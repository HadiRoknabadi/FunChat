using AutoMapper;
using FunChat.Application.DTOs.Account;
using FunChat.Application.DTOs.Common;
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

        public UserService(IApplicationDbContext context, UserManager<User> userManager, IMapper mapper, IViewRenderService viewRenderSerivce, ISenderService senderService)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _viewRenderSerivce = viewRenderSerivce;
            _senderService = senderService;
        }





        #endregion



        public async Task<ApplicationResultDTO<string>> RegisterUser(RegisterUserDTO registerUserDTO)
        {
            var result = new ApplicationResultDTO<string>
            {
                Status = ResultStatus.Success,
                StatusMessage = "عملیات با موفقیت انجام شد"
                
            };


            // if (await IsExistUserByEmail(registerUserDTO.Email))
            // {
            //     result.Status = ResultStatus.EmailIsExist;
            //     //result.Message = ResultStatus.EmailIsExist.GetEnumName();
            //     result.Data = registerUserDTO.Email;

            //     return result;

            // }


            var user=_mapper.Map<RegisterUserDTO,User>(registerUserDTO);

            var createUserResult = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if(createUserResult.Succeeded==false)
            {
                result.Status = ResultStatus.IdentityError;
                //result.Message = ResultStatus.IdentityError.GetEnumName();
                var identityErrors = createUserResult.Errors.ToList();
        
                foreach (var error in identityErrors)
                {
                    result.ErrorMessages.Add(error.Description.Replace("\"", ""));
                }

                return result;
            }

            var emailActivation=_mapper.Map<User,EmailActivationDTO>(user);

            string emailBody=_viewRenderSerivce.RenderToStringAsync("_ActivateAccount",emailActivation);

            _senderService.SendEmail(user.Email,"فعالسازی حساب",emailBody);

            return result;
        }

        public async Task<bool> IsExistUserByEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }


    }
}
