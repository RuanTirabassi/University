#include <stdio.h>

float Calcmedia(float n1, float n2, char op){

    float media;

    switch (op){
    case 'a':
        media = (n1 + n2)/2;
        break;

    case 'p':
        media = (n1 * 3 + n2 * 2)/5;
        break;

    case 'h':
        media = ((1/n1)+ (1/n2))/2;
        break;

    }
    return media;
}

int main(){

    float n1, n2, media;
    char op;

    printf("digite a primeira nota:\n");
    scanf("%f", &n1);

    printf("\ndigite a segunda nota:\n");
    scanf("%f", &n2);

    printf("qual opcao de media voce quer:\nmedia aritimetica: 'a'\nmedia ponderada: 'p'\nmedia harmonica: 'h'\n");
    scanf("%s", &op);

    media = Calcmedia(n1, n2, op);

    printf("\n media = %.2f\n", media);

return 0;
}

