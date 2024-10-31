using Microsoft.EntityFrameworkCore;
using TodoList.Data.Config;
using TodoList.Data.Context;
using TodoList.Endpoints;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    var settings = builder.Configuration.GetSection("TodoList").Get<TodoListSettings>();

    var connectionString = settings?.DevConnectionString;

    builder.Services.AddDbContext<TodoDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });

    builder.Services.AddScoped<IDbContextFactory<TodoDbContext>, TodoDbContextFactory>();
}

if (builder.Environment.IsProduction())
{
    var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? "Some error has occurred.";

    builder.Services.AddDbContext<TodoDbContext>(options =>
    {
        options.UseNpgsql(connectionString);
    });
}

builder.Services.AddDbContext<TodoDbContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("development-policy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .WithMethods(
                "GET",
                "POST",
                "PUT",
                "DELETE",
                "PATCH"
                );
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors();

app.MapGet("test", () => $"Todo List API is Running! {DateTime.UtcNow}");

app.MapToDoEndpoints();

app.Run();
