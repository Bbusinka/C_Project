#include <stdio.h>
#include <stdlib.h>
#include <time.h>

long long comp_count = 0;
struct timespec start_time, end_time;

long long timespec_diff(struct timespec start, struct timespec end) {
    return (end.tv_sec - start.tv_sec) * 1000000000LL + (end.tv_nsec - start.tv_nsec);
}

int binarySearch(int arr[], int left, int right, int value) {
    while (left <= right) {
    	comp_count++;
        int mid = left + (right - left) / 2;

        if (arr[mid] == value) {
            return 1;
        }

        if (arr[mid] < value) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return 0;
}

void quickSort(int arr[], int low, int high);
int partition(int arr[], int low, int high);
void swapElements(int* a, int* b);

void quickSort(int arr[], int low, int high) {
    if (low < high) {
        int pivot = partition(arr, low, high);
        quickSort(arr, low, pivot - 1);
        quickSort(arr, pivot + 1, high);
    }
}

int partition(int arr[], int low, int high) {
    int pivot = arr[high];
    int i = (low - 1);

    for (int j = low; j <= high - 1; j++) {
        if (arr[j] < pivot) {
            i++;
            swapElements(&arr[i], &arr[j]);
        }
    }

    swapElements(&arr[i + 1], &arr[high]);
    return (i + 1);
}

void swapElements(int* a, int* b) {
    int temp = *a;
    *a = *b;
    *b = temp;
}

int main() {
    FILE* file = fopen("results.txt", "w");
    if (file == NULL) {
        printf("Failed to open the file.\n");
        return 1;
    }

    srand(time(NULL));

    for (int n = 1000; n <= 100000; n += 1000) {
        long long total_comp_count = 0;
        double total_time = 0.0;

        for (int r = 0; r < 50; r++) {
            int* arr = (int*)malloc(n * sizeof(int));

            for (int i = 0; i < n; i++) {
                arr[i] = rand() % (2 * n);
            }

            quickSort(arr, 0, n - 1);

            int value = arr[rand() % n];
            comp_count = 0;

            clock_gettime(CLOCK_MONOTONIC, &start_time);
            int result = binarySearch(arr, 0, n - 1, value);
            clock_gettime(CLOCK_MONOTONIC, &end_time);

            if (result == 1) {
                total_comp_count += comp_count;
                total_time += timespec_diff(start_time, end_time);
            }

            free(arr);
        }

        double avg_comp_count = (double)total_comp_count / 50;
        double avg_time = total_time / 50;

        fprintf(file, "%d,%.2f,%lld\n", n, avg_time, total_comp_count);
    }

    fclose(file);
    return 0;
}

