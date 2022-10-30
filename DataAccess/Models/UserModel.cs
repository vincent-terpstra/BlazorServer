// ReSharper disable InconsistentNaming

using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class UserModel
{
    public int id { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "First Name is too long")]
    [MinLength(5, ErrorMessage = "First Name is too short")]
    public string firstname { get; set; }

    [Required]
    [MaxLength(15, ErrorMessage = "Last Name is too long")]
    [MinLength(5, ErrorMessage = "Last Name is too short")]
    public string lastname { get; set; }
    
    [Required]
    [EmailAddress]
    public string email { get; set; }

}