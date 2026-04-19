
# API de Validação de Dados

Esta API foi desenvolvida para realizar validações de dados básicos, como e-mails, números de telefone, CPF e verificação de números positivos.

## Como Usar

A API está acessível através de uma URL com parâmetros `GET`. Cada requisição deve incluir o parâmetro `action` com a operação desejada e os parâmetros necessários para validação (como `email`, `telefone`, `cpf`, `numero`).

### Exemplo de URL:

```
http://atividadeengenharia2.infinityfree.me/API.php?action=validar_email&email=exemplo@dominio.com
```

## Métodos da API

### 1. Validar E-mail
#### **Rota**:
```
/API.php?action=validar_email&email=<email>
```

#### **Parâmetros**:
- `email` (obrigatório): O endereço de e-mail a ser validado.

#### **Exemplo de Requisição**:
```text
GET /API.php?action=validar_email&email=teste@dominio.com
```

#### **Resposta**:

- **Se válido**:
    ```json
    {
      "acao": "validar_email",
      "email": "teste@dominio.com",
      "valido": true,
      "mensagem": "E-mail válido."
    }
    ```

- **Se inválido**:
    ```json
    {
      "acao": "validar_email",
      "email": "teste@dominio.com",
      "valido": false,
      "mensagem": "E-mail inválido."
    }
    ```

---

### 2. Validar Telefone
#### **Rota**:
```
/API.php?action=validar_telefone&telefone=<telefone>
```

#### **Parâmetros**:
- `telefone` (obrigatório): O número de telefone a ser validado.

#### **Exemplo de Requisição**:
```text
GET /API.php?action=validar_telefone&telefone=999999999
```

#### **Resposta**:

- **Se válido**:
    ```json
    {
      "acao": "validar_telefone",
      "telefone": "999999999",
      "valido": true,
      "mensagem": "Número de telefone válido."
    }
    ```

- **Se inválido**:
    ```json
    {
      "acao": "validar_telefone",
      "telefone": "999999999",
      "valido": false,
      "mensagem": "Número de telefone inválido."
    }
    ```

---

### 3. Validar CPF
#### **Rota**:
```
/API.php?action=validar_cpf&cpf=<cpf>
```

#### **Parâmetros**:
- `cpf` (obrigatório): O CPF a ser validado.

#### **Exemplo de Requisição**:
```text
GET /API.php?action=validar_cpf&cpf=12345678909
```

#### **Resposta**:

- **Se válido**:
    ```json
    {
      "acao": "validar_cpf",
      "cpf": "12345678909",
      "valido": true,
      "mensagem": "CPF válido."
    }
    ```

- **Se inválido**:
    ```json
    {
      "acao": "validar_cpf",
      "cpf": "12345678909",
      "valido": false,
      "mensagem": "CPF inválido."
    }
    ```

---

### 4. Verificar Número Positivo
#### **Rota**:
```
/API.php?action=numero_positivo&numero=<numero>
```

#### **Parâmetros**:
- `numero` (obrigatório): O número a ser verificado.

#### **Exemplo de Requisição**:
```text
GET /API.php?action=numero_positivo&numero=5
```

#### **Resposta**:

- **Se o número for positivo**:
    ```json
    {
      "acao": "numero_positivo",
      "numero": "5",
      "valido": true,
      "mensagem": "Número positivo."
    }
    ```

- **Se não for positivo**:
    ```json
    {
      "acao": "numero_positivo",
      "numero": "-5",
      "valido": false,
      "mensagem": "Número não é positivo."
    }
    ```

---

## **Como Testar**

1. **Validar E-mail**:
   - Exemplo de URL para testar:
     ```text
     http://atividadeengenharia2.infinityfree.me/API.php?action=validar_email&email=teste@dominio.com
     ```

2. **Validar Telefone**:
   - Exemplo de URL para testar:
     ```text
     http://atividadeengenharia2.infinityfree.me/API.php?action=validar_telefone&telefone=999999999
     ```

3. **Validar CPF**:
   - Exemplo de URL para testar:
     ```text
     http://atividadeengenharia2.infinityfree.me/API.php?action=validar_cpf&cpf=12345678909
     ```

4. **Verificar Número Positivo**:
   - Exemplo de URL para testar:
     ```text
     http://atividadeengenharia2.infinityfree.me/API.php?action=numero_positivo&numero=5
     ```

---

## **O que Não Fazer para Evitar Erros**

### **1. Não informar os parâmetros obrigatórios**

Se você não informar um parâmetro obrigatório, a API retornará um erro. Por exemplo:
- Não informar o parâmetro **`email`** em uma requisição para validar e-mail resultará em:
  ```
  Erro: Parâmetro 'email' é obrigatório e não pode estar vazio.
  ```

### **2. Passar valores vazios**

Certifique-se de que o valor do parâmetro **não seja vazio**. Por exemplo, se você passar um valor vazio para o CPF, telefone ou e-mail, a API retornará um erro de falta de valor.

### **3. Passar valores no formato errado**

A API possui validações de formato para **e-mails**, **telefones** e **CPFs**. Se os dados enviados não estiverem no formato esperado, a resposta será:

- **E-mail inválido** se o e-mail não tiver o formato adequado.
- **Telefone inválido** se o telefone não for composto apenas por 9 dígitos.
- **CPF inválido** se o CPF não seguir o formato de 11 números.

Por exemplo:
```
http://atividadeengenharia2.infinityfree.me/API.php?action=validar_email&email=teste@dominio
```
Resposta:
```json
{
  "acao": "validar_email",
  "email": "teste@dominio",
  "valido": false,
  "mensagem": "E-mail inválido."
}
```
