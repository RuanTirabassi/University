# Simulador de Máquina de Turing

## Funcionamento
<p>O autômato recebe uma entrada e um arquivo json com a transições e como a máquina deverá se comportar,
  a partir disso, a máquina faz a leitura da entrada e os caracteres que estão dentro dela para
fazer as transições e mudanças de estado. Ao final ele escreve 1 ou 0 no terminal de comando para aceitar
ou rejeita.</p>

## Execução da ferramenta
<p>A execução da ferramenta acontece a partir da linha de comando, para executar sera necessário utilizar o seguinte comando:</p>

    $ python Turing.py duplo_bal.json duplobal.in.txt 

<p>Ou utilizar os nomes dos seus arquivos, por exemplo:</p>

    $ python Turing.py seu_arquivo.json seu_arquivo.txt

<p> E caso não queira utilizar a linha de comando é só apagar ou comentar a linha 4,5 e 6 do código e colocar os arquivos que deseja abrir direto no código, como por exemplo:</p>

    # Abre o arquivo JSON no modo leitura
    with open('seu_aquivo.json', 'r') as dados:
    arq_json = json.load(dados)

    # Abre o arquivo txt no modo leitura e escrita:
    with open('seu_arquivo.txt', 'r+') as txt:

