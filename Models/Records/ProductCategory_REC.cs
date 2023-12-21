public class ProductCategory_REC
{
    public int category_id { get; set; }
    public int product_id { get; set; }
    public bool product_active { get; set; }
    public bool category_active { get; set; }
    public string? category_name { get; set; }
    public string? product_name { get; set; }
    public string? product_plu { get; set; }
}