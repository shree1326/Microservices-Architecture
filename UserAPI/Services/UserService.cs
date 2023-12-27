using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using UserAPI.Data;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserService : IUserService
    {
        private readonly DbContextClass _dbContext;

        public UserService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddUser(User user)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UserName", user.UserName));
            parameter.Add(new SqlParameter("@Address", user.Address));

            var result = await Task.Run(() => _dbContext.Database.ExecuteSqlRawAsync(@"exec AddNewUser @UserName, @Address", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteUser(int Id)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteUserByID {Id}"));
        }

        public async Task<IEnumerable<User>> GetUserById(int id)
        {
            var param = new SqlParameter("@UserId", id);
            var userdetails = await Task.Run(() => _dbContext.Users
            .FromSqlRaw(@"exec GetUserByID @UserId", param).ToListAsync());
            return userdetails;
        }

        public async Task<List<User>> GetUserList(int PageNumber, int PageSize, string order)
        {
            string sql = "exec Usp_GetAllUser @PageNo, @PageSize, @SortOrder";
            List<SqlParameter> parms = new List<SqlParameter>
            {
                new SqlParameter{ ParameterName = "@PageNo", Value = PageNumber},
                new SqlParameter{ ParameterName = "@PageSize", Value = PageSize},
                new SqlParameter{ ParameterName = "@SortOrder", Value = order}
            };
            return await Task.Run(() => _dbContext.Users.FromSqlRaw(sql, parms.ToArray()).ToListAsync());
        }
        public async Task<int> UpdateUser(User user)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@UserId", user.UserId));
            parameter.Add(new SqlParameter("@UserName", user.UserName));
            parameter.Add(new SqlParameter("@Address", user.Address));

            var result = await Task.Run(() => _dbContext.Database.ExecuteSqlRawAsync(@"exec UpdateUser  @UserId,@UserName, @Address", parameter.ToArray()));
            return result;
        }
    }
}