import json
import sys
import csv
import time

argvs = sys.argv
arquivo1 = argvs[1]
arquivo2 = argvs[2]
arquivo3 = argvs[3]

# Abre o arquivo Json no modo leitura
with open(arquivo1, 'r') as dados:
    arq_json = json.load(dados)

# Lista para armazenar as strings da primeira coluna
entradas = []

# Abre o arquivo csv no modo leitura
with open(arquivo2, "r") as csvfile:
    # Criamos o leitor CSV
    arq_csv = csv.reader(csvfile, delimiter=";")

    # Itera sobre as linhas do arquivo
    for linha in arq_csv:
        # Adiciona a primeira string da coluna à lista
        entradas.append(linha)

# Atrbuimos uma variável para cada especificação do json, assim podendo manipular de maneira mais facíl
initial_state = arq_json["initial"]
final_states = arq_json["final"]
transitions = arq_json["transitions"]

# Abre o arquivo de saída em modo de escrita e escreve o resultado nele, juntamente com as entradas
with open(arquivo3, "w") as saida:
    # Agora, vamos percorrer cada entrada da lista de entradas
    for entrada in entradas:
        # Pega o tempo ao inicio do processo de cada palavra
        tempo_inicial = time.time()

        atual_state = initial_state

        cont = 0
        wrongLetter = False
        # Vamos percorrer cada bloco do transitions no json
        for transition in transitions:

            # Atribui uma variavel para cada especificação do transition
            from_state = transition["from"]
            read_symbol = transition["read"]
            to_state = transition["to"]

            # Faz as comparações das letras do arquivo csv com as espcificações do arquivo json
            if from_state == atual_state:

                if read_symbol == entrada[0][cont]:
                    atual_state = to_state

                    if cont < len(entrada[0]) - 1:
                        cont += 1
                    elif cont == len(entrada[0]) - 1:

                        break
                else:

                    wrongLetter = True
                    break

        # Faz a verificação se aceita(1) ou rejeita(0)
        valorFinal = 0
        for final in final_states:
            if atual_state == final and not wrongLetter:
                valorFinal = 1
        # Pega o tempo ao fim de todo o processo da palavra
        tempo_final = time.time()

        # Escreve a entrada original e o resultado esperado no arquivo de saída
        entrada_str = entrada[0]
        resultado_esperado = entrada[1]

        tempo = f"{tempo_final - tempo_inicial:.5f}"
        saida.write(
            f"{entrada_str};{resultado_esperado};{valorFinal};{tempo}\n")
