using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class CategoryDTO : Category
{

    [Key]
    public int id { get; set; }
    [Column(TypeName = "timestamp without time zone")]
    public DateTime createddate { get; set; } = DateTime.Now;
    public required string createdby { get; set; }
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? modifieddate { get; set; }
    public string? modifiedby { get; set; }
}