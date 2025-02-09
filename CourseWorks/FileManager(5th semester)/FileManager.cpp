#include <windows.h>
#include <commctrl.h>
#include <string>
#include <vector>
#include <stack>
#include <shlwapi.h>
#include <strsafe.h>
#include "Operations.h"

#pragma comment(lib, "comctl32.lib")
#pragma comment(lib, "Shlwapi.lib")

#define LIST_VIEW_ID 7

HWND hListView, hBackButton, hForwardButton, hDeleteButton,
     hCopyButton, hPasteButton, hSearchBox, hComboBox;
std::wstring currentPath = L"C:\\";
std::wstring clipboardPath;
std::stack<std::wstring> backStack;
std::stack<std::wstring> forwardStack;
std::vector<std::wstring> currentItems;

HICON LoadAppIcon(const wchar_t* iconFilePath) {
    return (HICON)LoadImage(NULL, iconFilePath, IMAGE_ICON, 0, 0, LR_LOADFROMFILE);
}

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int nCmdShow) 
{
    SetProcessDpiAwarenessContext(DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
    WNDCLASS wc = {};
    wc.lpfnWndProc = WindowProc;
    wc.hInstance = hInstance;
    wc.lpszClassName = L"FileManagerWindow";

    wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);

    RegisterClass(&wc);

    RECT screenRect;
    SystemParametersInfo(SPI_GETWORKAREA, 0, &screenRect, 0);
    int screenWidth = screenRect.right;
    int screenHeight = screenRect.bottom;

    HWND hwnd = CreateWindowEx(0, L"FileManagerWindow", 
        L"Файловый менеджер", WS_OVERLAPPEDWINDOW | WS_VISIBLE | WS_MAXIMIZE,
        0, 0, screenWidth, screenHeight,
        NULL, NULL, hInstance, NULL);

    if (!hwnd)
        return 0;

    HICON hIcon = LoadAppIcon(L"file-explorer.ico"); 
    SendMessage(hwnd, WM_SETICON, ICON_BIG, (LPARAM)hIcon);

    ShowWindow(hwnd, nCmdShow);
    UpdateWindow(hwnd);

    MSG msg = {};
    while (GetMessage(&msg, NULL, 0, 0)) 
    {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }

    return 0;
}

ULONGLONG GetDirectorySize(const std::wstring& dirPath)
{
    ULONGLONG totalSize = 0;
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
                totalSize += GetDirectorySize(itemPath);
            }
            else
            {
                LARGE_INTEGER fileSize;
                fileSize.HighPart = findFileData.nFileSizeHigh;
                fileSize.LowPart = findFileData.nFileSizeLow;
                totalSize += fileSize.QuadPart;
            }
        } while (FindNextFile(hFind, &findFileData) != 0);

        FindClose(hFind);
    }
    return totalSize;
}


