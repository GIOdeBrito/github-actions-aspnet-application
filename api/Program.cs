var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Swagger if in Development environment
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/health");
app.MapGet("/time", () => new { time = DateTime.Now });

app.MapGet("/api", () =>
{
    return new { route = "v1", path = "/api" };
});

app.Run();