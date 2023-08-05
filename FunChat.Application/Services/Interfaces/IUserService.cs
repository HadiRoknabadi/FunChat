using FunChat.Application.DTOs.Account;
using FunChat.Application.DTOs.Common;

namespace FunChat.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationResultDTO<string>> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<bool> IsExistUserByEmail(string email);
        Task<ApplicationResultDTO> ActivateAccount(string emailActiveCode);
        Task<ApplicationResultDTO> LoginUser(LoginUserDTO loginUserDTO);
        Task<ApplicationResultDTO> LogOutUser(bool isUserAuthenticated);
        Task<ApplicationResultDTO<EditUserProfileDTO>> GetUserProfileDetailsForEdit(int userId);
        Task<ApplicationResultDTO> EditUserProfile(EditUserProfileDTO editUserProfileDTO);
    }
}
