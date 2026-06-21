using Buoi4_QLBanSach.Models.Repositories;

namespace Buoi4_QLBanSach.Models.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void AddCategory(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void DeleteCategory(int id) => _categoryRepository.Delete(id);

        public List<Category> GetAllCategory() => _categoryRepository.GetAll();

        public Category? GetCategoryById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }
    }
}
