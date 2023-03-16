using IssuesSystem.Bl;
using IssuesSystem.DAL.Context;
using IssuesSystem.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//IOC requires some sort of overload inside constructor called (dbcontext options) to create the object.
//classes focus on logic only , connection string can be changed easily from json file.

var connectionString = builder.Configuration.GetConnectionString("tickets");
builder.Services.AddDbContext<IssuesContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<ITicketsManager, TicketsManager>();
//This is to tell IOC that we you need TicketsRepo Form ITicketsRepo not any other implementation.
//builder.Services.AddScoped<ITicketsRepo, TicketsRepo>(); //gives new object with every request
//builder.Services.AddSingleton<ITicketsRepo, TicketsRepo>(); gives one object with every request
//builder.Services.AddTransient<ITicketsRepo, TicketsRepo>();
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
