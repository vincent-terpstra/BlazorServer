using BlazorServerDemo.Data;
using BlazorServerDemo.Interfaces;
using DataAccess.AppDbContext;
using DataAccess.Services;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerDemo;

public static class ServicesExtensionMethods
{
    public static void RegisterDependancies(this IServiceCollection Services)
    {
        Services.AddScoped<IUserService, UserServiceDb>();
        Services.AddSingleton<ICountryService, CountryService>();

        Services.AddDbContext<AppDbContext>(
            opt => opt.UseInMemoryDatabase("InMem")
        );
    }
}