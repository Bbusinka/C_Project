#include <math.h>
#include <stdlib.h>

// Процедура для считывания файла и подсчета частоты символов
void calculateSymbolCount(const char* filename, long symbol_count[256], long* total_symbols) {
    FILE* file = fopen(filename, "rb");

    if (file == NULL) {
        perror("Error opening the file");
        exit(1);
    }

    int c;
    while ((c = fgetc(file)) != EOF) {
        symbol_count[c]++;
        (*total_symbols)++;
    }

    fclose(file);
}

// Процедура для расчета энтропии
double calculateEntropy(long symbol_count[256], long total_symbols) {
    double entropy = 0.0;

    for (int i = 0; i < 256; i++) {
        if (symbol_count[i] > 0) {
            double p = (double)symbol_count[i] / total_symbols;
            entropy -= p * log2(p);
        }
    }

    return entropy;
}

// Процедура для расчета условной энтропии
double calculateConditionalEntropy(const char* filename) {
    long symbol_count[256] = {0};
    long conditional_count[256][256] = {0};
    long total_symbols = 0;

    calculateSymbolCount(filename, symbol_count, &total_symbols);

    FILE* file = fopen(filename, "rb");

    if (file == NULL) {
        perror("Error opening the file");
        exit(1);
    }

    unsigned char current_symbol = 0;
    unsigned char previous_symbol = 0;

    while (fread(&current_symbol, 1, 1, file) == 1) {
        conditional_count[previous_symbol][current_symbol]++;
        previous_symbol = current_symbol;
    }

    fclose(file);

    double conditional_entropy = 0.0;

    for (int i = 0; i < 256; i++) {
        for (int j = 0; j < 256; j++) {
            if (conditional_count[i][j] > 0) {
        double p = (double)conditional_count[i][j] / total_symbols;
               conditional_entropy -= p * (log2(p));
    }
        }
    }

    return conditional_entropy;
}

int main(int argc, char* argv[]) {
    if (argc != 2) {
        printf("Usage: %s <file_path>\n", argv[0]);
        return 1;
    }

    const char* filename = argv[1];
    long symbol_count[256] = {0};
    long total_symbols = 0;

    calculateSymbolCount(filename, symbol_count, &total_symbols);

    double entropy = calculateEntropy(symbol_count, total_symbols);

    double conditional_entropy = calculateConditionalEntropy(filename);

    printf("Entropy: %lf\n", entropy);
    printf("Conditional Entropy: %lf\n", conditional_entropy);
    printf("Difference: %lf\n", fabs(fabs(entropy) - fabs(conditional_entropy)));

    return 0;
}