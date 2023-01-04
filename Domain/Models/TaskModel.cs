namespace Domain.Models;

public class TaskModel
{
    public string Task { get; set; } = String.Empty;
    public bool IsComplete { get; set; } = false;
}