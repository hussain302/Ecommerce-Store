using Ecommerce.WebUI.DAL.IRepositories;
using Ecommerce.WebUI.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller}/{action}/{id?}",
    defaults: new { area = "Admin", controller = "Category", action = "Manage" }
);
app.Run();
