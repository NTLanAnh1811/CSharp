namespace Buoi4_QLBanSach.Models.Services
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User? GetUserById(int id);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void AddUser(User user);
    }
}
