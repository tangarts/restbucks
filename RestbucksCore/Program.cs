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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.MapFallback(() => Results.Redirect("/swagger"));

//app.MapGet("/order/", async (InMemoryOrderDb db) =>
//{
//    return await db.Orders.ToListAsync();
//})
//.WithName("GetOrders");

// Change to OrderItem
app.MapPost("/order",  (InMemoryOrderDb db, Order order) =>
{
    //await db.Orders.AddAsync(order);
    //await db.SaveChangesAsync();
    db.Save(order);
    return Results.Created($"/order/{order.Id}", order);
});

app.MapGet("/order/{id:int}",  (InMemoryOrderDb db, int id) =>
{
    // Nice switch syntax from davidfowl
    // return await db.Orders.FindAsync(id) switch
    return db.GetOrder(id) switch
    {
        Order order => Results.Ok(order),
        null => Results.NotFound()
    };
})
.WithName("GetOrder");



app.MapPut("/order/{id:int}", async (InMemoryOrderDb db, int id, Order order) =>
{

    if (id != order.Id)
    {
        return Results.BadRequest();
    }

    //if (!await db.Orders.AnyAsync(x => x.Id == id))
    if (!db.Exists(id))
    {
        return Results.NotFound();
    }
    //db.Update(order);
    //await db.SaveChangesAsync();
    db.Update(id, order);
    return Results.Ok();

});

app.MapDelete("/order/{id:int}", (InMemoryOrderDb db, int id) =>
{
    //Order? order = await db.Orders.FindAsync(id);
    Order? order = db.GetOrder(id);

    if (order is null) // id not in db
    {
        return Results.NotFound();
    }

    if (order.OrderStatus == Status.Served) // orderStatus == Ordered
    {
        // db.Orders.Remove(order);
        // await db.SaveChangesAsync();
        db.Delete(id);
        return Results.Ok();
    }

    return Results.Conflict(); // 409

});

app.Run();
