#include <stdio.h>

int main(){

    char c;

    printf("digite qualquer letra:\n");
    scanf("%c", &c);

    Verificar(c);
}

void Verificar(char c){

    if(c == 'a'|| c == 'e'|| c == 'i'|| c == 'o'|| c == 'u'){
        printf("Vogal!!");
    }
    else{
        printf("Consoante!!");
    }
}
