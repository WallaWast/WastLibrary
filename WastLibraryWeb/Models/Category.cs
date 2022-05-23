using System.ComponentModel.DataAnnotations;

namespace WastLibraryWeb.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset UpdatedDateTime { get; set; } = DateTimeOffset.Now;
}

