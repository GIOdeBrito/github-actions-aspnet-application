var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapFallbackToFile("index.html");

app.MapGet("/hello", () => "Hello World!");

var logger = app.Logger;

if(app.Environment.IsDevelopment())
{
	logger.LogInformation("[NOTE] Hot reload doesn't work well with Program.cs. Best to restart the container after big changes.");
}
else
{
	logger.LogInformation("[NOTE] Running program in Production.");
}

app.Run();
