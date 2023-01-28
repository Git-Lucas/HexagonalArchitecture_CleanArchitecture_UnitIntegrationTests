var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

//Não foi desacoplado o "Controller" do Main, pelo fato desta aplicação / API, ser absurdamente simples para
//esta simulação
app.MapGet("/moedas", () =>
{
    var moedas = new Dictionary<string,double>()
    {
        { "USD", 3 },
        { "EUR", 5 }
    };

    return Results.Ok(moedas);
});

app.Run();