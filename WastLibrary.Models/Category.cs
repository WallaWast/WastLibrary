using System.ComponentModel.DataAnnotations;

namespace WastLibrary.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Display Order")]
    [Range(1, 100, ErrorMessage ="Display Order must be between 1 and 100!")]
    public int DisplayOrder { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset UpdatedDateTime { get; set; } = DateTimeOffset.Now;
}

