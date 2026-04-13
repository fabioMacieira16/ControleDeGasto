# ApiDDD

## Banco de Dados — Migrations

O projeto utiliza **Entity Framework Core** com SQLite. O banco é criado e populado automaticamente via migrations.

### Pré-requisitos

Instale a ferramenta global do EF Core (caso ainda não tenha):

```bash
dotnet tool install --global dotnet-ef
```

### Criar o banco e aplicar as migrations

Execute a partir da pasta `ApiDDD.Api`:

```bash
cd backend/ApiDDD.Api

dotnet ef database update \
  --project ../ApiDDD.Data/ApiDDD.Data.csproj \
  --startup-project ./ApiDDD.Api.csproj
```

O arquivo `controle_gastos.db` será criado automaticamente na pasta `ApiDDD.Api`.

### Dados iniciais (Seed)

A migration `InitialCreate` já insere dados de teste:

**Pessoas**
| Id | Nome | Idade |
|----|--------------|-------|
| 1 | João Silva | 30 |
| 2 | Maria Souza | 25 |
| 3 | Pedro Alves | 17 |

**Categorias**
| Id | Descrição | Finalidade |
|----|--------------|------------|
| 1 | Alimentação | DESPESA |
| 2 | Transporte | DESPESA |
| 3 | Salário | RECEITA |
| 4 | Freelance | RECEITA |
| 5 | Lazer | DESPESA |
| 6 | Investimentos | AMBAS |

**Transações**
| Id | Descrição | Valor | Tipo | Pessoa |
|----|--------------------------|----------|---------|-------------|
| 1 | Supermercado | R$ 350,00 | DESPESA | João Silva |
| 2 | Uber para o trabalho | R$ 45,50 | DESPESA | João Silva |
| 3 | Salário de março | R$ 5000,00 | RECEITA | João Silva |
| 4 | Almoço | R$ 32,00 | DESPESA | Maria Souza |
| 5 | Projeto freelance | R$ 1200,00 | RECEITA | Maria Souza |
| 6 | Cinema | R$ 55,00 | DESPESA | Pedro Alves |
| 7 | Lanche | R$ 18,00 | DESPESA | Pedro Alves |

### Criar uma nova migration (após alterar o modelo)

```bash
cd backend/ApiDDD.Api

dotnet ef migrations add <NomeDaMigration> \
  --project ../ApiDDD.Data/ApiDDD.Data.csproj \
  --startup-project ./ApiDDD.Api.csproj
```

### Remover a última migration (se ainda não foi aplicada)

```bash
dotnet ef migrations remove \
  --project ../ApiDDD.Data/ApiDDD.Data.csproj \
  --startup-project ./ApiDDD.Api.csproj
```
