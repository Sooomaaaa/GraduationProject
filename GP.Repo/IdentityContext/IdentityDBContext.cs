using API.DL.Entities.idintity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Repo.IdentityContext
{
    public class IdentityDBContext : IdentityDbContext<AppUser>
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options):base(options)
        {
                
        }
    }
}
