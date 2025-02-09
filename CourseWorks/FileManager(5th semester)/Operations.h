#ifndef FILE_OPERATIONS_H
#define FILE_OPERATIONS_H

#include <stack>
#include <windows.h>
#include <string>
#include <vector>

extern HWND hListView, hBackButton, hForwardButton, hDeleteButton,
            hCopyButton, hPasteButton, hSearchBox, hComboBox;
extern std::wstring currentPath;
extern std::wstring clipboardPath;
extern std::stack<std::wstring> backStack;
extern std::stack<std::wstring> forwardStack;
extern std::vector<std::wstring> currentItems;

void DeleteDirectory(const std::wstring& dirPath);
void CopyDirectory(const std::wstring& source, const std::wstring& destination);
LRESULT CALLBACK WindowProc(HWND hwnd, UINT uMsg, WPARAM wParam, LPARAM lParam);
void InitializeComponents(HWND hwnd);
void LoadDirectoryContent(const std::wstring& path);
void FilterDirectoryContent(const std::wstring& directoryPath, const std::wstring& searchQuery);
void GoBack();
void GoForward();
void OpenSelectedItem();
void DeleteSelectedItem();
void CopySelectedItem();
void PasteItem();
void HandleDriveSelection();
void PopulateDrivesComboBox();
std::wstring GetUniqueName(const std::wstring& basePath, const std::wstring& name);

#endif // FILE_OPERATIONS_H