HWND CreateDialogWindow(const wchar_t* filePath)
{
    WNDCLASS wc = {};
    wc.lpfnWndProc = DefWindowProc;
    wc.hInstance = GetModuleHandle(NULL);
    wc.lpszClassName = L"DialogWindowClass";
    RegisterClass(&wc);

    HWND hWnd = CreateWindowEx(0, L"DialogWindowClass", L"Свойства", WS_OVERLAPPED | WS_VISIBLE | WS_SYSMENU,
        CW_USEDEFAULT, CW_USEDEFAULT, 400, 200, NULL, NULL,
        GetModuleHandle(NULL), NULL);

    HICON hIcon = LoadAppIcon(L"file-explorer.ico");
    SendMessage(hWnd, WM_SETICON, ICON_BIG, (LPARAM)hIcon);

    CreateWindowEx(0, L"STATIC", L"Имя:", WS_VISIBLE | WS_CHILD, 10, 10, 100, 25, hWnd, NULL,
        GetModuleHandle(NULL), NULL);
    HWND hFileName = CreateWindowEx(0, L"STATIC", L"", WS_VISIBLE | WS_CHILD | SS_LEFT, 110, 10, 250, 25, hWnd, NULL,
        GetModuleHandle(NULL), NULL);

    CreateWindowEx(0, L"STATIC", L"Размер:", WS_VISIBLE | WS_CHILD, 10, 40, 100, 25, hWnd, NULL,
        GetModuleHandle(NULL), NULL);
    HWND hSize = CreateWindowEx(0, L"STATIC", L"", WS_VISIBLE | WS_CHILD | SS_LEFT, 110, 40, 250, 25, hWnd, NULL,
        GetModuleHandle(NULL), NULL);

    HWND hCreationDateLabel = CreateWindowEx(
     0,                  
     L"STATIC",          
     L"Дата создания:",  
     WS_VISIBLE | WS_CHILD, 
     10, 70,             
     100, 25,            
     hWnd,               
     NULL,               
     GetModuleHandle(NULL), 
     NULL                
 );

    HWND hCreationDate = CreateWindowEx(
        0,                  
        L"STATIC",          
        L"",                
        WS_VISIBLE | WS_CHILD | SS_LEFT, 
        110, 70,            
        250, 25,            
        hWnd,               
        NULL,               
        GetModuleHandle(NULL), 
        NULL                
    );

    WIN32_FIND_DATA findFileData;
    HANDLE hFind = FindFirstFile(filePath, &findFileData);
    if (hFind != INVALID_HANDLE_VALUE)
    {
        SetWindowText(hFileName, findFileData.cFileName);

        if (findFileData.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
        {
            ULONGLONG dirSize = GetDirectorySize(filePath);
            std::wstring sizeStr = std::to_wstring(dirSize) + L" байт";
            SetWindowText(hSize, sizeStr.c_str());
        }
        else
        {
            LARGE_INTEGER fileSize;
            fileSize.HighPart = findFileData.nFileSizeHigh;
            fileSize.LowPart = findFileData.nFileSizeLow;
            std::wstring sizeStr = std::to_wstring(fileSize.QuadPart) + L" байт";
            SetWindowText(hSize, sizeStr.c_str());
        }

        FILETIME ft = findFileData.ftCreationTime;
        SYSTEMTIME st;
        FileTimeToSystemTime(&ft, &st);
        wchar_t date[100];
        swprintf(date, 100, L"%02d/%02d/%04d %02d:%02d", st.wDay, st.wMonth, st.wYear, st.wHour, st.wMinute);
        SetWindowText(hCreationDate, date);

        FindClose(hFind);
    }

    return hWnd;
}

void ShowFileProperties() 
{
    int selectedIndex = ListView_GetNextItem(hListView, -1, LVNI_SELECTED);
    if (selectedIndex != -1) 
    {
        wchar_t itemText[256] = {};
        LVITEM lvi = {};
        lvi.iSubItem = 0;
        lvi.pszText = itemText;
        lvi.cchTextMax = 256;
        lvi.iItem = selectedIndex;

        if (ListView_GetItem(hListView, &lvi)) 
        {
            std::wstring filePath = currentPath + L"\\" + itemText;

            HWND hDlg = CreateDialogWindow(filePath.c_str());
            ShowWindow(hDlg, SW_SHOW);
        }
    }
}


LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam) {
    switch (uMsg) 
    {
    case WM_CREATE:
        InitializeComponents(hwnd);
        PopulateDrivesComboBox();
        LoadDirectoryContent(currentPath);
        break;

    case WM_COMMAND:
        if (LOWORD(wParam) == 1) 
        {
            GoBack();
        }
        else if (LOWORD(wParam) == 2) 
        {
            GoForward();
        }
        else if (LOWORD(wParam) == 3) 
        {
            DeleteSelectedItem();
        }
        else if (LOWORD(wParam) == 4) 
        {
            CopySelectedItem();
        }
        else if (LOWORD(wParam) == 5)
        {
            PasteItem();
        }
        else if (LOWORD(wParam) == 6)
        {
            ShowFileProperties();
        }
        if (HIWORD(wParam) == CBN_SELCHANGE && LOWORD(wParam) == 7) {
            HandleDriveSelection();
        }
        else if (HIWORD(wParam) == EN_CHANGE && reinterpret_cast<HWND>(lParam) == hSearchBox) 
        {
            wchar_t searchQuery[256];
            GetWindowText(hSearchBox, searchQuery, 256);
            FilterDirectoryContent(currentPath, searchQuery);
        }
        else if (HIWORD(wParam) == LBN_DBLCLK)
        {
            OpenSelectedItem();
        }
        break;
    case WM_CTLCOLORSTATIC: {
        HDC hdcStatic = reinterpret_cast<HDC>(wParam);

        SetBkMode(hdcStatic, TRANSPARENT);

        SetTextColor(hdcStatic, RGB(0, 0, 0)); 

        return (INT_PTR)GetStockObject(NULL_BRUSH);
    }

    case WM_RBUTTONDOWN:
    {
        HMENU hPopupMenu = CreatePopupMenu();
        if (hPopupMenu) 
        {
            AppendMenu(hPopupMenu, MF_STRING, 1, L"Свойства");

            POINT pt;
            GetCursorPos(&pt);

            TrackPopupMenu(hPopupMenu, TPM_RIGHTBUTTON, pt.x, pt.y, 0, hwnd, NULL);
            DestroyMenu(hPopupMenu);
        }
    }
    break;
    case WM_CONTEXTMENU:
    {
        if (reinterpret_cast<HWND>(wParam) == hListView)
        {
            POINT pt;
            GetCursorPos(&pt);

            HMENU hPopupMenu = CreatePopupMenu();
            if (hPopupMenu) 
            {
                AppendMenu(hPopupMenu, MF_STRING, 6, L"Свойства");

                TrackPopupMenu(hPopupMenu, TPM_RIGHTBUTTON, pt.x, pt.y, 0, hwnd, NULL);
                DestroyMenu(hPopupMenu);
            }
        }
    }
    break;
    case WM_NOTIFY: 
    {
        LPNMHDR nmhdr = (LPNMHDR)lParam;
        if (nmhdr->idFrom == LIST_VIEW_ID && nmhdr->code == NM_DBLCLK) 
        {
            OpenSelectedItem();
        }
        break;
    }
    case WM_DESTROY:
        PostQuitMessage(0);
        return 0;
    default: ;
    }
    return DefWindowProc(hwnd, uMsg, wParam, lParam);
}

