using BlazorServerDemo.Models;

namespace BlazorServerDemo.Interfaces;

public interface ICountryService
{
    public IEnumerable<Country> GetCountries();
}