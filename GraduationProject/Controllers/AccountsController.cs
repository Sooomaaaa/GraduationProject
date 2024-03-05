using API.DL.Entities.idintity;
using GP.Core.Services;
using GraduationProject.Dtos;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace GraduationProject.Controllers
{
    public class AccountsController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountsController( UserManager<AppUser> userManager , SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppDto>> register(regiterDto regiterDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser()
            {
                Gender = regiterDto.Gender, 
                FirstName = regiterDto.firstName,
                LastName = regiterDto.lastName,
                Email = regiterDto.Email,
                PhoneNumber = regiterDto.phoneNumber,
                UserName = regiterDto.Email.Split("@")[0],
                PictureUrl=regiterDto.pictureUrl, // gener
            };
          
                var result = await _userManager.CreateAsync(user, regiterDto.Password);

                if (result.Succeeded)
                {
                    return Ok(new AppDto()
                    {

                        displayName = $"{user.FirstName} {user.LastName}",
                        Email = user.Email,
                        Token = await _tokenService.CreateToken(user, _userManager)
                    });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return BadRequest(ModelState);
                }
        }
        [HttpPost("Login")]
        public async Task<ActionResult<AppDto>> login (loginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if(user == null) return Unauthorized(new ApiRespond("User not Found"));
            

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiRespond("Password incorrect"));
            return Ok(new AppDto()
            {
                displayName = $"{user.FirstName} {user.LastName}", 
                Email = user.Email,
                Token = await _tokenService.CreateToken(user, _userManager)
            });
        }

    }
}