void PopulateDrivesComboBox() {
    SendMessage(hComboBox, CB_RESETCONTENT, 0, 0);

    DWORD drives = GetLogicalDrives();
    for (int i = 0; i < 26; ++i) {
        if (drives & (1 << i)) {
            wchar_t driveLetter[4] = { wchar_t('A' + i), L':', L'\\', L'\0' };
            SendMessage(hComboBox, CB_ADDSTRING, 0, (LPARAM)driveLetter);
        }
    }

    SendMessage(hComboBox, CB_SETCURSEL, 0, 0);

    wchar_t selectedDrive[4];
    SendMessage(hComboBox, CB_GETLBTEXT, 0, (LPARAM)selectedDrive);
    currentPath = selectedDrive;

    LoadDirectoryContent(currentPath);
}

void OnDriveSelectionChange() {
    int selectedIndex = SendMessage(hComboBox, CB_GETCURSEL, 0, 0);
    if (selectedIndex != CB_ERR) {
        wchar_t selectedDrive[4];
        SendMessage(hComboBox, CB_GETLBTEXT, selectedIndex, (LPARAM)selectedDrive);
        currentPath = selectedDrive;

        LoadDirectoryContent(currentPath);
    }
}


void HandleDriveSelection() {
    wchar_t selectedDrive[4];
    int index = SendMessage(hComboBox, CB_GETCURSEL, 0, 0);
    SendMessage(hComboBox, CB_GETLBTEXT, index, (LPARAM)selectedDrive);
    LoadDirectoryContent(selectedDrive);
}


