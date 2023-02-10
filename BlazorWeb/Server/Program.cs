using Microsoft.AspNetCore.ResponseCompression;
using BlazorWeb.DAL;
using BlazorWeb.BLL;
using BlazorWeb.DAL.Persistence;
using BlazorWeb.Shared;
using Microsoft.AspNetCore.Hosting;
using GlobalErrorHandling.Extensions;
using BlazorWeb.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

//builder.Services.AddSharedModelServices();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
}
else
{
  app.UseExceptionHandler("/Error");
}

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.MigrateDatabase<DataContext>((context, services) => { });
app.Run();

