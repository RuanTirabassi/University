#include <stdio.h>

int main(){

    int n;

    printf("digite um numero:\n");
    scanf("%i", &n);

    Verificar(n);

return 0;
}

void Verificar(int n){

    int cont;

    for(int i = 1; i <= n; i++){
        if(n % i == 0){
            cont++;
        }
    }

         if(cont == 2){
        printf("\nEh um numero primo\n");
    }
    else{
        printf("\nNao eh um numero primo\n");
    }
}
