#include <stdio.h>

int main(){

    int x, n;

    printf("digite um numero para 'x':\n");
    scanf("%i", &x);

    printf("digite um numero para 'n':\n");
    scanf("%i", &n);

    Calc_potencia(x, n);

return 0;
}

void Calc_potencia(int x, int n){

    int resultado = x;

    for(int i = 1; i < n; i++){

        resultado = resultado * x;
    }

    printf("\n\nresultado: %i\n", resultado);


}
