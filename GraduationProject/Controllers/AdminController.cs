using API.DL.Entities.idintity;
using AutoMapper;
using DP.Servise;
using GP.Core.Entites;
using GP.Core.IRepository;
using GP.Core.Services;
using GP.Repo.IdentityContext;
using GraduationProject.Dtos;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase 
    {

        public AdminController(IGenericRepository<AppUser> DocRepo, UserManager<AppUser> userManager,ITokenService tokenService)
        {
            _DocRepo = DocRepo;
            UserManager = userManager;
            TokenService = tokenService;
        }

        public IGenericRepository<AppUser> _DocRepo { get; }
        public UserManager<AppUser> UserManager { get; }
        public ITokenService TokenService { get; }
       

        [HttpPost]
        public async Task<ActionResult<AppDto>> AddDoctor(regiterDto regiter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Doctor()
            {
                
                Gender = regiter.Gender,
                FirstName = regiter.firstName,
                LastName = regiter.lastName,
                Email = regiter.Email,
                PhoneNumber = regiter.phoneNumber,
                UserName = regiter.Email.Split("@")[0]

            };
            var result = await UserManager.CreateAsync(user, regiter.Password);

            if (result.Succeeded)
            {
                await _DocRepo.Create(user);
                return Ok(new AppDto()
                {

                    displayName = $"{user.FirstName} {user.LastName}",
                    Email = user.Email,
                    Token = await TokenService.CreateToken(user, UserManager)
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
    }

}

