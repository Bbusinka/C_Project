#include <stdio.h>
#include <stdlib.h>
#include <time.h>

struct node {
    struct node* left;
    struct node* right;
    int element;
};

struct node* root = NULL;

// Funkcja wstawiająca węzeł do drzewa BST
void insert(struct node** root, struct node* node_ptr) {
    if (node_ptr == NULL)
        return;

    // Jeśli drzewo jest puste, węzeł staje się korzeniem
    if (*root == NULL) {
        *root = node_ptr;
    }
    // Jeśli element jest mniejszy od korzenia, rekurencyjnie wstaw go do lewego poddrzewa
    else if (node_ptr->element < (*root)->element) {
        insert(&(*root)->left, node_ptr);
    }
    // Jeśli element jest większy od korzenia, rekurencyjnie wstaw go do prawego poddrzewa
    else if (node_ptr->element > (*root)->element) {
        insert(&(*root)->right, node_ptr);
    }
    // Jeśli element już istnieje w drzewie, nie wstawiaj go ponownie
    else {
        free(node_ptr); // Zwolnij pamięć zaalokowaną dla zduplikowanego węzła
        return;
    }
}


// Funkcja zwalniająca pamięć zaalokowaną dla poddrzewa o korzeniu w danym węźle
void free_subtree(struct node** root) {
    if (*root == NULL)
        return;
    
    // Rekurencyjnie zwalniaj lewe poddrzewo
    if ((*root)->left != NULL) {
        free_subtree(&(*root)->left);
    }
    
    // Rekurencyjnie zwalniaj prawe poddrzewo
    if ((*root)->right != NULL) {
        free_subtree(&(*root)->right);
    }
    
    // Zwolnij bieżący węzeł i ustaw go na NULL
    free(*root);
    *root = NULL;
}

void print_BST(struct node* root, int depth, char prefix) {
    if (root == NULL)
        return;

    static char left_trace[100]; // Tablica do śledzenia lewych gałęzi
    static char right_trace[100]; // Tablica do śledzenia prawych gałęzi

    if (root->left != NULL) {
        print_BST(root->left, depth + 1, '/');
    }
    if (prefix == '/')
        left_trace[depth - 1] = '|';
    if (prefix == '\\')
        right_trace[depth - 1] = ' ';
    if (depth == 0)
        printf("-");
    if (depth > 0)
        printf(" ");
    for (int i = 0; i < depth - 1; i++)
        if (left_trace[i] == '|' || right_trace[i] == '|') {
            printf("| ");
        } else {
            printf("  ");
        }
    if (depth > 0)
        printf("%c-", prefix);
    printf("[%d]\n", root->element);
    left_trace[depth] = ' ';
    if (root->right != NULL) {
        right_trace[depth] = '|';
        print_BST(root->right, depth + 1, '\\');
    }
}

// Funkcja usuwająca węzeł o podanym kluczu z drzewa BST
struct node* delete(struct node* root, int key) {
    if (root == NULL) {
        return root;
    }

    if (key < root->element) {
        root->left = delete(root->left, key);
    } else if (key > root->element) {
        root->right = delete(root->right, key);
    } else {
        // Węzeł do usunięcia nie ma żadnego dziecka lub ma tylko jedno dziecko
        if (root->left == NULL) {
            struct node* temp = root->right;
            free(root);
            return temp;
        } else if (root->right == NULL) {
            struct node* temp = root->left;
            free(root);
            return temp;
        }

        // Węzeł do usunięcia ma dwoje dzieci
        struct node* temp = root->right;
        while (temp->left != NULL) {
            temp = temp->left;
        }

        // Zamień element węzła z najmniejszym elementem w jego prawym poddrzewie
        root->element = temp->element;

        // Usuń najmniejszy element z prawego poddrzewa
        root->right = delete(root->right, temp->element);
    }

    return root;
}

// Funkcja obliczająca wysokość drzewa BST
int height(struct node* root) {
    if (root == NULL) {
        return 0;
    }

    int leftHeight = height(root->left);
    int rightHeight = height(root->right);

    return (leftHeight > rightHeight) ? (leftHeight + 1) : (rightHeight + 1);
}

int main() {
    srand(time(NULL));

    int size = 50;
  
printf("\n");

// Wstaw więcej węzłów do drzewa BST
    for (int i = 0; i < size/2; i++) {
        struct node* node_ptr = malloc(sizeof(struct node));
        node_ptr->element = rand() % (2 * size);
        node_ptr->left = NULL;
        node_ptr->right = NULL;
        insert(&root, node_ptr);
    }
    
        printf("DRZEWO:\n");
        print_BST(root, 0, '-');
        printf("\n\n");
        // Wypisz wysokość drzewa BST
        printf("WYSOKOŚĆ DRZEWA: %d\n\n", height(root));

    // Wstaw węzły do drzewa BST
    for (int i = 0; i < size; i++) {
        struct node* node_ptr = malloc(sizeof(struct node));
        node_ptr->element = i;
        node_ptr->left = NULL;
        node_ptr->right = NULL;
        printf("WSTAW: [%d]\n", node_ptr->element);
        insert(&root, node_ptr);
        printf("DRZEWO:\n");
        print_BST(root, 0, '-');
        printf("\n\n");
        // Wypisz wysokość drzewa BST
        printf("WYSOKOŚĆ DRZEWA: %d\n\n", height(root));
    }
    

    // Usuń losowy węzeł z drzewa BST
    for (int i = 0; i < size; i++) {
        int index_to_delete = rand() % size;
        printf("USUŃ: [%d]\n", index_to_delete);
        root = delete(root, index_to_delete);
        printf("DRZEWO:\n");
        print_BST(root, 0, '-');
        printf("\n\n");
        // Wypisz wysokość drzewa BST
        printf("WYSOKOŚĆ DRZEWA: %d\n\n", height(root));
    }

    // Wstaw więcej węzłów do drzewa BST
    for (int i = 0; i < size; i++) {
        struct node* node_ptr = malloc(sizeof(struct node));
        node_ptr->element = rand() % (2 * size);
        node_ptr->left = NULL;
        node_ptr->right = NULL;
        printf("WSTAW: [%d]\n\n", node_ptr->element);
        insert(&root, node_ptr);
        printf("DRZEWO:\n");
        print_BST(root, 0, '-');
        printf("\n\n");
        // Wypisz wysokość drzewa BST
        printf("WYSOKOŚĆ DRZEWA: %d\n\n", height(root));
    }

    // Usuń losowy węzeł z drzewa BST
    for (int i = 0; i < size; i++) {
        int index_to_delete = rand() % size;
        printf("USUŃ: [%d]\n", index_to_delete);
        root = delete(root, index_to_delete);
        printf("DRZEWO:\n");
        print_BST(root, 0, '-');
        printf("\n\n");
        // Wypisz wysokość drzewa BST
        printf("WYSOKOŚĆ DRZEWA: %d\n\n", height(root));
    }


    // Zwolnij pamięć zaalokowaną dla drzewa BST
    free_subtree(&root);
    return 0;
}
