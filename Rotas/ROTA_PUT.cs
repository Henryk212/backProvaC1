using Microsoft.EntityFrameworkCore;
using controleDeFuncionarios.Models;
using controleDeFuncionarios.Dao;

namespace controleDeFuncionarios.Rotas;

public static class ROTA_PUT
{
    public static void MapPutRoutes(this WebApplication app)
    {
        app.MapPut("/api/cargo/{id}", async (int id, Cargo cargo, AppDbContext context) =>
        {
            var existingCargo = await context.Cargos.FindAsync(id);
            if (existingCargo == null)
            {
                return Results.NotFound("Cargo não encontrado.");
            }
            existingCargo.nome = cargo.nome;
            existingCargo.descricao = cargo.descricao;
            await context.SaveChangesAsync();
            return Results.Ok(existingCargo);
        });

        app.MapPut("/api/dadosbancarios/{id}", async (int id, DadosBancarios dados, AppDbContext context) =>
        {
            var existingDados = await context.DadosBancarios.FindAsync(id);
            if (existingDados == null)
            {
                return Results.NotFound("Dado bancário não encontrado.");
            }
            existingDados.banco = dados.banco;
            existingDados.agencia = dados.agencia;
            existingDados.conta = dados.conta;
            await context.SaveChangesAsync();
            return Results.Ok(existingDados);
        });

        app.MapPut("/api/endereco/{id}", async (int id, Endereco endereco, AppDbContext context) =>
        {
            var existingEndereco = await context.Enderecos.FindAsync(id);
            if (existingEndereco == null)
            {
                return Results.NotFound("Endereço não encontrado.");
            }
            existingEndereco.TipoLogradouro = endereco.TipoLogradouro;
            existingEndereco.Logradouro = endereco.Logradouro;
            existingEndereco.Numero = endereco.Numero;
            existingEndereco.Complemento = endereco.Complemento;
            existingEndereco.Bairro = endereco.Bairro;
            existingEndereco.Estado = endereco.Estado;
            existingEndereco.Cep = endereco.Cep;
            await context.SaveChangesAsync();
            return Results.Ok(existingEndereco);
        });

        app.MapPut("/api/pessoa/{id}", async (int id, Pessoa pessoa, AppDbContext context) =>
        {
            var existingPessoa = await context.Pessoas.FirstOrDefaultAsync(p => p.id == id);
            if (existingPessoa == null)
            {
                return Results.NotFound("Pessoa não encontrada.");
            }

            existingPessoa.nome = pessoa.nome;
            existingPessoa.dataNascimento = pessoa.dataNascimento;
            existingPessoa.cpf = pessoa.cpf;
            existingPessoa.telefone = pessoa.telefone;
            existingPessoa.email = pessoa.email;
            existingPessoa.sexo = pessoa.sexo;

            if (pessoa.Endereco != null && existingPessoa.enderecoID != null)
            {
                var existingEndereco = await context.Enderecos.FindAsync(existingPessoa.enderecoID);
                if (existingEndereco != null)
                {
                    existingEndereco.TipoLogradouro = pessoa.Endereco.TipoLogradouro;
                    existingEndereco.Logradouro = pessoa.Endereco.Logradouro;
                    existingEndereco.Numero = pessoa.Endereco.Numero;
                    existingEndereco.Complemento = pessoa.Endereco.Complemento;
                    existingEndereco.Bairro = pessoa.Endereco.Bairro;
                    existingEndereco.Estado = pessoa.Endereco.Estado;
                    existingEndereco.Cep = pessoa.Endereco.Cep;
                }
            }

                await context.SaveChangesAsync();
                return Results.Ok(existingPessoa);
            });

        app.MapPut("/api/setor/{id}", async (int id, Setor setor, AppDbContext context) =>
        {
            var existingSetor = await context.Setores.FindAsync(id);
            if (existingSetor == null)
            {
                return Results.NotFound("Setor não encontrado.");
            }
            existingSetor.nome = setor.nome;
            existingSetor.descricao = setor.descricao;
            await context.SaveChangesAsync();
            return Results.Ok(existingSetor);
        });

        app.MapPut("/api/funcionario/{id}", async (int id, Funcionario funcionario, AppDbContext context) =>
        {
            var existingFuncionario = await context.Funcionarios.FindAsync(id);
            if (existingFuncionario == null)
            {
                return Results.NotFound("Funcionário não encontrado.");
            }
            existingFuncionario.pessoaId = funcionario.pessoaId;
            existingFuncionario.setorId = funcionario.setorId;
            existingFuncionario.salario = funcionario.salario;
            existingFuncionario.cargoId = funcionario.cargoId;
            existingFuncionario.dadosBancariosId = funcionario.dadosBancariosId;
            existingFuncionario.enderecoID = funcionario.enderecoID;
            await context.SaveChangesAsync();
            return Results.Ok(existingFuncionario);
        });
    }
}