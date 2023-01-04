using BlazorServerDemo.Data;
using BlazorServerDemo.Interfaces;
using DataAccess;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IUserService, UserServiceDb>();
builder.Services.AddSingleton<ICountryService, CountryService>();

builder.Services.AddDbContext<AppDbContext>(
    opt => opt.UseInMemoryDatabase("InMem")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var users = scope.ServiceProvider.GetRequiredService<IUserService>();
    users.PopulateDbUsers();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();