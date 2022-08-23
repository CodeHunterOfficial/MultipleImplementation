using MultipleImplementation.Controllers;
using MultipleImplementation.Interfaces;
using MultipleImplementation.Repositories;
using MultipleImplementation.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

builder.Services.AddSingleton<ShoppingCartCache>();
builder.Services.AddSingleton<ShoppingCartDB>();
builder.Services.AddSingleton<ShoppingCartAPI>();



builder.Services.AddTransient<Func<string, IShoppingCart>>(serviceProvider => key =>
{
    switch (key)
    {
        case "API":
            return serviceProvider.GetService<ShoppingCartAPI>();
        case "DB":
            return serviceProvider.GetService<ShoppingCartDB>();
        default:
            return serviceProvider.GetService<ShoppingCartCache>();
    }
});

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

app.UseAuthorization();

app.MapControllers();

app.Run();
