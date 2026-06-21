using System.Xml.Serialization;

namespace Buoi4_QLBanSach.Models.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        Category? GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}
