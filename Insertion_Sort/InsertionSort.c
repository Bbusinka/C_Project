#include <stdio.h>
#include <stdlib.h>
#include <string.h>
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



int main(int argc, char* argv[]) {
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
    insertionSort(arr_asc, n);
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
    insertionSort2(arr_desc, n);
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
