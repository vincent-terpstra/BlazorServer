using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class PersonModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "First Name is too long")]
    [MinLength(5, ErrorMessage = "First Name is too short")]
    public string Firstname { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "Last Name is too long")]
    [MinLength(5, ErrorMessage = "Last Name is too short")]
    public string Lastname { get; set; }
    
    [Required]
    [EmailAddress]
    public string Email { get; set; }


    public string FullName => $"{Firstname} {Lastname}";

}