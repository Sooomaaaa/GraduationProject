
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace API.DL.Entities.idintity
{
    public class AppUser :IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Gender  { get; set; }
        public string PictureUrl  { get; set; }
        
 
    }

   
}
