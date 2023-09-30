using DPA.Store.DOMAIN.Core.Entities;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> IsEmailRegistered(string email);
        Task<User> SignIn(string email, string password);
        Task<bool> SignUp(User user);
    }
}