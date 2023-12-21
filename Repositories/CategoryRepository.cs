public interface ICategoryRepository
{
    IEnumerable<CategoryDTO> GetAllCategories();
    CategoryDTO? GetCategoryById(int id);
    void AddCategory(Category category);
    void UpdateCategory(int id, Category category);
    void DeleteCategory(int id);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly DataContext _context;

    public CategoryRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryDTO> GetAllCategories()
    {
        return _context.categories.ToList();
    }

    public CategoryDTO? GetCategoryById(int id)
    {
        return _context.categories.SingleOrDefault(x => x.id == id);
    }

    public void AddCategory(Category category)
    {
        CategoryDTO categoryToSave = new CategoryDTO
        {
            name = category.name,
            createdby = "DEV"
        };

        _context.categories.Add(categoryToSave);
        _context.SaveChanges();
    }

    public void UpdateCategory(int id, Category category)
    {
        CategoryDTO? categoryToUpdate = _context.categories.SingleOrDefault(category => category.id == id);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.name = category.name;
            categoryToUpdate.active = category.active;
            categoryToUpdate.modifieddate = DateTime.Now;
            categoryToUpdate.modifiedby = "DEV";

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Category not Found");
        }
    }

    public void DeleteCategory(int id)
    {
        CategoryDTO? categoryToRemove = _context.categories.SingleOrDefault(category => category.id == id && category.active == true);
        if (categoryToRemove != null)
        {
            _context.categories.Remove(categoryToRemove);

            _context.SaveChanges();
        }
        else
        {
            throw new ArgumentException("Category not Found");
        }
    }
}