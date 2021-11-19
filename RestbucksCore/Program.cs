// <copyright file="Program.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

using RestbucksCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<OrderDbContext>(opt => opt.UseInMemoryDatabase("Order"));
builder.Services.AddSingleton<InMemoryOrderDb>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapFallback(() => Results.Redirect("/swagger"));

app.MapPost("/order",  (InMemoryOrderDb db, Order order) =>
{
    db.Save(order);
    return Results.Created($"/order/{order.Id}", order);
});

app.MapGet("/order/{id:int}", (InMemoryOrderDb db, int id) =>
{
    return db.GetOrder(id) switch
   {
       Order order => Results.Ok(order),
       null => Results.NotFound()
   };
});

app.MapPut("/order/{id:int}", (InMemoryOrderDb db, int id, Order order) =>
{
    if (id != order.Id)
    {
        return Results.BadRequest();
    }

    if (!db.Exists(id))
    {
        return Results.NotFound();
    }

    db.Update(id, order);
    return Results.Ok();
});

app.MapDelete("/order/{id:int}", (InMemoryOrderDb db, int id) =>
{
    Order? order = db.GetOrder(id);

    if (order is null)
    {
        return Results.NotFound();
    }

    if (order.OrderStatus == Status.Served) // orderStatus == Ordered
    {
        db.Delete(id);
        return Results.Ok();
    }

    return Results.Conflict(); // 409
});

app.Run();
