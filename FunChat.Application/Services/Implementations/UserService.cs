using FunChat.Application.DTOs.Account;
using FunChat.Application.DTOs.Common;
using FunChat.Application.Extensions;
using FunChat.Application.Services.Interfaces;
using FunChat.Application.Services.Interfaces.Context;
using FunChat.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunChat.Application.Services.Implementations
{
    public class UserService:IUserService
    {
        #region Constructor

        private readonly IApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public UserService(IApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        #endregion
        public async Task<ApplicationResultDTO<string>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = new ApplicationResultDTO<string>
            {
                Status = ResultStatus.Success,
                Message = ResultStatus.Success.GetEnumName(),
                Data=""
                
            };


            if (await IsExistUserByEmail(registerUserDTO.Email))
            {
                result.Status = ResultStatus.EmailIsExist;
                result.Message = ResultStatus.EmailIsExist.GetEnumName();
                result.Data = registerUserDTO.Email;
            }



            return result;
        }

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }


    }
}
