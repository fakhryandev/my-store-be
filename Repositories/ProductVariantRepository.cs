public interface IProductVariantRepository
{
    IEnumerable<ProductVariant_REC> GetAllProductVariants();
    ProductVariant_REC? GetProductVariantById(int id);
    void AddProductVariant(ProductVariant productVariant);
    void UpdateProductVariant(int id, ProductVariant productVariant);
    void DeleteProductVariant(int id);
}

public class ProductVariantRepository : IProductVariantRepository
{
    private readonly DataContext _context;

    public ProductVariantRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<ProductVariant_REC> GetAllProductVariants()
    {
        return _context.productvariants
        .Join(_context.products,
        productVariant => productVariant.product_id,
        product => product.id,
        (productVariant, product) => new
        {
            Product = product,
            ProductVariant = productVariant
        }).Join(_context.categories,
        joinedData => joinedData.Product.category_id,
        category => category.id,
        (joinedData, category) => new ProductVariant_REC
        {
            id = joinedData.ProductVariant.id,
            product_id = joinedData.Product.id,
            code = joinedData.ProductVariant.code,
            name = joinedData.ProductVariant.name,
            qty = joinedData.ProductVariant.qty,
            price = joinedData.ProductVariant.price,
            active = joinedData.ProductVariant.active,
            product_active = joinedData.Product.active,
            category_active = category.active,
            category_name = category.name,
        }
        ).Where(
            joinedData => joinedData.category_active == true
            && joinedData.active == true
            && joinedData.product_active == true
        ).ToList();
    }

    public ProductVariant_REC? GetProductVariantById(int id)
    {
        return _context.productvariants
        .Join(_context.products,
        productVariant => productVariant.product_id,
        product => product.id,
        (productVariant, product) => new
        {
            Product = product,
            ProductVariant = productVariant
        }).Join(_context.categories,
        joinedData => joinedData.Product.category_id,
        category => category.id,
        (joinedData, category) => new ProductVariant_REC
        {
            id = joinedData.ProductVariant.id,
            product_id = joinedData.Product.id,
            code = joinedData.ProductVariant.code,
            name = joinedData.ProductVariant.name,
            qty = joinedData.ProductVariant.qty,
            price = joinedData.ProductVariant.price,
            active = joinedData.ProductVariant.active,
            product_active = joinedData.Product.active,
            category_active = category.active,
            category_name = category.name,
        }
        ).Where(
            joinedData => joinedData.category_active == true
            && joinedData.active == true
            && joinedData.product_active == true
            && joinedData.id == id
        ).SingleOrDefault();
    }

    public void AddProductVariant(ProductVariant productVariant)
    {
        ProductVariantDTO productVariantToSave = new ProductVariantDTO
        {
            name = productVariant.name,
            code = productVariant.code,
            product_id = productVariant.product_id,
            image_location = productVariant.image_location,
            qty = productVariant.qty,
            price = productVariant.price,
            createdby = "DEV",
        };

        _context.productvariants.Add(productVariantToSave);
        _context.SaveChanges();
    }

    public void UpdateProductVariant(int id, ProductVariant productVariant)
    {
        ProductVariantDTO? productVariantToUpdate = _context.productvariants.SingleOrDefault(productVariant => productVariant.id == id && productVariant.active == true);
        if (productVariantToUpdate != null)
        {
            productVariantToUpdate.name = productVariant.name;
            productVariantToUpdate.code = productVariant.code;
            productVariantToUpdate.product_id = productVariant.product_id;
            productVariantToUpdate.image_location = productVariant.image_location;
            productVariantToUpdate.qty = productVariant.qty;
            productVariantToUpdate.price = productVariant.price;

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Product Variant not found");
        }
    }

    public void DeleteProductVariant(int id)
    {
        ProductVariantDTO? productVariantToRemove = _context.productvariants.SingleOrDefault(productVariant => productVariant.id == id && productVariant.active == true);
        if (productVariantToRemove != null)
        {
            productVariantToRemove.active = false;
            productVariantToRemove.modifieddate = DateTime.Now;
            productVariantToRemove.modifiedby = "DEV";

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Product Variant not found");
        }
    }
}