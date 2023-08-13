using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json");
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Welcome to API Gateway for all services of ecommerce");
await app.UseOcelot();
app.Run();
