#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

int comp_count = 0;
int swap_count = 0;

void swap(int* a, int* b) {
    int temp = *a;
    *a = *b;
    *b = temp;
    swap_count++;
}

void dualPivotQuickSortAsc(int arr[], int low, int high) {
    if (low < high) {
        if (arr[low] > arr[high]) {
            swap(&arr[low], &arr[high]);
            comp_count++;
        }

        int pivot1 = arr[low];
        int pivot2 = arr[high];

        int i = low + 1;
        int k = low + 1;
        int j = high - 1;

        while (k <= j) {
	    comp_count++;
            if (arr[k] < pivot1) {
                swap(&arr[k], &arr[i]);
                i++;
                //comp_count++;
            } else if (arr[k] >= pivot2) {
                while (arr[j] > pivot2 && k < j) {
                    j--;
                    //comp_count++;
                }
                swap(&arr[k], &arr[j]);
                j--;
                //comp_count++;
                if (arr[k] < pivot1) {
                    swap(&arr[k], &arr[i]);
                    i++;
                }
            }
            k++;
        }

        i--;
        j++;

        swap(&arr[low], &arr[i]);
        swap(&arr[high], &arr[j]);

        dualPivotQuickSortAsc(arr, low, i - 1);
        dualPivotQuickSortAsc(arr, i + 1, j - 1);
        dualPivotQuickSortAsc(arr, j + 1, high);
    }
}


void dualPivotQuickSortDesc(int arr[], int low, int high) {
    if (low < high) {
        if (arr[low] < arr[high]) {
            swap(&arr[low], &arr[high]);
            comp_count++;
        }

        int pivot1 = arr[low];
        int pivot2 = arr[high];

        int i = low + 1;
        int k = low + 1;
        int j = high - 1;

        while (k <= j) {
	    comp_count++;
            if (arr[k] > pivot1) {
                swap(&arr[k], &arr[i]);
                i++;
                //comp_count++;
            } else if (arr[k] <= pivot2) {
                while (arr[j] < pivot2 && k < j) {
                    j--;
                    //comp_count++;
                }
                swap(&arr[k], &arr[j]);
                j--;
                //comp_count++;
                if (arr[k] > pivot1) {
                    swap(&arr[k], &arr[i]);
                    i++;
                }
            }
            k++;
        }

        i--;
        j++;

        swap(&arr[low], &arr[i]);
        swap(&arr[high], &arr[j]);

        dualPivotQuickSortDesc(arr, low, i - 1);
        dualPivotQuickSortDesc(arr, i + 1, j - 1);
        dualPivotQuickSortDesc(arr, j + 1, high);
    }
}

int main() {
    int n;
    scanf("%d", &n);
    int* arr = (int*) malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        scanf("%d", &arr[i]);
    }
    printf("Ciąg losowy:\n");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    int* arr_asc = (int*) malloc(n * sizeof(int));
    memcpy(arr_asc, arr, n * sizeof(int));
    printf("\n\nCiąg posortowany rosnąco:\n");
    comp_count = 0;
    swap_count = 0;
    dualPivotQuickSortAsc(arr_asc, 0, n-1);
    for (int i = 0; i < n; i++) {
        printf("%d ", arr_asc[i]);
    }
    printf("\n");
    printf("Liczba porównań: %d\n", comp_count);
    printf("Liczba zamian: %d\n", swap_count);
    int* arr_desc = (int*) malloc(n * sizeof(int));
    memcpy(arr_desc, arr, n * sizeof(int));
    printf("\n\nCiąg posortowany malejąco:\n");
    comp_count = 0;
    swap_count = 0;
    dualPivotQuickSortDesc(arr_desc, 0, n-1);
    for (int i = 0; i < n; i++) {
        printf("%d ", arr_desc[i]);
    }
    printf("\n");
    printf("Liczba porównań: %d\n", comp_count);
    printf("Liczba zamian: %d\n", swap_count);
    free(arr);
    free(arr_asc);
    free(arr_desc);
    return 0;

}
