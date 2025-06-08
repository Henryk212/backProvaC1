using Microsoft.EntityFrameworkCore;
using controleDeFuncionarios.Models;
using controleDeFuncionarios.Dao;

namespace controleDeFuncionarios.Rotas;

public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        
        app.MapPost("/api/cargo", async (Cargo cargo, AppDbContext context) =>
        {
            context.Cargos.Add(cargo);
            await context.SaveChangesAsync();
            return Results.Created($"/api/cargo/{cargo.id}", cargo);
        });

        
        app.MapPost("/api/dadosbancarios", async (DadosBancarios dados, AppDbContext context) =>
        {
            context.DadosBancarios.Add(dados);
            await context.SaveChangesAsync();
            return Results.Created($"/api/dadosbancarios/{dados.id}", dados);
        });

        
        app.MapPost("/api/endereco", async (Endereco endereco, AppDbContext context) =>
        {
            context.Enderecos.Add(endereco);
            await context.SaveChangesAsync();
            return Results.Created($"/api/endereco/{endereco.Id}", endereco);
        });


        app.MapPost("/api/pessoa", async (PessoaEnderecoRequest request, AppDbContext context) =>
        {
            var endereco = request.Endereco;
            context.Enderecos.Add(endereco);
            await context.SaveChangesAsync();

            var pessoa = request.Pessoa;
            pessoa.enderecoID = endereco.Id;

            context.Pessoas.Add(pessoa);
            await context.SaveChangesAsync();

            return Results.Created($"/api/pessoa/{pessoa.id}", new { Pessoa = pessoa, Endereco = endereco });
        });

        
        app.MapPost("/api/setor", async (Setor setor, AppDbContext context) =>
        {
            context.Setores.Add(setor);
            await context.SaveChangesAsync();
            return Results.Created($"/api/setor/{setor.id}", setor);
        });

        
        app.MapPost("/api/funcionario", async (Funcionario funcionario, AppDbContext context) =>
        {
            context.Funcionarios.Add(funcionario);
            await context.SaveChangesAsync();
            return Results.Created($"/api/funcionario/{funcionario.id}", funcionario);
        });
    }
}
