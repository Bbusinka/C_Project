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


void swap(int* a, int* b) {
    int temp = *a;
    *a = *b;
    *b = temp;
    swap_count++;
}

int partition(int arr[], int low, int high) {
    int pivot = arr[high];  
    int i = (low - 1); 

    for (int j = low; j <= high - 1; j++) {
        comp_count++;
        if (arr[j] <= pivot) {
            i++;  
            if (&arr[i] != &arr[j]){
            swap(&arr[i], &arr[j]);
            }
        }
    }
  
    if (&arr[i + 1] != &arr[high]){
        swap(&arr[i + 1], &arr[high]); 
    }
    return (i + 1);
}


void quickSort(int arr[], int low, int high) {
    if (low < high) {
        int pi = partition(arr, low, high);
        quickSort(arr, low, pi - 1);
        quickSort(arr, pi + 1, high);
    }
}


int partition2(int arr[], int low, int high) {
    int pivot = arr[(low + high) / 2];  
    int i = low - 1; 
    int j = high + 1;
    while (1) {
        do {
            i++;
            comp_count++;
        } while (arr[i] > pivot);

        do {
            j--;
            comp_count++;
        } while (arr[j] < pivot);

        if (i >= j) {
            return j;
        }
        
        if (arr[i] == arr[j]) {
            continue; 
        }

        swap(&arr[i], &arr[j]);
    }
    
}

void quickSort2(int arr[], int low, int high) {
    if (low < high) {
        int pi = partition2(arr, low, high);
        quickSort2(arr, low, pi - 1);
        quickSort2(arr, pi + 1, high);
    }
}

void hybridSort(int arr[], int l, int r) {
    if (r - l <= 20) {
        insertionSort(arr + l, r - l + 1);
    } else {
        int pi = partition(arr, l, r);
        hybridSort(arr, l, pi - 1);
        hybridSort(arr, pi + 1, r);
    }
}

void hybridSort2(int arr[], int l, int r) {
    if (r - l <= 20) {
        insertionSort2(arr + l, r - l + 1);
    } else {
        int pi = partition2(arr, l, r);
        hybridSort2(arr, l, pi - 1);
        hybridSort2(arr, pi + 1, r);
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
    hybridSort(arr_asc, 0, n - 1);
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
    hybridSort2(arr_desc, 0, n - 1);
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





