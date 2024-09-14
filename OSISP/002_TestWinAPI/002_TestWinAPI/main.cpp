#include <windows.h>
#include <tchar.h>
#include "resource.h"

//
// Common Data
//

HWND hMainDlg = NULL;
const int nArraySize = 65535;
int nSortState[3] = { 0 };


void FillArray(int* arr, int size)
{
	for (int i = 0; i < size; ++i)
		arr[i] = rand() % 1000;
}

void SelectSort(int* arr, int size)
{
	int tmp;
	for (int i = 0; i < size; ++i) // i - ����� �������� ����
	{
		int pos = i;
		tmp = arr[i];
		for (int j = i + 1; j < size; ++j) // ���� ������ ����������� ��������
		{
			if (arr[j] < tmp)
			{
				pos = j;
				tmp = arr[j];
			}
		}
		arr[pos] = arr[i];
		arr[i] = tmp; // ������ ������� ���������� � a[i]
	}
}

void BubbleSort(int* arr, int size)
{
	int tmp;

	for (int i = 0; i < size - 1; ++i) // i - ����� �������
	{
		for (int j = 0; j < size - 1; ++j) // ���������� ���� �������
		{
			if (arr[j + 1] < arr[j])
			{
				tmp = arr[j + 1];
				arr[j + 1] = arr[j];
				arr[j] = tmp;
			}
		}
	}
}

void QuickSort(int* a, int N) {
	// �� ����� - ������ a[], a[N] - ��� ��������� �������.

	int i = 0, j = N;      // ��������� ��������� �� �������� �����
	int temp, p;

	p = a[N >> 1];      // ����������� �������

	// ��������� ����������
	do {
		while (a[i] < p) i++;
		while (a[j] > p) j--;

		if (i <= j) {
			temp = a[i];
			a[i] = a[j];
			a[j] = temp;
			i++; j--;
		}
	} while (i <= j);

	// ����������� ������, ���� ����, ��� �����������
	if (j > 0) QuickSort(a, j);
	if (N > i) QuickSort(a + i, N - i);
}

LPCTSTR StateToString(int nState)
{
	switch (nState)
	{
	case 0: return TEXT("READY");
	case 1: return TEXT("RUNNING");
	}
	return TEXT("");
}


void UpdateDialog(int index, int state)
{
	nSortState[index] = state;
	PostMessage(hMainDlg, WM_APP + 1, 0, 0);
}
//
// ThreadProc
//

DWORD WINAPI ThreadProc(LPVOID lpParameter)
{
	int index = (int)lpParameter;
	UpdateDialog(index, 1);

	int* array = new int[nArraySize];
	FillArray(array, nArraySize);

	switch (index)
	{
	case 0: SelectSort(array, nArraySize); break;
	case 1: BubbleSort(array, nArraySize); break;
	case 2: QuickSort(array, nArraySize - 1); break;
	}

	
	delete[] array;
	UpdateDialog(index, 0);
	return 0;
}

INT_PTR CALLBACK MainDlgPro�(HWND hDlg, UINT uiMsg, WPARAM wParam, LPARAM lParam)
{
	switch (uiMsg)
	{
	case WM_INITDIALOG:
		hMainDlg = hDlg;
		PostMessage(hMainDlg, WM_APP + 1, 0, 0);
		return 1;
	case WM_COMMAND: 
	{
		switch (LOWORD(wParam))
		{
		case IDC_RUN:
			CreateThread(NULL, 0, ThreadProc, (LPVOID)0, 0, NULL);
			CreateThread(NULL, 0, ThreadProc, (LPVOID)1, 0, NULL);
			CreateThread(NULL, 0, ThreadProc, (LPVOID)2, 0, NULL);
			return 1;
		case IDCANCEL:
			EndDialog(hDlg, 0);
			return 1;
		}
		break;

	}
	case WM_APP+1:
		SetDlgItemText(hDlg, IDC_SELECTSORT, StateToString(nSortState[0]));
		SetDlgItemText(hDlg, IDC_BUBBLESORT, StateToString(nSortState[1]));
		SetDlgItemText(hDlg, IDC_QUICKSORT, StateToString(nSortState[2]));
		EnableWindow(GetDlgItem(hDlg, IDC_RUN), !(nSortState[0] || nSortState[1] || nSortState[2]));
		return 1;
	}
	return 0;
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE, LPSTR, int)
{
	srand(3647);
	return DialogBox(hInst, MAKEINTRESOURCE(IDD_MAIN), NULL, MainDlgPro�);
}