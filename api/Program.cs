var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
		// I mean, I don't have a certificate
		// still, it's ideal to keep this in a way
		policy.WithOrigins("https://HTTPS_URL")
              .AllowAnyMethod()
              .AllowAnyHeader()
			  .AllowCredentials();
    });

	options.AddPolicy("DevPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Use Swagger if in Development environment
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
	app.UseCors("DevPolicy");
}
// For production
else
{
	app.UseCors();
}

app.MapHealthChecks("/health");
app.MapGet("/time", () => new { time = DateTime.Now });

app.MapGet("/api", () =>
{
    return new { route = "v1", path = "/api" };
});

app.Run();