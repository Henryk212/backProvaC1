using controleDeFuncionarios.Models;
using controleDeFuncionarios.Dao;
using controleDeFuncionarios.Rotas;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();
app.UseCors("PermitirTudo");

InicializarBanco.PopularBancoDeDados(app.Services);

app.MapGet("/", () => "Hello World!");
app.MapGetRoutes();
app.MapPostRoutes();
app.MapDeleteRoutes();
app.MapPutRoutes();

app.Run();
