using System.Text;
using BlazorServerDemo.Interfaces;
using BlazorServerDemo.Models;

namespace BlazorServerDemo.Data;

public class CountryService : ICountryService
{
    private List<Country>? _countries;
    
    public IEnumerable<Country> GetCountries()
    {
        return _countries ??= CreateCountryList();
    }

    private List<Country> CreateCountryList()
    {
        return new()
        {
            new()
            {
                Name = "Canada",
                Region = "Province",
                Provinces = provinces.Split(Environment.NewLine)
                    .Where(str => !string.IsNullOrWhiteSpace(str))
                    .Select(str => new Province(){Name = str.Trim()}).ToList()
            },
            new()
            {
                Name = "United States",
                Region = "State",
                Provinces = states.Split(Environment.NewLine)
                    .Where(str => !string.IsNullOrWhiteSpace(str))
                    .Select(str => new Province(){Name = str.Trim()}).ToList()
            }
        };
    }

    private string provinces = @"
        Alberta
        British Columbia
        Manitoba
        New Brunswick
        Newfoundland and Labrador
        Northwest Territories
        Nova Scotia
        Nunavut
        Ontario
        Prince Edward Island
        Quebec
        Saskatchewan
        Yukon
    ";

    private string states = @"
        Alabama
        Alaska
        Arizona
        Arkansas
        California
        Colorado
        Connecticut
        Delaware
        Florida
        Georgia
        Hawaii
        Idaho
        Illinois
        Indiana
        Iowa
        Kansas
        Kentucky
        Louisiana
        Maine
        Maryland
        Massachusetts
        Michigan
        Minnesota
        Mississippi
        Missouri
        Montana
        Nebraska
        Nevada
        New Hampshire
        New Jersey
        New Mexico
        New York
        North Carolina
        North Dakota
        Ohio
        Oklahoma
        Oregon
        Pennsylvania
        Rhode Island
        South Carolina
        South Dakota
        Tennessee
        Texas
        Utah
        Vermont
        Virginia
        Washington
        West Virginia
        Wisconsin
        Wyoming
    ";
}