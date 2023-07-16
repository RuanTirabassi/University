#include <stdio.h>

int main(){

    int h, m, s;

    printf("digite as horas, os minutos e os segundos:\n");
    scanf("%i%i%i", &h, &m,&s);

    Calc_seg(h,m,s);

return 0;
}

void Calc_seg(int h, int m, int s){

    int calc;

    calc = (h * 3600) + (m * 60) + s;

    printf("%i:%i:%i tem %i segundos", h, m, s, calc);

}
