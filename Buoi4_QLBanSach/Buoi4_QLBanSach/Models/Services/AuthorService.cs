using Buoi4_QLBanSach.Models.Repositories;

namespace Buoi4_QLBanSach.Models.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public void AddAuthor(Author author)
        {
            _authorRepository.Add(author);
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }

        public List<Author> GetAllAuthor() => _authorRepository.GetAll();

        public Author? GetAuthorById(int id) => _authorRepository.GetById(id);

        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
    }
}
