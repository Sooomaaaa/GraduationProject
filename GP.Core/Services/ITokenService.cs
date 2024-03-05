using API.DL.Entities.idintity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser appUser , UserManager<AppUser> userManager);
    }
}
