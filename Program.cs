// See https://aka.ms/new-console-template for more information
using HelloWorldV2.aoc_2024_day13;

Console.WriteLine("Hello, World!");

var logic = new Logic();
//logic.Handle();

var builder = WebApplication.CreateBuilder(args);

// Configure to listen on all interfaces
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(3000);
});

var app = builder.Build();

app.MapGet("/", () => "Hello Web");

app.Run();