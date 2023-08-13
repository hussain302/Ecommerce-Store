using Ecommerce.MapperConfig;
using ProductServices.Data;
using ProductServices.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Register Automapper Service
builder.Services.AddSingleton(sp =>
{
    var mapperConfig = ProductMapperConfig.RegisterProductMaps();
    return mapperConfig.CreateMapper();
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.


//Local services
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//Cache service
builder.Services.AddMemoryCache();

builder.Services.AddControllers();

//swagger
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
app.MapGet("/", () => "Welcome to Products API project of Microservices");
app.UseOutputCache();
app.UseResponseCaching();
app.MapControllers();
app.Run();
