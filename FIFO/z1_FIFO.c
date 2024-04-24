//Valeriia Loichyk - 269399

#include <stdio.h>
#include <stdlib.h>
#define MAX_SIZE 50

typedef struct {
    int data[MAX_SIZE];
    int front, rear;
} Queue;

Queue* create() {
    Queue* q = (Queue*)malloc(sizeof(Queue));
    q->front = q->rear = -1;
    return q;
}

int isFull(Queue* q) {
    return q->rear == MAX_SIZE - 1;
}

int isEmpty(Queue* q) {
    return q->front == -1;
}

void enqueue(Queue* q, int x) {
    if (isFull(q)) {
        printf("Queue is full\n");
        return;
    }
    if (isEmpty(q)) {
        q->front = q->rear = 0;
    } else {
        q->rear++;
    }
    printf("Insert element: %d\n", q->data[q->rear] = x);
}

int dequeue(Queue* q) {
    if (isEmpty(q)) {
        printf("Queue is empty\n");
        return -1;
    }
    int x = q->data[q->front];
    if (q->front == q->rear) {
        q->front = q->rear = -1;
    } else {
        q->front++;
    }
    printf("Delete element: %d\n", x);
    return x;
}

int main() {
    printf("Zadanie 1 FIFO. Valeriia Loichyk - 269399\n");
    printf("FIFO QUEUE\n");
    Queue* q = create();
    printf("INSERTING\n");
    for (int i = 0; i < MAX_SIZE; i++)
        enqueue(q, i);

    printf("\n\nDELETING\n");
    for (int i = 0; i < MAX_SIZE; i++)
        dequeue(q);

    free(q);
    return 0;
}
