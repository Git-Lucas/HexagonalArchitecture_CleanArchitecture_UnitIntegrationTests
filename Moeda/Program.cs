var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

//N�o foi desacoplado o "Controller" do Main, pelo fato desta aplica��o / API, ser absurdamente simples para
//esta simula��o
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