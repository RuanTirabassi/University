# Trabalho de Compiladores

Este repositório contém um interpretador desenvolvido em **C# (SDK 9)**, utilizando **ANTLR** para gerar código a partir da gramática definida no arquivo `.g4`.

## Estrutura do Projeto

O projeto está dividido nas seguintes partes dentro da pasta `Lang`:

### 1. Preprocessador
- Substitui `#include` pelo conteúdo das bibliotecas referenciadas.
- Substitui as referências a `#define` pelos respectivos valores.

### 2. Listener
- Realiza a análise semântica do código.
- Garante que variáveis inteiras tenham valores válidos.
- Detecta erros como declaração de variáveis duplicadas.
- Utiliza `LangErrorListener` para gerenciar erros semânticos.

### 3. Visitor
- Percorre a árvore sintática e executa as ações correspondentes.
- No caso de um comando `print`, exibe o valor na tela.

## Como Executar o Interpretador

1. Insira o código a ser interpretado no arquivo `input.txt`.
2. No diretório do projeto, execute o seguinte comando:
   ```sh
   dotnet run
   ```

## Dependências
- [.NET SDK 9](https://dotnet.microsoft.com/en-us/download)
- [ANTLR](https://www.antlr.org/)

## Autor
Este projeto foi desenvolvido para a disciplina de Compiladores.

