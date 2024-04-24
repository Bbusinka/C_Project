#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
int comp_count = 0;
int swap_count = 0;

void insertionSort(int arr[], int n) {
    for (int i = 1; i < n; i++) {
        int key = arr[i];
        int j = i - 1;

        while (j >= 0 && arr[j] > key) {
            arr[j + 1] = arr[j];
            j = j - 1;
            comp_count++;
            swap_count++;
        }
        arr[j + 1] = key;
        if (j>=0){
            comp_count++;
        }
    }
}

void insertionSort2(int arr[], int n) {
    for (int i = 1; i < n; i++) {
        int key = arr[i];
        int j = i - 1;
        while (j >= 0 && arr[j] < key) {
            arr[j + 1] = arr[j];
            j = j - 1;
            comp_count++;
            swap_count++;
        }
        arr[j + 1] = key;
        if (j>=0){
            comp_count++;
        }
    }
}


void merge(int arr[], int l, int m, int r) {
    int i, j, k;
    int n1 = m - l + 1;
    int n2 = r - m;

    int L[n1], R[n2];

    for (i = 0; i < n1; i++) {
        L[i] = arr[l + i];
    }
    for (j = 0; j < n2; j++) {
        R[j] = arr[m + 1 + j];
    }

    i = 0;
    j = 0;
    k = l;

    while (i < n1 && j < n2) {
        if (L[i] <= R[j]) {
            arr[k] = L[i];
            i++;
        } else {
            arr[k] = R[j];
            j++;
        }
        k++;
        comp_count++;
        swap_count++;
    }

    while (i < n1) {
        arr[k] = L[i];
        i++;
        k++;
        swap_count++;
    }

    while (j < n2) {
        arr[k] = R[j];
        j++;
        k++;
        swap_count++;
    }
}


void merge2(int arr[], int l, int m, int r) {
    int i, j, k;
    int n1 = m - l + 1;
    int n2 = r - m;

    int L[n1], R[n2];

    for (i = 0; i < n1; i++) {
        L[i] = arr[l + i];
    }
    for (j = 0; j < n2; j++) {
        R[j] = arr[m + 1 + j];
    }

    i = 0;
    j = 0;
    k = l;

    while (i < n1 && j < n2) {
        if (L[i] >= R[j]) {
            arr[k] = L[i];
            i++;
        } else {
            arr[k] = R[j];
            j++;
        }
        k++;
        comp_count++;
        swap_count++;
    }

    while (i < n1) {
        arr[k] = L[i];
        i++;
        k++;
        swap_count++;
    }

    while (j < n2) {
        arr[k] = R[j];
        j++;
        k++;
        swap_count++;
    }
}

void hybridSort(int arr[], int l, int r) {
    if (r - l <= 20) {
        insertionSort(arr + l, r - l + 1);
    } else {
        int m = l + (r - l) / 2;
        hybridSort(arr, l, m);
        hybridSort(arr, m + 1, r);
        merge(arr, l, m, r);
    }
}

void hybridSort2(int arr[], int l, int r) {
    if (r - l <= 20) {
        insertionSort2(arr + l, r - l + 1);
    } else {
        int m = l + (r - l) / 2;
        hybridSort2(arr, l, m);
        hybridSort2(arr, m + 1, r);
        merge2(arr, l, m, r);
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
    hybridSort(arr_asc, 0, n-1);
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
    hybridSort2(arr_desc, 0, n-1);
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





