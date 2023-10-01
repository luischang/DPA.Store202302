using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.Store.DOMAIN.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> SignUp(UserRegisterDTO userDTO)
        {
            var existsUser = await _userRepository
                            .IsEmailRegistered(userDTO.Email);
            if (existsUser) return false;

            var user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Address = userDTO.Address,
                Country = userDTO.Country,
                DateOfBirth = userDTO.DateOfBirth,
                Password = userDTO.Password,
                IsActive = true,
                Type = "U"
            };

            var result = await _userRepository
                            .SignUp(user);
            return result;

        }


    }
}
