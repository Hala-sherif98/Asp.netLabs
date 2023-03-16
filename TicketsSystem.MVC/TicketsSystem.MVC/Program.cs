using Microsoft.EntityFrameworkCore;
using TicketsSystem.BL.Managers.Departments;
using TicketsSystem.BL.Managers.Developers;
using TicketsSystem.BL.Managers.Tickets;
using TicketsSystem.DAL.Context;
using TicketsSystem.DAL.Repo.DepartmentsRepo;
using TicketsSystem.DAL.Repo.DevelopersRepo;
using TicketsSystem.DAL.Repo.TicketsRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("TicketsSystem");
builder.Services.AddDbContext<TicketContext>(options
    => options.UseSqlServer(connectionString));


builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();


builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
builder.Services.AddScoped<IDeveopersManager, DevelopersManager>();

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
