using TodoList.Endpoints;
using TodoList.Infra.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("development-policy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<TodoDbContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("development-policy");

app.UseHttpsRedirection();

app.MapGet("test", () => $"Todo List API is Running! {DateTime.UtcNow}");

app.MapToDoEndpoints();

app.Run();
