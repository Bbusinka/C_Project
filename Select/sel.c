#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int comp_count = 0;
int swap_count = 0;

int partition(int arr[], int left, int right) {
    int size = right - left + 1;
    int temp;
    if (size <= 5) {
        // Sortowanie małych podtablicy przy użyciu np. sortowania bąbelkowego
        for (int i = left; i <= right; i++) {
            for (int j = left; j < right; j++) {
            comp_count++;
                if (arr[j] > arr[j + 1]) {
                swap_count++;
                    temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
        return (left + right) / 2;
    }

    // Dzielenie na grupy po 5 elementów i wyznaczanie median dla każdej grupy
    for (int i = 0; i < size / 5; i++) {
        int start = left + i * 5;
        int end = start + 4;
        if (end > right) {
            end = right;
        }
        int medianIndex = partition(arr, start, end);
        temp = arr[medianIndex];
        arr[medianIndex] = arr[left + i];
        arr[left + i] = temp;
    }

    // Rekurencyjne wywołanie partition dla mediany median
    int medianOfMediansIndex = partition(arr, left, left + (size / 5) - 1);

    // Zamiana mediany median z ostatnim elementem
    temp = arr[medianOfMediansIndex];
    arr[medianOfMediansIndex] = arr[right];
    arr[right] = temp;

    // Standardowe podziału względem pivota
    int pivot = arr[right];
    int i = left - 1;
    for (int j = left; j < right; j++) {
        if (arr[j] < pivot) {
            i++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    temp = arr[i + 1];
    arr[i + 1] = arr[right];
    arr[right] = temp;

    return i + 1;
}


int sel(int arr[], int left, int right, int k) {
    if (left == right) {
        return arr[left];
    }
    int pivot_index = partition(arr, left, right);
    int pivot_rank = pivot_index - left + 1;
    if (k == pivot_rank) {
        return arr[pivot_index];
    } else if (k < pivot_rank) {
        return sel(arr, left, pivot_index - 1, k);
    } else {
        return sel(arr, pivot_index + 1, right, k - pivot_rank);
    }
}

int main(int argc, char* argv[]) {
    int n, k;
    scanf("%d", &n);
    int* arr = (int*) malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        scanf("%d", &arr[i]);
    }
    
    // wyświetl początkowy stan tablicy
    printf("Początkowy stan tablicy: ");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n\n");
    if (argc != 2) {
        fprintf(stderr, "Usage: %s k\n", argv[0]);
        return 0;
    }
    //k-ta statystyka
    k = atoi(argv[1]);
    if (k>=1 && k<=n){    // wykonaj select i wyświetl wyniki
    	int kth_smallest = sel(arr, 0, n - 1, k);
    	printf("Znaleziona %d-ta statystyka pozycyjna (select): %d\n", k, kth_smallest);
    }
    else{
        printf("Wprowadż 1<=k<=n");
        return 0;
    }
    
    // Wyświetl liczby wykonanych porównań i przestawień
    printf("Liczba porównań: %d\n", comp_count);
    printf("Liczba przestawień: %d\n\n", swap_count);


    // wyświetl końcowy stan tablicy
    printf("Końcowy stan tablicy: ");
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n\n");
    
    // posortuj tablicę i wyświetl
    for (int i = 0; i < n - 1; i++) {
   	for (int j = 0; j < n - i - 1; j++) {
        	if (arr[j] > arr[j + 1]) {
        	int temp = arr[j];
            	arr[j] = arr[j + 1];
             	arr[j + 1] = temp;
        	}
    	}
    }

    printf("Posortowany ciąg kluczy: ");
    for (int i = 0; i < n; i++) {
         printf("%d ", arr[i]);
    }
	printf("\n");
    
    comp_count = 0;
    swap_count = 0;
    free(arr);
    return 0;
}

