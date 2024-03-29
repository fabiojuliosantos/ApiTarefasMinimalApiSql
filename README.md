# :computer: ApiCatalogoMinimalApi
## :book: Repositório de uma Api de Tarefas
#### Repositório de Estudos sobre API utilizando .NET com a abordagem de Minimal Api

Minimal APIs utilizam uma quantidade menor de recursos se comparadas às APIs convencionais, sendo ideais para aplicações que consumam o mínimo de dependências do ASP.NET Core, por exemplo.

Todos os recursos necessários ficam presentes na classe Program.cs como classes das models, configurações e controllers

#### Tecnologias utilizadas:
- .Net 7;
- Dapper;
- SQL Server (ou outro banco de preferência)

#### Rotas do projeto:

|Rota|Verbo Http|Funcionalidade|
|:---:|:--:|:----:|
|/tarefas|GET|Lista todas as Tarefas|
|/tarefas{id}|GET|Mostra a tarefa do id informado|
|/tarefas|POST|Insere uma nova tarefa|
|/tarefas{id}|PUT|Atualiza a tarefa informada pelo id|
|/tarefas{id}|DELETE|Exclui a tarefa informada pelo id|

#### Observação:
- Todos os dados são salvos em banco utilizando o Dapper, para executar, configure de acordo com a sua ConnectionString, no arquivo *appsettings.json* inserindo o código
  
  
  `"ConnectionStrings": {
    "DefaultConnection": "Sua ConnectionString;"
  }`
