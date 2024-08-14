using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Models;
using Project.Repository;
using System.Security.Principal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(SessionOptions =>
{
    SessionOptions.IdleTimeout = TimeSpan.FromDays(20);
});
string conntect =  builder.Configuration.GetConnectionString("CS");
builder.Services.AddDbContext<AppDbContext>(optionBuilder =>
{
    optionBuilder.UseSqlServer(conntect);
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(

    option => option.Password.RequireDigit = true

    ).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<DeptRep,DeptRep>();
builder.Services.AddScoped<EmpRep,EmpRep>();
builder.Services.AddScoped<ProRep,ProRep>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acount}/{action=Login}/{id?}");

app.Run();
