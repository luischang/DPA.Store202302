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
        private readonly IJWTFactory _jwtFactory;

        public UserService(IUserRepository userRepository, IJWTFactory jwtFactory)
        {
            _userRepository = userRepository;
            _jwtFactory = jwtFactory;
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

        public async Task<UserReponseDTO> 
            SignIn(UserAuthDTO userAuthDTO)
        {
            var user = await _userRepository
                .SignIn(userAuthDTO.Email, userAuthDTO.Password);
            if (user == null) return null;

            var token = _jwtFactory.GenerateJWToken(user);

            var userDTO = new UserReponseDTO()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                UserType = user.Type == "U" ? "Usuario": "Admin",
                Token = token
            };
            return userDTO; 

        }


    }
}
