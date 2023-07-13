#include <stdio.h>

float Calc(float altura, float kg){

    float IMC;

    IMC = kg/(altura * altura);

    return IMC;
}

void TabelaIMC(float imc){

    if(imc < 18.5){
        printf("\nAbaixo do peso");
    }
    else if(18.5 <= imc <= 24.9){
        printf("\nPeso normal");
    }
    else if(25 <= imc <= 29.9){
        printf("\nSobre peso");
    }
    else{
        printf("\nObeso");
    }
}
int main(void){

    float peso, altura, IMC;

    printf("digite sua altura em metros:\n");
    scanf("%f", &altura);

    printf("digite quanto voce pesa em Kg:\n");
    scanf("%f", &peso);

    IMC = Calc(altura, peso);

    printf("\nIMC: %.2f\n", IMC);

    TabelaIMC(IMC);
}
