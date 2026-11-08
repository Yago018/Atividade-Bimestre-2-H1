using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Teacher
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, Url]
    public string UrlLattes { get; set; } = string.Empty;

    [Range(typeof(DateTime), "1900-01-01", "2100-12-31")]
    public DateTime DataAdmissao { get; set; }
}