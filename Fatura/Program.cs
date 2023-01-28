using Fatura.Application;
using Fatura.Domain.Data;
using Fatura.Infra.Data;
using Fatura.Infra.Data.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EfSqliteAdapter>();

//Não é possível utilizar o AddSingleton aqui, porque um serviço não pode começar depois de outro. Por
//exemplo: o TransacaoDataSqlite, recebe no seu construtor, o EfSqliteAdapter (scopped). Então se ele fosse
//Singleton, não seria possível atribuir à interface ITransacaData, o TransacaoDataSqlite sem o
//EfSqliteAdapter. Além de que por padrão, o .NET recomenda o AddScopped para serviços
builder.Services.AddScoped<ITransacaoData, TransacaoDataSqlite>();
builder.Services.AddScoped<IMoedaData, MoedaDataAPI>();
builder.Services.AddScoped<FaturaUseCase>();

var app = builder.Build();

app.UseHttpsRedirection();

//Além de adicionar no WebApplication, é necessário após o build, mapear estes controllers
app.MapControllers();

app.Run();