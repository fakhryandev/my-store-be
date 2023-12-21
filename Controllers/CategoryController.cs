using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public ActionResult Get()
    {
        try
        {
            IEnumerable<CategoryDTO> categories = _categoryRepository.GetAllCategories();
            return Ok(
                new
                {
                    success = true,
                    message = "Data berhasil diambil",
                    data = categories
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
    public ActionResult<CategoryDTO> GetById(int id)
    {
        try
        {
            CategoryDTO? category = _categoryRepository.GetCategoryById(id);
            if (category == null)
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
                    data = category
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

    [HttpPost]
    public ActionResult Post([FromBody] Category category)
    {
        try
        {
            if (category == null)
            {
                return StatusCode(400, new
                {
                    success = false,
                    message = "Invalid category object"
                });
            }

            _categoryRepository.AddCategory(category);
            var response = new
            {
                status = true,
                message = "Kategori berhasil dibuat",
            };
            return CreatedAtAction(null, response);
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
    public ActionResult Put([FromBody] Category category, int id)
    {
        try
        {
            if (category == null)
            {
                return BadRequest("Invalid category object");
            }

            _categoryRepository.UpdateCategory(id, category);

            var response = new
            {
                status = true,
                message = "Kategori berhasil diupdate",
            };
            return Ok(response);
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
            _categoryRepository.DeleteCategory(id);
            var response = new
            {
                status = true,
                message = "Kategori berhasil dihapus",
            };

            return Ok(response);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}