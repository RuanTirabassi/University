<?php
// Define que a resposta será em HTML (visualização do JSON)
header('Content-Type: text/html; charset=utf-8');

// Lê a ação (método) que o usuário quer executar
$action = isset($_GET['action']) ? $_GET['action'] : null;

// Função para enviar resposta HTML exibindo exatamente a resposta da "API" (array -> JSON)
function send_html_response(array $response)
{
    // JSON que representa a resposta da API
    $json = json_encode($response, JSON_UNESCAPED_UNICODE | JSON_PRETTY_PRINT);

    // Classes de status para estilizar (baseado em 'valido', se existir)
    $statusClass = '';
    if (isset($response['valido'])) {
        if ($response['valido'] === true) {
            $statusClass = 'valid';
        } elseif ($response['valido'] === false) {
            $statusClass = 'invalid';
        }
    }

    // Escapar JSON para exibir em HTML
    $jsonEscaped = htmlspecialchars($json, ENT_QUOTES, 'UTF-8');

    echo "
    <html lang='pt-BR'>
    <head>
        <meta charset='UTF-8'>
        <meta name='viewport' content='width=device-width, initial-scale=1.0'>
        <title>Resultado da Validação</title>
        <style>
            body {
                font-family: Arial, sans-serif;
                background-color: #f4f4f9;
                color: #333;
                margin: 20px;
                padding: 20px;
            }
            .container {
                background-color: #fff;
                border-radius: 8px;
                padding: 20px;
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            }
            h1 {
                color: #4CAF50;
            }
            .result {
                font-size: 1em;
                margin-top: 10px;
            }
            .valid {
                color: green;
                font-weight: bold;
            }
            .invalid {
                color: red;
                font-weight: bold;
            }
            .response-block {
                margin-bottom: 10px;
                padding: 8px;
                background-color: #f9f9f9;
                border: 1px solid #ddd;
                border-radius: 5px;
            }
            .response-block span.key {
                font-weight: bold;
            }
            pre {
                background-color: #272822;
                color: #f8f8f2;
                padding: 15px;
                border-radius: 5px;
                overflow-x: auto;
                font-size: 0.9em;
            }
            .status-label {
                margin-top: 10px;
            }
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Resultado da Validação</h1>

            <div class='result'>
    ";

    // Exibe cada campo da resposta (EXATAMENTE o que está na resposta da API)
    foreach ($response as $key => $value) {
        // Converte boolean para 'true' / 'false' para ficar mais claro
        if (is_bool($value)) {
            $displayValue = $value ? 'true' : 'false';
        } else {
            $displayValue = $value;
        }

        // Aplica classe de status se for o campo 'valido'
        $extraClass = ($key === 'valido') ? " $statusClass" : '';

        echo "
                <div class='response-block$extraClass'>
                    <span class='key'>{$key}:</span> " . htmlspecialchars((string)$displayValue, ENT_QUOTES, 'UTF-8') . "
                </div>
        ";
    }

    echo "
            </div>

            <h2>JSON da Resposta da API</h2>
            <pre>{$jsonEscaped}</pre>
        </div>
    </body>
    </html>
    ";
    exit;
}

// -------------------------
// Tratamento quando nenhuma ação foi informada
// -------------------------
if ($action === null) {
    $response = [
        'acao'     => null,
        'valido'   => false,
        'mensagem' => "Nenhuma ação informada. Use o parâmetro 'action' (validar_email, validar_telefone, validar_cpf, numero_positivo)."
    ];
    send_html_response($response);
}

