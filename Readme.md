# API de Disciplinas

API REST simples feita com **ASP.NET Core (Minimal API)** para gerenciar disciplinas. Projeto criado para fins de estudo na disciplina de Desenvolvimento de Software Visual.

Os dados ficam armazenados **em memória** (em uma `List<Disciplina>`), portanto são perdidos sempre que a aplicação é reiniciada.

## Tecnologias

- C#
- .NET (ASP.NET Core Minimal API)
- Swagger / OpenAPI (Swashbuckle)

## Pré-requisitos

- [SDK do .NET](https://dotnet.microsoft.com/download) instalado (versão compatível com o projeto)

## Como executar

```bash
# Clonar o repositório
git clone <url-do-repositorio>
cd <pasta-do-projeto>

# Executar a aplicação
dotnet run
```

Ao iniciar, o terminal mostra a URL da API (por exemplo, `https://localhost:7000`). Em ambiente de desenvolvimento, a documentação interativa do Swagger fica disponível em:

```
https://localhost:<porta>/swagger
```

## Modelo

### Disciplina

| Campo            | Tipo   | Descrição                                           |
|------------------|--------|-----------------------------------------------------|
| `id`             | int    | Gerado automaticamente pelo servidor (sequencial)   |
| `nomeDisciplina` | string | Nome da disciplina                                  |
| `cargaHoraria`   | int    | Carga horária em horas                              |

```json
{
  "id": 1,
  "nomeDisciplina": "DSV",
  "cargaHoraria": 80
}
```

## Endpoints

| Método | Rota                | Descrição                              | Respostas            |
|--------|---------------------|----------------------------------------|----------------------|
| GET    | `/disciplinas`      | Lista todas as disciplinas             | 200                  |
| GET    | `/disciplinas/{id}` | Retorna uma disciplina pelo ID         | 200, 404             |
| POST   | `/disciplinas`      | Cadastra uma nova disciplina           | 201                  |
| PUT    | `/disciplinas/{id}` | Atualiza uma disciplina pelo ID        | 200, 404             |

### Exemplos

**Listar disciplinas**

```http
GET /disciplinas
```

```json
[
  { "id": 1, "nomeDisciplina": "DSV", "cargaHoraria": 80 },
  { "id": 2, "nomeDisciplina": "BD", "cargaHoraria": 60 },
  { "id": 3, "nomeDisciplina": "Redes", "cargaHoraria": 45 },
  { "id": 4, "nomeDisciplina": "ES", "cargaHoraria": 120 }
]
```

**Buscar por ID**

```http
GET /disciplinas/1
```

Retorna `404 Not Found` caso a disciplina não exista.

**Cadastrar disciplina**

```http
POST /disciplinas
Content-Type: application/json

{
  "nomeDisciplina": "Estrutura de Dados",
  "cargaHoraria": 80
}
```

Resposta `201 Created`:

```json
{
  "id": 5,
  "nomeDisciplina": "Estrutura de Dados",
  "cargaHoraria": 80
}
```

**Atualizar disciplina**

```http
PUT /disciplinas/1
Content-Type: application/json

{
  "nomeDisciplina": "Desenvolvimento de Software Visual",
  "cargaHoraria": 100
}
```

Retorna `200 OK` com a disciplina atualizada, ou `404 Not Found` caso o ID não exista.

## Dados iniciais

Ao iniciar, a API já carrega quatro disciplinas de exemplo: DSV, BD, Redes e ES.

## Observações

- O `id` é gerado pelo servidor e não pode ser definido pelo cliente.
- Não há banco de dados: os dados existem apenas enquanto a aplicação está rodando.

## Possíveis melhorias

- Endpoint `DELETE /disciplinas/{id}`
- Validação dos dados de entrada (nome obrigatório, carga horária maior que zero)
- Persistência em banco de dados com Entity Framework Core