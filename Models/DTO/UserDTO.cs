using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class UserDTO : User
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