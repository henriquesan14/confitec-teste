# API Usuários - WebApp Usuários
## API e WebApp de CRUD de Usuários

### Features

- [x] API REST de CRUD de usuários
- [x] WebApp SPA de usuários


### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:
- [.NET](https://dotnet.microsoft.com/en-us/)
- [Angular](https://dotnet.microsoft.com/en-us/)
- [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)

### 🛠 Padrões Utilizados

As seguintes padrões foram usados na construção do projeto:
- DDD (Domain-Driven Design)
- CQRS (Command Query Responsibility Segregation)
- SOLID

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET](https://dotnet.microsoft.com/en-us/), [Angular](https://dotnet.microsoft.com/en-us/).
Além disto é bom ter um editor para trabalhar com o código como [VSCode](https://code.visualstudio.com/) ou [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).
Também é preciso configurar as váriaveis de conexão com banco de dados no arquivo `confitec-teste/src/Confitec.API/appsettings.json` e verificar qual URL e porta a API está rodando para apontar no arquivo `confitec-teste/src/confitec-webapp/src/environments/environment.ts`.

### 🎲 Rodando o Back End (servidor)

#### Rodando Confitec.API

```bash
# Clone este repositório
$ git clone <https://github.com/henriquesan14/confitec-teste.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd confitec-teste

# Vá para a pasta da Confitec.API
$ cd src/Confitec.API

# Execute a aplicação com o comando do dotnet
$ dotnet run

# A API iniciará na porta:5000 com HTTP e na porta:5001 com HTTPS - acesse <http://localhost:5001>
```

#### Rodando Confitec-webapp

```bash
# Volte para raiz do projeto
$ cd ..

# Vá para a pasta da confitec-webapp
$ cd src/confitec-webapp

# Instale as dependências
$ npm install

# Execute a aplicação com o comando do angular
$ ng serve

# A Aplicação iniciará na porta:4200 - acesse <http://localhost:4200>
```


### Autor
---

<a href="https://www.linkedin.com/in/henrique-san/">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/33522361?v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Henrique Santos</b></sub></a> <a href="https://www.linkedin.com/in/henrique-san/">🚀</a>


Feito com ❤️ por Henrique Santos 👋🏽 Entre em contato!

[![Linkedin Badge](https://img.shields.io/badge/-Henrique-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/henrique-san/)](https://www.linkedin.com/in/henrique-san/) 
