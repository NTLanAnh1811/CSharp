using System.Xml.Serialization;

namespace Buoi4_QLBanSach.Models.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category? GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
