using API.DL.Entities.idintity;
using GP.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DP.Servise
{
    public class TokenService : ITokenService
    {
        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task<string> CreateToken(AppUser appUser , UserManager<AppUser> userManager)
        {
            //Private Claim(user defined)
            var AuthClaim = new List<Claim>()
            {
                new Claim (ClaimTypes.Email , appUser.Email),
                //new Claim (ClaimTypes.MobilePhone , appUser.PhoneNumber
            };
            //var userRole = await userManager.GetRolesAsync(appUser)

            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
            // we use encode to convet string to array of byte
            var Token = new JwtSecurityToken(

               issuer: Configuration["JWT:Issuer"],// register Claims
               audience: Configuration["JWT:Audiance"],// register Claims
               expires: DateTime.Now.AddDays(Double.Parse(Configuration["JWT:ExpirationTime"])), // register Claims
               claims: AuthClaim,//private Claim
               signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature) // secretKey
               );

            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
    }
}
