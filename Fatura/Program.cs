using Fatura.Application;
using Fatura.Domain.Data;
using Fatura.Infra.Data;
using Fatura.Infra.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EfSqliteAdapter>();

//N�o � poss�vel utilizar o AddSingleton aqui, porque um servi�o n�o pode come�ar depois de outro. Por
//exemplo: o TransacaoDataSqlite, recebe no seu construtor, o EfSqliteAdapter (scopped). Ent�o se ele fosse
//Singleton, n�o seria poss�vel atribuir � interface ITransacaData, o TransacaoDataSqlite sem o
//EfSqliteAdapter. Al�m de que por padr�o, o .NET recomenda o AddScopped para servi�os
builder.Services.AddScoped<ITransacaoData, TransacaoDataSqlite>();
builder.Services.AddScoped<IMoedaData, MoedaDataAPI>();
builder.Services.AddScoped<FaturaUseCase>();

var app = builder.Build();

app.UseHttpsRedirection();

//Al�m de adicionar no WebApplication, � necess�rio ap�s o build, mapear estes controllers
app.MapControllers();

app.Run();