using Dapper.Contrib.Extensions;
using TarefasApi.Data;
using static TarefasApi.Data.TarefaContext;

namespace TarefasApi.Endpoints;

public static class TarefasEndpoints
{
    public static void MapTarefasEndpoint(this WebApplication app)
    {
        #region Get
        app.MapGet("/", () => $"Bem-Vindo a API Tarefas {DateTime.Now}");

        app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
        {
            using var con = await connectionGetter();
            var tarefas = con.GetAll<Tarefa>().ToList();
            if (tarefas is null) return Results.NotFound("Erro: Tarefas não encontradas!");
            return Results.Ok(tarefas);
        });

        app.MapGet("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
       {
           using var con = await connectionGetter();
           return con.Get<Tarefa>(id) is Tarefa tarefa ? Results.Ok(tarefa) : Results.NotFound("Erro: Tarefa não encontrada!");
       });
        #endregion Get

        #region Post
        app.MapPost("/tarefas", async (GetConnection connectionGetter, Tarefa Tarefa) =>
        {
            using var con = await connectionGetter();
            var id = con.Insert(Tarefa);
            return Results.Created($"/tarefas/{id}", Tarefa);
        });
        #endregion Post

        #region Put
        app.MapPut("/tarefas", async (GetConnection connectionGetter, Tarefa Tarefa) =>
       {
           using var con = await connectionGetter();
           var id = con.Update(Tarefa);
           return Results.Created($"/tarefas/{id}", Tarefa);
       });
        #endregion Put
        
        #region Delete
        app.MapDelete("/tarefas/{id}", async (GetConnection connectionGetter, int id) =>
        {
            using var con = await connectionGetter();

            var deleted = con.Get<Tarefa>(id);

            if (deleted is null) return Results.NotFound("Erro: Tarefa não encontrada!");

            con.Delete(deleted);
            return Results.Ok(deleted);
        });
        #endregion Delete
    }
}