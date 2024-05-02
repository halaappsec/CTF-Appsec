using MyWebApiApp.Models; // For WeatherForecast
using MyWebApiApp.Services; // For AuthService

using log4net;
using log4net.Config;

var logger = LogManager.GetLogger(typeof(Program));
XmlConfigurator.Configure(new FileInfo("log4net.config"));

logger.Info("log4net is now configured and logging!");


// Define a class to handle login requests
public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<AuthService>(); // Register AuthService for dependency injection
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirect root to index.html
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/index.html");
        return;
    }
    await next();
});

// Enable static files
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions { DefaultFileNames = new List<string> { "index.html" } });

// Configure the WeatherForecast endpoint
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
}).WithName("GetWeatherForecast")
  .WithOpenApi();

// Configure the login endpoint to accept parameters from the request body
app.MapPost("/login", ([FromForm] LoginRequest loginRequest, AuthService authService) =>
{
    if (authService.ValidateLogin(loginRequest.Username, loginRequest.Password))
        return Results.Ok("Login Successful");
    else
        return Results.Unauthorized();
});

// Run the application
app.Run();

