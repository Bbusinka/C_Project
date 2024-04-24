//Valeriia Loichyk - 269399

#include <stdio.h>
#include <stdlib.h>
#define MAX_SIZE 50

typedef struct {
    int data[MAX_SIZE];
    int top;
} Stack;

Stack* create() {
    Stack* s = (Stack*)malloc(sizeof(Stack));
    s->top = -1;
    return s;
}

int isFull(Stack* s) {
    return s->top == MAX_SIZE - 1;
}

int isEmpty(Stack* s) {
    return s->top == -1;
}

void push(Stack* s, int x) {
    if (isFull(s)) {
        printf("Stack is full\n");
        return;
    }
    s->data[++s->top] = x;
    printf("Insert element: %d\n", x);
}

int pop(Stack* s) {
    if (isEmpty(s)) {
        printf("Stack is empty\n");
        return -1;
    }
    printf("Delete element: %d\n", s->data[s->top--]);
}

int main() {
    printf("Zadanie 1 LIFO. Valeriia Loichyk - 269399\n");
    printf("LIFO STACK\n");
    Stack* s = create();
    printf("INSERTING\n");
    for (int i = 0; i < MAX_SIZE; i++)
        push(s, i);

    printf("\n\nDELETING\n");
    for (int i = 0; i < MAX_SIZE; i++)
        pop(s);

    free(s);
    return 0;
}
