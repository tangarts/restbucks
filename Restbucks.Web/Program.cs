// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using Restbucks.Core;
using Restbucks.Core.Models;
using Restbucks.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Order"));
builder.Services.AddSingleton<IOrderRepository, InMemoryOrderDb>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapFallback(() => Results.Redirect("/swagger"));

app.MapPost("/order", (IOrderRepository db, Order order) =>
{
   db.CreateOrder(order);
   return Results.Created($"/order/{order.Id}", order);
})
.WithName("new_order");

app.MapGet("/order/{id:int}", (IOrderRepository db, int id) =>
{
    return db.GetOrder(id) switch
   {
       Order order => Results.Ok(order),
       null => Results.NotFound()
   };
})
.WithName("get_order");

app.MapPut("/order/{id:int}", (IOrderRepository db, int id, Order order) =>
{
    if (id != order.Id)
    {
        return Results.BadRequest();
    }

    if (!db.Exists(id))
    {
        return Results.NotFound();
    }

    db.UpdateOrder(order);
    return Results.Ok();
})
.WithName("update_order");

app.MapDelete("/order/{id:int}", (IOrderRepository db, int id) =>
{
    Order? order = db.GetOrder(id);

    if (order is null)
    {
        return Results.NotFound();
    }

    if (order.OrderStatus == Status.Served) // orderStatus == Ordered
    {
        db.DeleteOrder(id);
        return Results.Ok();
    }

    return Results.Conflict(); // 409
})
.WithName("delete_order");

app.Run("http://localhost:9090/");
