#include <stdio.h>
#include <stdlib.h>

int comp_count = 0;
int swap_count = 0;

int partition(int arr[], int left, int right, int pivot_index) {
    int pivot_value = arr[pivot_index];
    int temp = arr[right];
    arr[right] = arr[pivot_index];
    arr[pivot_index] = temp;
    int store_index = left;
    for (int i = left; i < right; i++) {
        if (arr[i] < pivot_value) {
            temp = arr[i];
            arr[i] = arr[store_index];
            arr[store_index] = temp; 
            store_index++;
            swap_count++;
        }
        comp_count++;
    }
    temp = arr[right];
    arr[right] = arr[store_index];
    arr[store_index] = temp;
    swap_count++;
    return store_index;
}

int randomized_partition(int arr[], int left, int right) {
    int pivot_index = rand() % (right - left + 1) + left;
    return partition(arr, left, right, pivot_index);
}

int randomized_select(int arr[], int left, int right, int k) {
    if (left == right) {
        return arr[left];
    }
    int pivot_index = randomized_partition(arr, left, right);
    int pivot_rank = pivot_index - left + 1;
    if (k == pivot_rank) {
        return arr[pivot_index];
    } else if (k < pivot_rank) {
        return randomized_select(arr, left, pivot_index - 1, k);
    } else {
        return randomized_select(arr, pivot_index + 1, right, k - pivot_rank);
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
    printf("Początkowy stan tablicy:\n");
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
    if (k>=1 && k<=n){
    	// wykonaj randomized select i wyświetl wyniki
    	int kth_smallest = randomized_select(arr, 0, n - 1, k);
    	printf("Znaleziona %d statystyka pozycyjna (randomized select): %d\n\n", k, kth_smallest);
    }
    else{
        printf("Wprowadż 1<=k<=n");
        return 0;
    }
    
    // Wyświetl liczby wykonanych porównań i przestawień
    printf("Liczba porównań: %d\n", comp_count);
    printf("Liczba przestawień: %d\n\n", swap_count);
    
    // wyświetl końcowy stan tablicy
    printf("Końcowy stan tablicy: \n");
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
