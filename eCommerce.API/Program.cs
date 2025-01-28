using eCommerce.Infrastructure;
using eCommerce.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
