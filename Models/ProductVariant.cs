public class ProductVariant
{
    public required int product_id { get; set; }
    public required string code { get; set; }
    public required string name { get; set; }
    public required string image_location { get; set; }
    public int qty { get; set; }
    public int price { get; set; }
}