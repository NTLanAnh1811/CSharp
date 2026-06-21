using Buoi4_QLBanSach.Models.Repositories;

namespace Buoi4_QLBanSach.Models.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void DeleteUser(int id) => _userRepository.Delete(id);

        public List<User> GetAllUser() => _userRepository.GetAll();

        public User? GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }
    }
}
