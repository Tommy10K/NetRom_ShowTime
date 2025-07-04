using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowTime.BusinessLogic.Abstractions;
using ShowTime.BusinessLogic.Dtos;
using ShowTime.DataAccess.Models;
using ShowTime.DataAccess.Repositories.Abstractions;

namespace ShowTime.BusinessLogic.Services
{
    public class UserService : IUserService 
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserGetDto?> LogInAsync(LogInDto dto)
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                var foundUser = users.FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);
                
                if (foundUser == null) return null;
                return new UserGetDto
                {
                    Id = foundUser.Id,
                    Email = foundUser.Email,
                    Role = foundUser.Role,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while logging in.", ex);
            }
        }

        public async Task<UserGetDto?> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null) return null;

                return new UserGetDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the user with ID {id}.", ex);
            }
        }

        public async Task<IList<UserGetDto>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userRepository.GetAllAsync();
                return users.Select(user => new UserGetDto 
                {

                    Id = user.Id,
                    Email = user.Email,
                    Role = user.Role,
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all users.", ex);
            }
        }

        public async Task AddUserAsync(UserCreateDto newUser)
        {
            try
            {
                var user = new User
                {
                    Email = newUser.Email,
                    Password = newUser.Password,
                    Role = newUser.Role
                };
                await _userRepository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        Task<UserGetDto> IUserService.GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
