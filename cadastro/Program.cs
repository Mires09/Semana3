using cadastro.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://0.0.0.0:8000");

var app = builder.Build();

app.MapGet("/", () => "API de funcionários em execução ...");

Funcionario[] funcionarios = new Funcionario[100];
int contador = 0;

//Rotas
app.MapGet("/for", () => {
    for(int i=0; i<5; i++){
        Console.WriteLine(i);
    }
});

app.MapGet("/while", () => {
    int i=0;
    while(i< 5){
        Console.WriteLine(i);
        i++;
    }
});

app.MapGet("/objeto", () => {
    Funcionario funcionario = new Funcionario();

    funcionario.Nome = "Fulano";

    Console.WriteLine("Nome: " + funcionario.Nome);

    return Results.Ok(new {
    nome = funcionario.Nome
    });
});

app.MapGet("/vetor", () => {
    int[] numeros = new int[100];

    numeros[0] = 15;
    numeros[1] = 53;
    numeros[2] = 34;
    
    Console.WriteLine("Valor: " + numeros[0]);
    Console.WriteLine("Valor: " + numeros[1]);
    Console.WriteLine("Valor: " + numeros[2]);

    return Results.Ok(new {
    numeros
    });
 });

app.MapGet("/funcionario/cadastrar/{nome}", (string nome) => {
    Funcionario funcionario = new Funcionario();
    funcionario.Nome = nome;

    funcionarios[contador] = funcionario;
    contador++;

    //Modificar na próxima aula
    return Results.Ok(new{
        funcionarios
    });
 });


app.Run();