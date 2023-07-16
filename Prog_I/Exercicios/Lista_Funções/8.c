#include <stdio.h>
void Calc(int n){

    int cont;

        printf("os divisores de %i sao: \n", n);

    for(int i = 1; i <= n; i++){
        if(n % i == 0){
            printf("%i\n", i);
            cont ++;
        }
    }
    printf("\n%i tem %i divisores", n, cont);
}

int main(){

    int n;

    printf("digite um numero inteiro:\n");
    scanf("%i", &n);

    Calc(n);

return 0;
}
