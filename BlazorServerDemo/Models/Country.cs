using Microsoft.EntityFrameworkCore.Storage;

namespace BlazorServerDemo.Models;

public class Country
{
    public string Name { get; init; }

    public Guid Id { get; } = Guid.NewGuid();
    public List<Province> Provinces { get; init; } = new();

}