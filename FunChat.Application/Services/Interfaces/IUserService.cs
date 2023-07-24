using FunChat.Application.DTOs.Account;
using FunChat.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunChat.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationResultDTO<string>> RegisterUser(RegisterUserDTO registerUserDTO);
        Task<bool> IsExistUserByEmail(string email);
    }
}
