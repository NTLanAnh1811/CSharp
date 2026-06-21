using Microsoft.EntityFrameworkCore;

namespace Buoi4_QLBanSach.Models.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QlsachContext _qlsachContext;
        public CategoryRepository(QlsachContext qlsachContext)
        {
            _qlsachContext = qlsachContext;
        }

        public void Add(Category category)
        {
            _qlsachContext.Categories.Add(category);
            _qlsachContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = _qlsachContext.Categories
                .Include(c => c.Books).FirstOrDefault(c => c.Id == id);
            if(category != null) {
                category.Books.Clear();
                _qlsachContext.Categories.Remove(category);
                _qlsachContext.SaveChanges();
            }
        }

        public List<Category> GetAll()
        {
            return _qlsachContext.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _qlsachContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Category category)
        {
            _qlsachContext.Categories.Update(category);
            _qlsachContext.SaveChanges();
        }
    }
}
