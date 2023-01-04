namespace BlazorServerDemo.Models;

public class Province
{
    public string Name { get; init; }
    public Guid Id { get; } = Guid.NewGuid();
}