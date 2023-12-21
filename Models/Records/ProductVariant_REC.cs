public class ProductVariant_REC
{
    public int id { get; set; }
    public int product_id { get; set; }
    public string? code { get; set; }
    public string? name { get; set; }
    public int qty { get; set; }
    public int price { get; set; }
    public bool active { get; set; }
    public string? category_name { get; set; }
    public bool product_active { get; set; }
    public bool category_active { get; set; }
}