public interface IProductRepository
{
    IEnumerable<ProductCategory_REC> GetAllProducts();
    ProductCategory_REC? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
}

public class ProductRepository : IProductRepository
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        ProductDTO productToSave = new ProductDTO
        {
            name = product.name,
            plu = product.plu,
            active = product.active,
            createdby = "DEV",
            category_id = product.category_id,
        };

        _context.products.Add(productToSave);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        ProductDTO? productToRemove = _context.products.SingleOrDefault(product => product.id == id && product.active == true);
        if (productToRemove != null)
        {
            productToRemove.active = false;
            productToRemove.modifieddate = DateTime.Now;
            productToRemove.modifiedby = "DEV";

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Product not found");
        }
    }

    public IEnumerable<ProductCategory_REC> GetAllProducts()
    {
        return _context.products
        .Join(
            _context.categories,
            product => product.category_id,
            category => category.id,
            (product, category) => new ProductCategory_REC
            {
                product_id = product.id,
                category_id = category.id,
                product_active = product.active,
                category_active = category.active,
                category_name = category.name,
                product_name = product.name,
                product_plu = product.plu,
            }
        )
        .Where(joinedData => joinedData.product_active == true && joinedData.category_active == true).ToList();
    }

    public ProductCategory_REC? GetProductById(int id)
    {
        return _context.products
        .Join(
            _context.categories,
            product => product.category_id,
            category => category.id,
            (product, category) => new ProductCategory_REC
            {
                product_id = product.id,
                category_id = category.id,
                product_active = product.active,
                category_active = category.active,
                category_name = category.name,
                product_name = product.name,
                product_plu = product.plu,
            }
        )
        .Where(joinedData => joinedData.product_active == true && joinedData.category_active == true && joinedData.product_id == id).SingleOrDefault();

    }

    public void UpdateProduct(int id, Product product)
    {
        ProductDTO? productToUpdate = _context.products.SingleOrDefault(product => product.id == id && product.active == true);
        if (productToUpdate != null)
        {
            productToUpdate.name = product.name;
            productToUpdate.plu = product.plu;
            productToUpdate.category_id = product.category_id;

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Product not found");
        }
    }
}