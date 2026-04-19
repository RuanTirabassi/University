import json
import sys

argvs = sys.argv
arquivo1 = argvs[1]
arquivo2 = argvs[2]

# Abre o arquivo JSON no modo leitura
with open(arquivo1, 'r') as dados:
    arq_json = json.load(dados)

initial_state = arq_json["initial"]
final_states = arq_json["final"]
white = arq_json["white"]
transitions = arq_json["transitions"]

# Abre o arquivo txt no modo leitura e escrita:
with open(arquivo2, 'r+') as txt:
    # Lê o conteúdo do arquivo para uma lista de caracteres
    entrada = list(txt.read().strip())

    # Define a posição inicial da cabeça de leitura
    posicao = 0

    # Loop para percorrer a entrada
    while initial_state not in final_states:
        # Verifica se a posição atual está dentro dos limites da entrada
        if posicao < 0 or posicao >= len(entrada):
            entrada.insert(posicao, white)

        # Obtém o caractere da entrada na posição atual
        caractere_atual = entrada[posicao]

        # Procura por uma transição que corresponda ao estado atual e ao caractere atual
        for transicao in transitions:
            if transicao["from"] == initial_state and transicao["read"] == caractere_atual:
                # Atualiza o estado atual
                initial_state = transicao["to"]

                # Escreve o caractere na fita, se necessário
                if "write" in transicao:
                    entrada[posicao] = transicao["write"]

                # Move a cabeça de leitura para a direção especificada
                if transicao["dir"] == "R":
                    posicao += 1
                elif transicao["dir"] == "L":
                    posicao -= 1

                # Se a cabeça de leitura ultrapassar os limites da entrada, adiciona um caractere em branco
                if posicao == len(entrada):
                    entrada.append(white)
                elif posicao == -1:
                    entrada.insert(0, white)

                # Sai do loop de transições
                break

    # Volta para o início do arquivo e escreve a nova fita no arquivo de entrada
    txt.seek(0)
    txt.truncate()  # Limpa o conteúdo do arquivo
    txt.write(''.join(entrada))

# Verifica se a Máquina de Turing aceita ou rejeita a entrada
if initial_state in final_states:
    print("1")
else:
    print("0")