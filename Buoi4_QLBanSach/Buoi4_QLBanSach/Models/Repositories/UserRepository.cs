using Microsoft.EntityFrameworkCore;

namespace Buoi4_QLBanSach.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QlsachContext _qlsachContext;
        public UserRepository(QlsachContext qlsachContext)
        {
            _qlsachContext = qlsachContext;
        }

        public void Add(User user)
        {
            _qlsachContext.Users.Add(user);
            _qlsachContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _qlsachContext.Users.Find(id);
            if(user != null)
            {
                _qlsachContext.Users.Remove(user);
                _qlsachContext.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            return _qlsachContext.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _qlsachContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            _qlsachContext.Users.Update(user);
            _qlsachContext.SaveChanges();
        }
    }
}
