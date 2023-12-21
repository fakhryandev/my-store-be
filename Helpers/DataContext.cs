using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<CategoryDTO> categories { get; set; }
    public DbSet<ProductDTO> products { get; set; }
    public DbSet<ProductVariantDTO> productvariants { get; set; }
    public DbSet<UserDTO> users { get; set; }
}