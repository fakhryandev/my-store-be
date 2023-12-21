using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductVariantController : ControllerBase
{
    private readonly IProductVariantRepository _productVariantRepository;

    public ProductVariantController(IProductVariantRepository productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {

            var product = _productVariantRepository.GetAllProductVariants();

            return Ok(
                new
                {
                    success = true,
                    message = "Data retrieved successfully",
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
    public ActionResult<ProductVariantDTO> GetById(int id)
    {
        try
        {
            ProductVariant_REC? product = _productVariantRepository.GetProductVariantById(id);
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
                    message = "Data retrieved successfully",
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
    public ActionResult Post([FromBody] ProductVariant productVariant)
    {
        try
        {
            if (productVariant == null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Invalid category object"
                });
            }

            _productVariantRepository.AddProductVariant(productVariant);
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
    public ActionResult Put([FromBody] ProductVariant productVariant, int id)
    {
        try
        {
            if (productVariant == null)
            {
                return BadRequest("Invalid product object");
            }

            _productVariantRepository.UpdateProductVariant(id, productVariant);

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
            _productVariantRepository.DeleteProductVariant(id);

            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}