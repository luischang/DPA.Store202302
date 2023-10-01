using DPA.Store.DOMAIN.Core.DTO;

namespace DPA.Store.DOMAIN.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> SignUp(UserRegisterDTO userDTO);
        Task<UserReponseDTO>SignIn(UserAuthDTO userAuthDTO);
    }
}