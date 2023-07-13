#include <stdio.h>

int main(){

    int n;

    printf("calcular a area de quantos terrenos: \n");
    scanf("%i", &n);

    Calc_area(n);

return 0;
}

void Calc_area(int n){
    float c, l, area;

    for(int i = 0; i < n; i++){
        printf("\ndigite o comprimento do terreno %i:\n", i+1);
        scanf("%f", &c);
        printf("\ndigite a largura do terreno %i:\n", i+1);
        scanf("%f", &l);

        area = c*l;

        printf("\na area do terreno %i eh: %.2f\n\n", i+1, area);
    }


}
