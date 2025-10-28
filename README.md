# DesafioTecnicoUnicont

Projeto desenvolvido em .NET 8 para processamento e gestão de notas fiscais eletrônicas, utilizando arquitetura baseada em API e Worker.

## Sumário

- [Descrição](#descrição)
- [Requisitos](#requisitos)
- [Configuração do appsettings.json](#configuração-do-appsettingsjson)
- [Como Executar](#como-executar)
- [Observações](#observações)

---

## Descrição

Este projeto é composto por uma API (`DesafioTecnicoUnicont.Api`) e um Worker (`DesafioTecnicoUnicode.Worker`) que processam arquivos XML de notas fiscais, realizam persistência em banco de dados SQL Server e comunicação via RabbitMQ.

---

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local ou remoto)
- RabbitMQ (se aplicável)
- Visual Studio 2022 ou superior

---

## Configuração do appsettings.json

O arquivo `appsettings.json` contém as principais configurações do projeto. Exemplo:

{ "ConnectionStrings": { "DefaultConnection": "Server=(local);Database=DesafioTecnicoDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False" }, "Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } }, "AllowedHosts": "*" }


### Principais configurações:

- **ConnectionStrings:DefaultConnection**  
  String de conexão com o banco de dados SQL Server.  
  > Exemplo:  
  `Server=(local);Database=DesafioTecnicoDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False`

- **Logging**  
  Nível de log para aplicação e para componentes do ASP.NET Core.

- **AllowedHosts**  
  Define quais hosts podem acessar a API.  
  > `"*"` permite todos.

> **Importante:**  
> Ajuste a string de conexão conforme seu ambiente de banco de dados.

---

## Como Executar

### 1. Restaurar Dependências

Abra o terminal na raiz do projeto e execute:
`dotnet restore`
### 2. Gerar Banco de Dados

Se estiver usando Entity Framework, execute:
`dotnet ef database update --startup-project DesafioTecnicoUnicont.Api`

### 3. Executar a API
`dotnet run --project DesafioTecnicoUnicont.Api`

A API estará disponível em `https://localhost:5001` (ou porta configurada).

### 4. Executar o Worker
`dotnet run --project DesafioTecnicoUnicode.Worker`

---

## Observações

- Certifique-se de que o SQL Server está ativo e acessível.
- Para RabbitMQ, configure as credenciais e host nos arquivos de configuração correspondentes.
- Ajuste o `appsettings.json` conforme seu ambiente de desenvolvimento ou produção.

---


