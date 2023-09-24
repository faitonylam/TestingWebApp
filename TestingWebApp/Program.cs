global using TestingWebApp.Models;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Logging.EventLog;

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TestingWebApp.Services;
using TestingWebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Add Database Context
builder.Services.AddDbContext<TestdbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDataRepositories, DataRepositories>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
