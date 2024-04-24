#include <stdio.h>
#include <stdlib.h>
#include <time.h>

struct Stack {
    int data;
    struct Stack* next;
    struct Stack* prev; 
};

void insert(struct Stack** head, int data) {
    struct Stack* newStack = (struct Stack*)malloc(sizeof(struct Stack));
    newStack->data = data;
    newStack->next = NULL;
    newStack->prev = NULL;

    if (*head == NULL) {
        *head = newStack;
        (*head)->next = *head; 
        (*head)->prev = *head; 
        return;
    }

    struct Stack* tail = (*head)->prev; 
    tail->next = newStack;
    newStack->prev = tail;
    newStack->next = *head;
    (*head)->prev = newStack;
}

void printList(struct Stack* head) {
    if (head == NULL) {
        printf("Lista jest pusta.\n");
        return;
    }

    struct Stack* current = head;
    do {
        printf("%d ", current->data);
        current = current->next;
    } while (current != head);

    printf("\n");
}

struct Stack* merge(struct Stack* list1, struct Stack* list2) {
    if (list1 == NULL) {
        return list2;
    }
    if (list2 == NULL) {
        return list1;
    }

    struct Stack* tail1 = list1->prev; 
    struct Stack* tail2 = list2->prev; 
    tail1->next = list2;
    list2->prev = tail1;

    tail2->next = list1;
    list1->prev = tail2;

    return list1;
}

void freeList(struct Stack* head) {
    if (head == NULL) {
        return;
    }

    struct Stack* current = head;
    struct Stack* nextNode;

    do {
        nextNode = current->next;
        free(current);
        current = nextNode;
    } while (current != head);
}

int searchElement(struct Stack* head, int index) {
    if (head == NULL || index < 0) {
        return -1;
    }

    int comparisonsForward = 0;
    int comparisonsBackward = 0;

    int direction = rand() % 2; 
    struct Stack* current;

    if (direction == 0) {
        current = head;
        for (int i = 0; i < index && comparisonsForward <= 2 * index; i++) {
            current = current->next;
            comparisonsForward++;
        }
    } else {
        current = head->prev; 
        for (int i = 0; i < index && comparisonsBackward <= 2 * index; i++) {
            current = current->prev;
            comparisonsBackward++;
        }
    }

    return direction == 0 ? comparisonsForward : comparisonsBackward;
}

int main() {
    printf("Zadanie 3. Valeriia Loichyk - 269399\n");
    struct Stack* list = NULL;
    srand(time(NULL)); 
    for (int i = 0; i < 10000; i++) {
        insert(&list, rand()%100001);
    }

    int totalComparisonsIndex = 0;
    int totalComparisonsRandom = 0;
    int index = 0;
    for (int i = 0; i < 100000; i++) {
        index = 6340;
        totalComparisonsIndex += searchElement(list, index);
    }

    double avgComparisonsIndex = (double)totalComparisonsIndex / 100000;
    printf("Średnia ilość porównań dla wyszukiwania po indeksie %d: %f\n", index, avgComparisonsIndex);

    for (int i = 0; i < 100000; i++) {
        index = rand() % 10000;
        totalComparisonsRandom += searchElement(list, index);
    }

    double avgComparisonsRandom = (double)totalComparisonsRandom / 100000;
    printf("Średnia ilość porównań dla wyszukiwania losowego elementu: %f\n", avgComparisonsRandom);

    struct Stack* list1 = NULL;
    insert(&list1, 18);
    insert(&list1, 12);
    insert(&list1, 11);
    insert(&list1, 14);
    insert(&list1, 19);
    insert(&list1, 20);
    insert(&list1, 23);
    insert(&list1, 28);
    insert(&list1, 26);
    insert(&list1, 29);

    struct Stack* list2 = NULL;
    insert(&list2, 13);
    insert(&list2, 15);
    insert(&list2, 17);
    insert(&list2, 16);
    insert(&list2, 10);
    insert(&list2, 21);
    insert(&list2, 22);
    insert(&list2, 24);
    insert(&list2, 25);
    insert(&list2, 27);

    printf("Listy do łączenia:\n");
    printf("List 1: ");
    printList(list1);
    printf("List 2: ");
    printList(list2);

    struct Stack* mergedList = merge(list1, list2);
    printf("Lista łączona: ");
    printList(mergedList);

    freeList(list);
    freeList(list1);
    freeList(list2);
    freeList(mergedList);

    return 0;
}
