namespace Domain.Models;

/// <summary>
/// Represents a post to a media website
/// </summary>
public class Post
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateModified { get; set; }
}