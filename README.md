# MyFinance Web

## Descrição do Projeto

O MyFinance Web é uma aplicação ASP.NET MVC para controle financeiro familiar, permitindo o registro de receitas e despesas, categorização por Plano de Contas, análise de gastos e geração de relatórios e gráficos para melhor planejamento financeiro.

A aplicação possibilita:
- Cadastro de Plano de Contas (categorias de receitas e despesas)
- Registro de transações financeiras vinculadas ao plano de contas
- Interface web responsiva para desktop, tablets e smartphones

## Arquitetura Utilizada

A arquitetura segue o padrão MVC, com separação em camadas:
- **Controllers**: Lógica de controle e rotas
- **Services**: Regras de negócio e orquestração
- **Domain**: Entidades de domínio
- **Infrastructure**: Acesso a dados (DbContext)
- **Views**: Interface do usuário

Diagrama arquitetural:

(![Captura de tela de 2025-07-07 23-42-18](https://github.com/user-attachments/assets/7288bc64-5921-4fdd-b318-a7f2652d8a2f)

## Tecnologias Utilizadas
- ASP.NET Core MVC (.NET 6+)
- Entity Framework Core
- MySQL Server **ou** SQL Server
- Bootstrap (CSS)
- C#

## Funcionalidades/Requisitos

### RF001 – Plano de Contas
O sistema permite o cadastro de Plano de Contas para categorização das Receitas e Despesas.

Exemplo:
| Código | Descrição         | Tipo |
|--------|-------------------|------|
| 1      | Combustível       | D    |
| 2      | Supermercado      | D    |
| 3      | Almoço            | D    |
| 4      | IPTU              | D    |
| 5      | IPVA              | D    |
| 6      | Salário           | R    |
| 7      | Crédito de Juros  | R    |
| 8      | Apartamento Aluguel| R   |

### RF002 – Registro de Transações
O sistema permite o registro de transações financeiras indicando um item do Plano de Contas.

Exemplo:
| Código | Histórico         | Data                | Plano de Contas | Valor     |
|--------|-------------------|---------------------|-----------------|-----------|
| 100    | Gasolina Viagem   | 20/12/2022 – 14:00  | 1               | R$ 289,00 |
| 200    | Almoço Família    | 24/12/2022 – 12:30  | 3               | R$ 120,00 |
| 300    | Salário           | 05/01/2023 – 00:00  | 6               | R$ 1.000,00|
| 400    | IPVA Blazer       | 10/01/2023 – 13:30  | 5               | R$ 250,00 |

### RF003 – Relatório de Transações por Período
Relatório HTML das transações por tipo (Receita ou Despesa) e por período de datas.

### RF004 – Gráfico de Receitas vs Despesas por Período
Relatório gráfico (pizza) mostrando o total de receitas e despesas por período.

### RNF005 – Suporte a Plataformas
Sistema web responsivo para desktop, tablets e smartphones.

### RNF006 – Linguagens de Implementação
Desenvolvido em Microsoft ASP.NET MVC com Banco de Dados SQL-SERVER (ou MySQL).

## Telas do Sistema

### Plano de Contas
(![Captura de tela de 2025-07-07 23-46-11](https://github.com/user-attachments/assets/120c33e5-f329-4848-94f0-401ec16490e5)

### Cadastro de Plano de Contas

(![Captura de tela de 2025-07-07 23-46-31](https://github.com/user-attachments/assets/641e60ad-728d-4150-a2ab-bb12da98c72c))

### Transações Financeiras

(![Captura de tela de 2025-07-07 23-46-47](https://github.com/user-attachments/assets/5a57fd7d-3255-4ac0-a7c2-fdec82f4c2c9))

### Cadastro de Transação

(![Captura de tela de 2025-07-07 23-47-07](https://github.com/user-attachments/assets/c3cfeeb0-c60a-4700-8761-5c05daa43e3f))

## Como rodar o projeto com MySQL Server **ou** SQL Server local

1. **Crie o banco de dados e tabelas**
   - Execute o script SQL disponível em `src/myfinance-web-dotnet-08/myfinance.sql` no seu MySQL local **ou** adapte para SQL Server.

2. **Configure a connection string**
   - **Para MySQL:** No arquivo `MyfinanceDbContext.cs`, use:
     ```csharp
     var connectionString = "server=localhost;database=myfinance;user=SEU_USUARIO;password=SUA_SENHA;";
     optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
     ```
   - **Para SQL Server:** No arquivo `MyfinanceDbContext.cs`, use:
     ```csharp
     var connectionString = @"Server=localhost;Database=myfinance;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True;";
     optionsBuilder.UseSqlServer(connectionString);
     ```

3. **Execute o projeto**
   ```sh
   dotnet run 
   ```

4. **Acesse no navegador**
   - Normalmente em: http://localhost:5000 ou http://localhost:5001

## Sobre o Projeto

Aplicação web para que famílias possam registrar receitas e despesas, analisar gastos e planejar melhor suas finanças. 

---
PONTIFÍCIA UNIVERSIDADE CATÓLICA DE MINAS GERAIS  
CURSO DE PÓS-GRADUAÇÃO EM ENGENHARIA DE SOFTWARE  
PRÁTICAS DE IMPLEMENTAÇÃO E EVOLUÇÃO DE SOFTWARE  
Prof.: Filipe Tório

