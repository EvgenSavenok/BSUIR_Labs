#include "Operations.h"

#include <commctrl.h>

void DeleteDirectory(const std::wstring& dirPath) 
{
    WIN32_FIND_DATA findFileData;
    HANDLE hFind = FindFirstFile((dirPath + L"\\*").c_str(), &findFileData);

    if (hFind != INVALID_HANDLE_VALUE) 
    {
        do
        {
            std::wstring itemName = findFileData.cFileName;
            if (itemName == L"." || itemName == L"..") 
                continue;

            std::wstring itemPath = dirPath + L"\\" + itemName;

            if (findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
            {
                DeleteDirectory(itemPath);
            }
            else
            {
                DeleteFile(itemPath.c_str());
            }
        } while (FindNextFile(hFind, &findFileData) != 0);
        FindClose(hFind);
        RemoveDirectory(dirPath.c_str());
    }
}

void CopyDirectory(const std::wstring& source, const std::wstring& destination) 
{
    if (!CreateDirectory(destination.c_str(), NULL)) 
    {
        return;
    }

    WIN32_FIND_DATA findFileData;
    HANDLE hFind = FindFirstFile((source + L"\\*").c_str(), &findFileData);

    if (hFind != INVALID_HANDLE_VALUE) 
    {
        do 
        {
            std::wstring itemName = findFileData.cFileName;
            if (itemName == L"." || itemName == L"..") 
                continue;

            std::wstring itemPath = source + L"\\" + itemName;
            std::wstring newDestination = destination + L"\\" + itemName;

            if (findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) 
            {
                CopyDirectory(itemPath, newDestination);
            }
            else 
            {
                CopyFile(itemPath.c_str(), newDestination.c_str(), FALSE);
            }
        } 
        while (FindNextFile(hFind, &findFileData) != 0);
        FindClose(hFind);
    }
}

std::wstring GetFilePermissions(const std::wstring& filePath) 
{
    DWORD attributes = GetFileAttributes(filePath.c_str());
    if (attributes == INVALID_FILE_ATTRIBUTES) 
    {
        return L"---"; 
    }

    std::wstring permissions = L"";

    HANDLE hFile = CreateFile(
        filePath.c_str(),
        GENERIC_READ,
        FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE,
        NULL,
        OPEN_EXISTING,
        FILE_ATTRIBUTE_NORMAL,
        NULL
    );

    if (hFile != INVALID_HANDLE_VALUE) 
    {
        permissions += L"r";
        CloseHandle(hFile);
    } 
    else 
    {
        permissions += L"-";
    }

    hFile = CreateFile(
        filePath.c_str(),
        GENERIC_WRITE,
        FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE,
        NULL,
        OPEN_EXISTING,
        FILE_ATTRIBUTE_NORMAL,
        NULL
    );

    if (hFile != INVALID_HANDLE_VALUE) 
    {
        permissions += L"w";
        CloseHandle(hFile);
    } 
    else 
    {
        permissions += L"-";
    }

    bool isExecutable = false;
    std::wstring extensions[] = { L".exe", L".bat", L".cmd" };

    for (const auto& ext : extensions) 
    {
        if (filePath.size() >= ext.size() &&
            filePath.compare(filePath.size() - ext.size(), ext.size(), ext) == 0) 
        {
            isExecutable = true;
            break;
        }
    }

    if (isExecutable) 
    {
        permissions += L"x";
    } 
    else 
    {
        permissions += L"-";
    }
    return permissions;
}

void LoadDirectoryContent(const std::wstring& path) {
    currentItems.clear();
    ListView_DeleteAllItems(hListView);

    WIN32_FIND_DATA findFileData;
    HANDLE hFind = FindFirstFile((path + L"\\*").c_str(), &findFileData);

    if (hFind != INVALID_HANDLE_VALUE) {
        do {
            std::wstring itemName = findFileData.cFileName;
            if (itemName == L"." || itemName == L"..")
                continue;

            currentItems.push_back(itemName);

            LVITEM lvi = {};
            lvi.mask = LVIF_TEXT;
            lvi.iItem = ListView_GetItemCount(hListView);

            lvi.iSubItem = 0;
            lvi.pszText = const_cast<wchar_t*>(itemName.c_str());
            ListView_InsertItem(hListView, &lvi);

            if (!(findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)) {
                LARGE_INTEGER fileSize;
                fileSize.HighPart = findFileData.nFileSizeHigh;
                fileSize.LowPart = findFileData.nFileSizeLow;

                std::wstring sizeStr = std::to_wstring(fileSize.QuadPart);
                std::wstring size = L" байт";
                sizeStr += size;
                ListView_SetItemText(hListView, lvi.iItem, 1, const_cast<wchar_t*>(sizeStr.c_str()));
            } else {
                std::wstring sizeStr = L"Папка";
                ListView_SetItemText(hListView, lvi.iItem, 1, const_cast<wchar_t*>(sizeStr.c_str()));
            }

            std::wstring filePath = path + L"\\" + itemName;
            std::wstring permissions = GetFilePermissions(filePath);
            ListView_SetItemText(hListView, lvi.iItem, 3, const_cast<wchar_t*>(permissions.c_str()));

            FILETIME ft = findFileData.ftCreationTime;
            SYSTEMTIME st;
            FileTimeToSystemTime(&ft, &st);
            wchar_t date[100];
            swprintf(date, 100, L"%02d/%02d/%04d %02d:%02d", st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
            ListView_SetItemText(hListView, lvi.iItem, 2, date);

        } while (FindNextFile(hFind, &findFileData) != 0);

        FindClose(hFind);
    }
}

std::wstring GetUniqueName(const std::wstring& basePath, const std::wstring& name) 
{
    std::wstring newName = name;
    std::wstring fullPath = basePath + L"\\" + newName;

    int counter = 1;
    while (GetFileAttributes(fullPath.c_str()) != INVALID_FILE_ATTRIBUTES) 
    {
        newName = name + L" (" + std::to_wstring(counter++) + L")";
        fullPath = basePath + L"\\" + newName;
    }

    return newName;
}

void PasteItem() 
{
    if (!clipboardPath.empty()) 
    {
        size_t lastSlashPos = clipboardPath.find_last_of(L"\\/");
        std::wstring itemName = clipboardPath.substr(lastSlashPos + 1);

        itemName = GetUniqueName(currentPath, itemName);
        std::wstring destinationPath = currentPath + L"\\" + itemName;

        DWORD attributes = GetFileAttributes(clipboardPath.c_str());
        if (attributes & FILE_ATTRIBUTE_DIRECTORY) 
        {
            CopyDirectory(clipboardPath, destinationPath); 
        }
        else 
        {
            if (!CopyFile(clipboardPath.c_str(), destinationPath.c_str(), FALSE)) 
            {
                MessageBox(NULL, L"Ошибка при копировании файла.", L"Ошибка", MB_OK | MB_ICONERROR);
            }
        }
        LoadDirectoryContent(currentPath); 
    }
    else 
    {
        MessageBox(NULL, L"Буфер пуст. Сначала скопируйте файл или каталог.", L"Ошибка", MB_OK | MB_ICONWARNING);
    }
}


void GoBack()
{
    if (!backStack.empty())
    {
        forwardStack.push(currentPath);
        currentPath = backStack.top();
        backStack.pop();
        LoadDirectoryContent(currentPath);
    }
}

void GoForward() 
{
    if (!forwardStack.empty()) 
    {
        backStack.push(currentPath);
        currentPath = forwardStack.top();
        forwardStack.pop();
        LoadDirectoryContent(currentPath);
    }
}

void OpenSelectedItem() 
{
    int index = ListView_GetNextItem(hListView, -1, LVNI_SELECTED);
    if (index != -1) 
    {
        wchar_t itemText[256];
        LVITEM lvItem;
        lvItem.iSubItem = 0; 
        lvItem.pszText = itemText;
        lvItem.cchTextMax = sizeof(itemText) / sizeof(wchar_t);
        lvItem.iItem = index;

        SendMessage(hListView, LVM_GETITEMTEXT, index, (LPARAM)&lvItem);
        
        std::wstring newPath = currentPath + L"\\" + itemText;

        WIN32_FIND_DATA findFileData;
        HANDLE hFind = FindFirstFile((newPath + L"\\*").c_str(), &findFileData);

        if (hFind != INVALID_HANDLE_VALUE) 
        {
            backStack.push(currentPath);
            forwardStack = std::stack<std::wstring>();
            currentPath = newPath;
            LoadDirectoryContent(currentPath);
            FindClose(hFind);
        }
        else 
        {
            ShellExecute(NULL, L"open", newPath.c_str(), NULL, NULL, SW_SHOWNORMAL);
        }
    }
}

void DeleteSelectedItem() 
{
    int index = ListView_GetNextItem(hListView, -1, LVNI_SELECTED);
    if (index != -1) 
    {
        wchar_t itemText[256];
        LVITEM lvItem = {};
        lvItem.iSubItem = 0; 
        lvItem.pszText = itemText;
        lvItem.cchTextMax = sizeof(itemText) / sizeof(wchar_t);
        lvItem.iItem = index;

        SendMessage(hListView, LVM_GETITEMTEXT, index, (LPARAM)&lvItem);

        std::wstring selectedItem = currentPath + L"\\" + itemText;
        DWORD attributes = GetFileAttributes(selectedItem.c_str());

        if (attributes & FILE_ATTRIBUTE_DIRECTORY) 
        {
            DeleteDirectory(selectedItem); 
        }
        else 
        {
            if (!DeleteFile(selectedItem.c_str())) 
            {
                MessageBox(NULL, L"Ошибка при удалении файла.", L"Ошибка", MB_OK | MB_ICONERROR);
            }
        }
        LoadDirectoryContent(currentPath); 
    }
    else 
    {
        MessageBox(NULL, L"Элемент не выбран.", L"Ошибка", MB_OK | MB_ICONWARNING);
    }
}


void CopySelectedItem() 
{
    int index = ListView_GetNextItem(hListView, -1, LVNI_SELECTED);
    if (index != -1) 
    {
        wchar_t itemText[256];
        LVITEM lvItem = {};
        lvItem.iSubItem = 0; 
        lvItem.pszText = itemText;
        lvItem.cchTextMax = sizeof(itemText) / sizeof(wchar_t);
        lvItem.iItem = index;

        SendMessage(hListView, LVM_GETITEMTEXT, index, (LPARAM)&lvItem);

        clipboardPath = currentPath + L"\\" + itemText; 
    }
    else 
    {
        MessageBox(NULL, L"Элемент не выбран.", L"Ошибка", MB_OK | MB_ICONWARNING);
    }
}


void SearchInDirectory(const std::wstring& directoryPath, const std::wstring& searchQuery)
{
    WIN32_FIND_DATA findFileData;
    HANDLE hFind = FindFirstFile((directoryPath + L"\\*").c_str(), &findFileData);

    if (hFind == INVALID_HANDLE_VALUE) 
    {
        return;
    }

    do
    {
        const std::wstring itemName = findFileData.cFileName;

        if (itemName == L"." || itemName == L"..") 
        {
            continue;
        }

        const std::wstring fullPath = directoryPath + L"\\" + itemName;

        if (findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
        {
            SearchInDirectory(fullPath, searchQuery);
        }
        else 
        {
            if (itemName.find(searchQuery) != std::wstring::npos) 
            {
                currentItems.push_back(fullPath); 
            }
        }
    } while (FindNextFile(hFind, &findFileData) != 0);

    FindClose(hFind);
}

void FilterDirectoryContent(const std::wstring& directoryPath, const std::wstring& searchQuery) 
{
    currentItems.clear();

    SendMessage(hListView, LVM_DELETEALLITEMS, 0, 0);

    if (searchQuery.empty()) 
    {
        WIN32_FIND_DATA findFileData;
        HANDLE hFind = FindFirstFile((directoryPath + L"\\*").c_str(), &findFileData);

        if (hFind != INVALID_HANDLE_VALUE) 
        {
            do 
            {
                const std::wstring itemName = findFileData.cFileName;

                if (itemName != L"." && itemName != L"..") 
                {
                    currentItems.push_back(itemName);
                }

            } while (FindNextFile(hFind, &findFileData));

            FindClose(hFind);
        }
    } 
    else 
    {
        SearchInDirectory(directoryPath, searchQuery);
    }

    LVITEM lvItem = {};
    lvItem.mask = LVIF_TEXT; 

    int index = 0;
    for (const auto& item : currentItems) 
    {
        lvItem.iItem = index++;  
        lvItem.pszText = const_cast<wchar_t*>(item.c_str()); 
        SendMessage(hListView, LVM_INSERTITEM, 0, (LPARAM)&lvItem);
    }
}
