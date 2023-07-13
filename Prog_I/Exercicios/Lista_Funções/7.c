#include<stdio.h>

int main(void){

    int x;

    printf("de um valor a 'x':\n");
    scanf("%i", &x);

    Tabuada(x);
}

void Tabuada(int x){

    int r;

    printf("Tabuada do %i:\n", x);

    for(int i = 1; i <= 10; i++){

       printf("%i x %i = %i\n", x, i, x*i);
    }
}
