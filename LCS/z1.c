#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

// Funkcja obliczająca maksimum z dwóch liczb
int max(int a, int b) {
    return (a > b) ? a : b;
}

// Funkcja znajdująca najdłuższy wspólny podciąg
int longest_common_subsequence(char* str1, char* str2, int m, int n) {
    // Tworzenie dwuwymiarowej tablicy dp do przechowywania wyników pośrednich
    int** dp = (int**)malloc((m + 1) * sizeof(int*));
    for (int i = 0; i <= m; i++) {
        dp[i] = (int*)malloc((n + 1) * sizeof(int));
    }

    // Wypełnianie tablicy dp
    for (int i = 0; i <= m; i++) {
        for (int j = 0; j <= n; j++) {
            if (i == 0 || j == 0)
                dp[i][j] = 0; // Warunek początkowy: dla pustych ciągów LCS wynosi 0
            else if (str1[i - 1] == str2[j - 1]) {
                dp[i][j] = dp[i - 1][j - 1] + 1; // Jeśli znaki są identyczne, zwiększamy długość LCS o 1
            }
            else {
                dp[i][j] = max(dp[i - 1][j], dp[i][j - 1]); // Jeśli znaki się nie zgadzają, wybieramy maksimum z LCS dla poprzednich podciągów
            }
        }
    }

    int lcs_length = dp[m][n]; // Długość LCS

    // Zwolnienie pamięci zajmowanej przez tablicę dp
    for (int i = 0; i <= m; i++) {
        free(dp[i]);
    }
    free(dp);

    return lcs_length;
}

int main() {
    int lengths[] = { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000, 10000 };
    int num_lengths = sizeof(lengths) / sizeof(lengths[0]);

    FILE* file = fopen("results.txt", "w");
    if (file == NULL) {
        printf("Błąd podczas otwierania pliku.\n");
        return 1;
    }

    printf("Długość\tŚr. porównania\n");

    srand(time(NULL)); // Inicjalizacja generatora liczb losowych

    for (int i = 0; i < num_lengths; i++) {
        int length = lengths[i];
        int num_tests = 100;
        int total_comparisons = 0;

        for (int test = 0; test < num_tests; test++) {
            // Alokacja pamięci dla losowo wygenerowanych ciągów
            char* seq1 = (char*)malloc((length + 1) * sizeof(char));
            char* seq2 = (char*)malloc((length + 1) * sizeof(char));

            // Generowanie losowych ciągów do testowania
            for (int j = 0; j < length; j++) {
                seq1[j] = 'A' + rand() % 26;
                seq2[j] = 'A' + rand() % 26;
            }

            seq1[length] = '\0'; // Dodanie znaku końca ciągu
            seq2[length] = '\0';

            int lcs = longest_common_subsequence(seq1, seq2, length, length); // Wywołanie funkcji szukającej LCS
            total_comparisons += lcs;

            free(seq1);
            free(seq2);
        }

        double average_comparisons = (double)total_comparisons / num_tests;

        fprintf(file, "%d,%f\n", length, average_comparisons);
        printf("%d\t%f\n", length, average_comparisons);
    }

    fclose(file);

    return 0;
}