switch ($action) {
    // -------------------------
    // 1) VALIDAR E-MAIL
    // Exemplo: api.php?action=validar_email&email=exemplo@dominio.com
    // -------------------------
    case 'validar_email':
        if (!isset($_GET['email']) || $_GET['email'] === '') {
            $response = [
                'acao'     => 'validar_email',
                'email'    => null,
                'valido'   => false,
                'mensagem' => "Parâmetro 'email' é obrigatório e não pode estar vazio."
            ];
            send_html_response($response);
        }

        $email  = $_GET['email'];
        $valido = filter_var($email, FILTER_VALIDATE_EMAIL) !== false;

        $response = [
            'acao'     => 'validar_email',
            'email'    => $email,
            'valido'   => $valido,
            'mensagem' => $valido ? 'E-mail válido.' : 'E-mail inválido.'
        ];
        send_html_response($response);
        break;

    // -------------------------
    // 2) VALIDAR NÚMERO DE TELEFONE
    // Exemplo: api.php?action=validar_telefone&telefone=999999999
    // -------------------------
    case 'validar_telefone':
        if (!isset($_GET['telefone']) || $_GET['telefone'] === '') {
            $response = [
                'acao'     => 'validar_telefone',
                'telefone' => null,
                'valido'   => false,
                'mensagem' => "Parâmetro 'telefone' é obrigatório e não pode estar vazio."
            ];
            send_html_response($response);
        }

        $telefone = $_GET['telefone'];
        // Valida o telefone (9 dígitos numéricos)
        $valido = preg_match("/^[0-9]{9}$/", $telefone) === 1;

        $response = [
            'acao'     => 'validar_telefone',
            'telefone' => $telefone,
            'valido'   => $valido,
            'mensagem' => $valido ? 'Número de telefone válido.' : 'Número de telefone inválido.'
        ];
        send_html_response($response);
        break;

    // -------------------------
    // 3) VALIDAR CPF
    // Exemplo: api.php?action=validar_cpf&cpf=12345678909
    // -------------------------
    case 'validar_cpf':
        if (!isset($_GET['cpf']) || $_GET['cpf'] === '') {
            $response = [
                'acao'     => 'validar_cpf',
                'cpf'      => null,
                'valido'   => false,
                'mensagem' => "Parâmetro 'cpf' é obrigatório e não pode estar vazio."
            ];
            send_html_response($response);
        }

        $cpf = $_GET['cpf'];
        // Validação simplificada: apenas 11 dígitos numéricos
        $valido = preg_match("/^\d{11}$/", $cpf) === 1;

        $response = [
            'acao'     => 'validar_cpf',
            'cpf'      => $cpf,
            'valido'   => $valido,
            'mensagem' => $valido ? 'CPF válido.' : 'CPF inválido.'
        ];
        send_html_response($response);
        break;

    // -------------------------
    // 4) VERIFICAR NÚMERO POSITIVO
    // Exemplo: api.php?action=numero_positivo&numero=5
    // -------------------------
    case 'numero_positivo':
        if (!isset($_GET['numero']) || $_GET['numero'] === '') {
            $response = [
                'acao'     => 'numero_positivo',
                'numero'   => null,
                'valido'   => false,
                'mensagem' => "Parâmetro 'numero' é obrigatório e não pode estar vazio."
            ];
            send_html_response($response);
        }

        $numero = $_GET['numero'];

        if (!is_numeric($numero)) {
            $response = [
                'acao'     => 'numero_positivo',
                'numero'   => $numero,
                'valido'   => false,
                'mensagem' => "Parâmetro 'numero' deve ser numérico."
            ];
            send_html_response($response);
        }

        $valido = $numero > 0;

        $response = [
            'acao'     => 'numero_positivo',
            'numero'   => $numero,
            'valido'   => $valido,
            'mensagem' => $valido ? 'Número positivo.' : 'Número não é positivo.'
        ];
        send_html_response($response);
        break;

    // -------------------------
    // AÇÃO DESCONHECIDA
    // -------------------------
    default:
        $response = [
            'acao'     => $action,
            'valido'   => false,
            'mensagem' => "Ação inválida. Use uma das seguintes: validar_email, validar_telefone, validar_cpf, numero_positivo."
        ];
        send_html_response($response);
}
