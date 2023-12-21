using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {

            var product = _productRepository.GetAllProducts();

            return Ok(
                new
                {
                    success = true,
                    message = "Data berhasil diambil",
                    data = product
                }
            );
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal Server Error:  {ex.Message}",
                data = (object?)null
            });
        }
    }

    [HttpGet("{id}")]
    public ActionResult<ProductCategory_REC> GetById(int id)
    {
        try
        {
            ProductCategory_REC? product = _productRepository.GetProductById(id);
            if (product == null)
            {
                return NotFound(new
                {
                    success = false,
                    message = "Data tidak ditemukan",
                    data = (object?)null
                });
            }
            return Ok(
                new
                {
                    success = true,
                    message = "Data berhasil diambil",
                    data = product
                }
            );
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal Server Error: {ex.Message}",
                data = (object?)null
            });
        }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Product product)
    {
        try
        {
            if (product == null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Invalid category object"
                });
            }

            _productRepository.AddProduct(product);
            return Created();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                success = false,
                message = $"Internal Server Error:  {ex.Message}",
            });
        }
    }

    [HttpPut("{id}")]
    public ActionResult Put([FromBody] Product product, int id)
    {
        try
        {
            if (product == null)
            {
                return BadRequest("Invalid product object");
            }

            _productRepository.UpdateProduct(id, product);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            _productRepository.DeleteProduct(id);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}