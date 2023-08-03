using System.Security.Claims;
using System.Security.Principal;
using AutoMapper;
using FunChat.Application.DTOs.Account;
using FunChat.Application.DTOs.Common;
using FunChat.Application.Extensions;
using FunChat.Application.Services.Interfaces;
using FunChat.Application.Services.Interfaces.Context;
using FunChat.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FunChat.Application.Services.Implementations
{
    public class UserService:IUserService
    {
        #region Constructor

        private readonly IApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IViewRenderService _viewRenderSerivce;
        private readonly ISenderService _senderService;
        private readonly SignInManager<User> _signInManager;

        public UserService(IApplicationDbContext context, UserManager<User> userManager, IMapper mapper, IViewRenderService viewRenderSerivce, ISenderService senderService, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _viewRenderSerivce = viewRenderSerivce;
            _senderService = senderService;
            _signInManager = signInManager;
        }






        #endregion


        #region Register User
        public async Task<ApplicationResultDTO<string>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = new ApplicationResultDTO<string>
            {
                Status = ResultStatus.Success,
  
            };

            var user=_mapper.Map<RegisterUserDTO,User>(registerUserDTO);

            var createUserResult = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if(createUserResult.Succeeded==false)
            {
                result.Status = ResultStatus.IdentityError;
                createUserResult.GetIdentityErrorMessages(result.ErrorMessages);

                return result;
            }

            var emailActivation=_mapper.Map<User,EmailActivationDTO>(user);

            string emailBody=_viewRenderSerivce.RenderToStringAsync("_ActivateAccount",emailActivation);

            _senderService.SendEmail(user.Email,"فعالسازی حساب",emailBody);

            return result;
        }

        #endregion

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<ApplicationResultDTO> ActivateAccount(string emailActiveCode)
        {
            var result=new ApplicationResultDTO();
            var user=await _context.Users.SingleOrDefaultAsync(u=>u.EmailActiveCode==emailActiveCode);

            if(user==null)
            {
                result.Status=ResultStatus.NotFound;
                result.ErrorMessages.Add("کاربری یافت نشد");

                return result;
            }

            user.EmailConfirmed=true;
            user.EmailActiveCode=Generators.Generators.GetEmailActivationCode();

            await _context.SaveChangesAsync();


            await _signInManager.SignInAsync(user,true);

            return result; 


        }

        #region Login User

        public async Task<ApplicationResultDTO> LoginUser(LoginUserDTO loginUserDTO)
        {
            var result=new ApplicationResultDTO();

            var user=await _userManager.FindByEmailAsync(loginUserDTO.Email);

            if(user==null)
            {
                result.Status=ResultStatus.NotFound;
                result.ErrorMessages.Add("کاربری با این مشخصات یافت نشد");
                return result;
            }

            if(user.EmailConfirmed==false)
            {
                result.Status=ResultStatus.AccountNotActivated;
                result.ErrorMessages.Add("حساب شما فعال سازی نشده است");
                return result;
            }
            
            await _signInManager.SignInAsync(user,loginUserDTO.RememberMe);

            return result;

        }

        public async Task<ApplicationResultDTO> LogOutUser(bool isUserAuthenticated)
        {
            var result=new ApplicationResultDTO();

            if(isUserAuthenticated==false)
            {
                
                return result;
            }

            await _signInManager.SignOutAsync();

            return result;
        }


        #endregion
    }
}
