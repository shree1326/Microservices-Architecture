using UserAPI.Models;

namespace UserAPI.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetUserList(int PageNumber, int PageSize, string order);
        public Task<IEnumerable<User>> GetUserById(int id);
        public Task<int> AddUser(User product);
        public Task<int> UpdateUser(User product);
        public Task<int> DeleteUser(int Id);
    }
}