void InitializeComponents(HWND hwnd) {
    HICON hBackIcon = (HICON)LoadImage(NULL, L"back.ico", IMAGE_ICON, 32, 32, LR_LOADFROMFILE);
    HICON hForwardIcon = (HICON)LoadImage(NULL, L"forward.ico", IMAGE_ICON, 32, 32, LR_LOADFROMFILE);
    HICON hDeleteIcon = (HICON)LoadImage(NULL, L"delete.ico", IMAGE_ICON, 32, 32, LR_LOADFROMFILE);
    HICON hCopyIcon = (HICON)LoadImage(NULL, L"copy.ico", IMAGE_ICON, 32, 32, LR_LOADFROMFILE);
    HICON hPasteIcon = (HICON)LoadImage(NULL, L"paste.ico", IMAGE_ICON, 32, 32, LR_LOADFROMFILE);

    RECT screenRect;
    SystemParametersInfo(SPI_GETWORKAREA, 0, &screenRect, 0);
    int screenHeight = screenRect.bottom;
    int screenWidth = screenRect.right;

    int buttonHeight = 40;  
    int listBoxHeight = screenHeight - 2 * buttonHeight - 20;

    hComboBox = CreateWindow(WC_COMBOBOX, L"", CBS_DROPDOWNLIST | WS_CHILD | WS_VISIBLE | WS_VSCROLL,
        400, 10, 100, 200, hwnd, (HMENU)6, NULL, NULL);

    hSearchBox = CreateWindowEx(WS_EX_CLIENTEDGE, L"EDIT", NULL,
        WS_CHILD | WS_VISIBLE | ES_AUTOHSCROLL, screenWidth - 330, 10, 300, 25, hwnd, NULL, NULL, NULL);

    hBackButton = CreateWindow(L"BUTTON", NULL, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_ICON,
        60, 10, 40, 40, hwnd, (HMENU)1, NULL, NULL);
    SendMessage(hBackButton, BM_SETIMAGE, IMAGE_ICON, (LPARAM)hBackIcon);  

    hForwardButton = CreateWindow(L"BUTTON", NULL, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_ICON,
        110, 10, 40, 40, hwnd, (HMENU)2, NULL, NULL);
    SendMessage(hForwardButton, BM_SETIMAGE, IMAGE_ICON, (LPARAM)hForwardIcon);  

    hDeleteButton = CreateWindow(L"BUTTON", NULL, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_ICON,
        10, 60, 40, 40, hwnd, (HMENU)3, NULL, NULL);
    SendMessage(hDeleteButton, BM_SETIMAGE, IMAGE_ICON, (LPARAM)hDeleteIcon);  

    hCopyButton = CreateWindow(L"BUTTON", NULL, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_ICON,
        10, 110, 40, 40, hwnd, (HMENU)4, NULL, NULL);
    SendMessage(hCopyButton, BM_SETIMAGE, IMAGE_ICON, (LPARAM)hCopyIcon);  

    hPasteButton = CreateWindow(L"BUTTON", NULL, WS_TABSTOP | WS_VISIBLE | WS_CHILD | BS_ICON,
        10, 160, 40, 40, hwnd, (HMENU)5, NULL, NULL);
    SendMessage(hPasteButton, BM_SETIMAGE, IMAGE_ICON, (LPARAM)hPasteIcon);

    hListView = CreateWindow(WC_LISTVIEW, NULL, WS_CHILD | WS_VISIBLE | LVS_REPORT | LVS_SINGLESEL | LVS_NOCOLUMNHEADER,
    60, buttonHeight + 20, GetSystemMetrics(SM_CXSCREEN) - 90, listBoxHeight, hwnd, (HMENU)LIST_VIEW_ID, NULL, NULL);

    ListView_SetExtendedListViewStyle(hListView, LVS_EX_FULLROWSELECT | LVS_EX_GRIDLINES);

    RECT rect;
    GetClientRect(hListView, &rect);
    int totalWidth = rect.right - rect.left;

    int columnWidth = totalWidth / 4;
    
    LVCOLUMN lvc = {};
    lvc.mask = LVCF_TEXT | LVCF_WIDTH | LVCF_SUBITEM;

    lvc.cx = columnWidth; 
    lvc.iSubItem = 0;
    ListView_InsertColumn(hListView, 0, &lvc);

    lvc.cx = columnWidth;
    lvc.iSubItem = 1;
    ListView_InsertColumn(hListView, 1, &lvc);

    lvc.cx = columnWidth;
    lvc.iSubItem = 2;
    ListView_InsertColumn(hListView, 2, &lvc);

    lvc.cx = columnWidth - 20;
    lvc.iSubItem = 3;
    ListView_InsertColumn(hListView, 3, &lvc);
}
