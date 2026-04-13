# Controle de Gastos

Sistema de controle de gastos residenciais desenvolvido com foco em boas práticas, separação de responsabilidades e aderência às regras de negócio.

## Tecnologias

**Backend**
- .NET 6 — Web API
- Entity Framework Core 6 com SQLite
- AutoMapper 15
- Arquitetura DDD (Domain-Driven Design)

**Frontend** _(a implementar)_
- React com TypeScript

## Estrutura do Projeto

```
ControleDeGasto/
├── backend/
│   ├── ApiDDD.Api/          # Camada de apresentação (Controllers, Startup)
│   ├── ApiDDD.Application/  # Serviços, DTOs, Interfaces, Profiles
│   ├── ApiDDD.Domain/       # Entidades, Enums, Interfaces de repositório
│   ├── ApiDDD.Data/         # DbContext, Migrations, Repositórios
│   └── ApiDDD.Test/         # Testes automatizados
└── frontend/                # (a implementar)
```

## Funcionalidades

### Pessoas
- Cadastro, edição, exclusão e listagem
- Ao excluir uma pessoa, todas as suas transações são removidas em cascata

### Categorias
- Cadastro e listagem
- Finalidade: `DESPESA`, `RECEITA` ou `AMBAS`

### Transações
- Registro de despesas e receitas vinculadas a uma pessoa e categoria
- **Regras de negócio:**
  - Valor deve ser positivo
  - Menores de 18 anos só podem registrar `DESPESA`
  - A categoria deve ser compatível com o tipo da transação

### Relatórios
- `GET /relatorios/pessoas` — totais de receitas, despesas e saldo por pessoa, com totais gerais

## Como executar o backend

### Pré-requisitos
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- `dotnet-ef` instalado globalmente:
  ```bash
  dotnet tool install --global dotnet-ef
  ```

### 1. Criar o banco de dados

```bash
cd backend/ApiDDD.Api

dotnet ef database update \
  --project ../ApiDDD.Data/ApiDDD.Data.csproj \
  --startup-project ./ApiDDD.Api.csproj
```

Isso cria o arquivo `controle_gastos.db` com dados de teste já inseridos (3 pessoas, 6 categorias e 7 transações).

### 2. Rodar a API

```bash
cd backend/ApiDDD.Api
dotnet run
```

A API estará disponível em `https://localhost:5001` e a documentação Swagger em `https://localhost:5001/swagger`.

## Documentação do banco de dados

Consulte [backend/README.md](backend/README.md) para detalhes sobre migrations, seed data e comandos do EF Core.

