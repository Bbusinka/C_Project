#include <stdio.h>
#include <stdlib.h>
#include <math.h>

// Struktura przechowująca analizę pliku.
typedef struct FileAnalysis
{
    FILE *file;                  // Uchwyt do pliku.
    char *filePath;              // Ścieżka do pliku.
    int possibleCharactersCount; // Maksymalna liczba możliwych znaków.
    int countOne[256];           // Liczba wystąpień pojedynczych znaków.
    int countTwo[256][256];      // Liczba wystąpień par znaków.
    int totalCount;              // Całkowita liczba znaków w pliku.
} FileAnalysis;

// Funkcja inicjalizująca strukturę FileAnalysis na podstawie ścieżki do pliku.
void init(FileAnalysis *fa, char *filePath)
{
    fa->file = fopen(filePath, "r"); // Otwiera plik w trybie do odczytu.

    unsigned char current = 0;
    unsigned char previous = 0;
    while (!feof(fa->file))
    {
        fa->countOne[current]++;           // Zlicza wystąpienia pojedynczych znaków.
        fa->countTwo[previous][current]++; // Zlicza wystąpienia par znaków.

        // Pobiera następny znak.
        previous = current;
        current = fgetc(fa->file);

        fa->totalCount++; // Zwiększa licznik ogólnej liczby znaków.
    }
}

// Funkcja tworząca strukturę FileAnalysis na podstawie ścieżki do pliku.
FileAnalysis *createFileAnalysis(char *filePath)
{
    int i, j;
    FileAnalysis *fa = (FileAnalysis *)malloc(sizeof(FileAnalysis)); // Alokacja pamięci dla struktury FileAnalysis.
    if (fa == NULL)
    {
        perror("Error in memory allocation"); // Wyświetla komunikat błędu, jeśli wystąpi problem z alokacją pamięci.
        exit(EXIT_FAILURE);                   // Kończy program z błędem.
    }

    fa->filePath = filePath; // Przypisuje ścieżkę pliku.
    fa->possibleCharactersCount = 256;

    // Wyzerowanie liczników countOne i countTwo.
    for (i = 0; i < 256; i++)
    {
        fa->countOne[i] = 0;
        for (j = 0; j < 256; j++)
        {
            fa->countTwo[i][j] = 0;
        }
    }

    init(fa, filePath); // Inicjalizuje strukturę.
    return fa;
}

// Funkcje obliczające różne wskaźniki analizy pliku tekstowego.
// ...

// Funkcja obliczająca entropię na podstawie struktury FileAnalysis.
double Entropy(FileAnalysis *fa)
{
    double output = 0.0;
    int count = 0;
    int x;
    for (x = 0; x < fa->possibleCharactersCount; x++)
    {
        if (fa->countOne[x])
        {
            output += -1.0 * log2(fa->countOne[x]) * fa->countOne[x];
            count++;
        }
    }

    output /= fa->totalCount;

    return output + log2(fa->totalCount);
}

// Funkcja obliczająca entropię warunkową na podstawie struktury FileAnalysis.
double ConditionalEntropy(FileAnalysis *fa)
{
    double output = 0.0;
    int x, y;
    for (x = 0; x < fa->possibleCharactersCount; x++)
    {
        for (y = 0; y < fa->possibleCharactersCount; y++)
        {
            if (fa->countOne[x] && fa->countTwo[x][y])
                output += 1.0 * fa->countTwo[x][y] / fa->totalCount * (-1 * log2(fa->countTwo[x][y]) + log2(fa->countOne[x]));
        }
    }
    return output;
}

// Funkcja wyświetlająca wyniki analizy pliku na podstawie struktury FileAnalysis.
void printResults(FileAnalysis *fa)
{
    double e = Entropy(fa);
    double ce = ConditionalEntropy(fa);

    printf("%s\n", fa->filePath);
    printf("  Entropy:               %lf\n", e);
    printf("  Conditional entropy:   %lf\n", ce);
    printf("  Difference:            %lf\n", e - ce);
}

// Funkcja zwalniająca zasoby związane z analizą pliku tekstowego.
void destroyFileAnalysis(FileAnalysis *fa)
{
    fclose(fa->file); // Zamyka plik.
    free(fa);         // Zwalnia pamięć zarezerwowaną dla struktury.
}

// Główna funkcja programu.
int main(int argc, const char *argv[])
{
    // Sprawdza, czy podano ścieżkę do pliku jako argument wiersza poleceń.
    if (argc < 2)
    {
        printf("usage: ./main.out <input_file_path>\n");
        return 0;
    }

    // Pobiera ścieżkę do pliku z argumentu wiersza poleceń.
    char *inputFilePath = (char *)argv[1];

    // Tworzy instancję FileAnalysis na podstawie podanej ścieżki.
    FileAnalysis *fa = createFileAnalysis(inputFilePath);

    // Wyświetla wyniki analizy.
    printResults(fa);

    // Zwalnia zasoby związane z analizą pliku.
    destroyFileAnalysis(fa);

    return 0;
}
