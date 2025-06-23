using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using XPE.ArquiteturaSoftware.Modulo5.Model.Entities;
using XPE.ArquiteturaSoftware.Modulo5.Model.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/produto", () =>
    {
        var service = new ProdutoService();
        return service.ListAll();
    })
    .WithName("GetAll")
    .WithOpenApi();

app.MapPost("/produto", ([FromBody] Produto produto) =>
    {
        var service = new ProdutoService();
            service.Create(produto);

            return Results.Created();
    })
    .WithName("Create")
    .WithOpenApi();

app.MapPut("/produto", ([FromBody] Produto produto) =>
    {
        var service = new ProdutoService();
        service.Edit(produto);

        return Results.Ok();
    })
    .WithName("Update")
    .WithOpenApi();

app.MapDelete("/produto", ([FromBody] Produto produto) =>
    {
        var service = new ProdutoService();
        service.Remove(produto);

        return Results.Ok();
    })
    .WithName("Remove")
    .WithOpenApi();

app.MapGet("/produto/{id}", ([FromRoute] Guid id) =>
    {
        var service = new ProdutoService();


        var result = service.GetById(id);
         return  result is not null? Results.Ok(result)
            : Results.NotFound();
    })
    .WithName("GetById")
    .WithOpenApi();

app.Run();