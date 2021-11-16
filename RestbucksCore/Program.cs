using Microsoft.EntityFrameworkCore;
using RestbucksCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OrderDb>(opt => opt.UseInMemoryDatabase("Order"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapFallback(() => Results.Redirect("/swagger"));

app.MapGet("/order/", (InMemoryOrderDb db) =>
{
    return db.Values;
})
.WithName("GetOrders");

app.MapPost("/order", (InMemoryOrderDb db, Order order) =>
{
    db.Save(order);
    return Results.Created($"/order/{order.Id}", order);
});

app.MapGet("/order/{id:int}", (InMemoryOrderDb db, int id) =>
{
    // Nice switch syntax from davidfowl
    return db.GetOrder(id) switch
    {
        Order order => Results.Ok(order),
        null => Results.NotFound()
    };
})
.WithName("GetOrder");



app.MapPut("/order/{id:int}", (InMemoryOrderDb db, int id, Order order) =>
{

    if (id != order.Id) 
    {
        return Results.BadRequest();
    }
    else
    {
        if (!db.Exists(order.Id))
        {
            return Results.NotFound();
        }
        db.Update(id, order);
        db.Save();
        return Results.Ok();    
    }

});

app.MapDelete("/order/{id:int}", (InMemoryOrderDb db, int id) =>
{
    Order? order = db.GetOrder(id);

    if (order is null) // id in db
    {
        return Results.NotFound();
    }
    else
    { 
        if (order.OrderStatus == Order.Status.Served) // orderStatus == Ordered
        {
            db.Delete(id);
            db.Save();
            return Results.Ok();
        }
        
        return Results.Conflict(); // 409
    } 
});




app.Run();
