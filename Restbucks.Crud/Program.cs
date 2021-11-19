using RestbucksCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSingleton<InMemoryOrderDb>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/order", (InMemoryOrderDb db, Order order) =>
{
    db.CreateOrder(order);
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

    db.UpdateOrder(order);
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
        db.DeleteOrder(id);
        return Results.Ok();
    }

    return Results.Conflict(); // 409
});

app.Run();