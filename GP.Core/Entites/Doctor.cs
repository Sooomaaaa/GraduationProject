using API.DL.Entities.idintity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Entites
{
    public class Doctor : AppUser
    {
        public string? PatientId { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
