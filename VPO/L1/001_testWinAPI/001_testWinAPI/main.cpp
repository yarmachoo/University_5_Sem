#include <windows.h>
#include <tchar.h>
#include "resource.h"

INT_PTR CALLBACK MainDlgProc(HWND, UINT, WPARAM, LPARAM);

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, LPSTR, int)
{
	return DialogBox(hInst, MAKEINTRESOURCE(IDD_MAIN), NULL, MainDlgProc, 0L);
}

INT_PTR CALLBACK MainDlgProc(HWND hDlg, UINT uiMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uiMsg)
	{
	case WM_INITDIALOG:
		return 1;
	case WM_COMMAND:
	{
		switch (LOWORD(wParam))
		{
		case IDC_RUN:
			return 1;
		case IDCANCEL:
			EndDialog(hDlg, 0);
			return 1;
		}
		break;
	}

	}
	return 0;
}