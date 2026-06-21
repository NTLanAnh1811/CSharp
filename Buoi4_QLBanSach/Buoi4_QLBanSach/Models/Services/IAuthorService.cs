namespace Buoi4_QLBanSach.Models.Services
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthor();
        Author? GetAuthorById(int id);
        void AddAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(int id);
    }
}
