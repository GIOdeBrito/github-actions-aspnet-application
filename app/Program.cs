var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var logger = app.Logger;

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");

app.MapGet("/hello", () => "Hello World!");

logger.LogInformation("[NOTE] Hot reload doesn't work well with Program.cs. Best to restart the container after big changes.");

app.Run();
