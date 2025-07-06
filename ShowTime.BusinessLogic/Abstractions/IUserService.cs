using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Abstractions
{
    public interface IUserService
    {
        Task<UserGetDto?> LogInAsync(LogInDto dto);
        Task<UserGetDto?> GetUserByIdAsync(int userId);
        Task<IList<UserGetDto>> GetAllUsersAsync();
        Task AddUserAsync(UserCreateDto newUser);
        Task DeleteUserAsync(int id);
    }
}
