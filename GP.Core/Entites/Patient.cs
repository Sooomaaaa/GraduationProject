using API.DL.Entities.idintity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Entites
{
    public class Patient :AppUser
    {
        public double HeartRate { get; set; }
        public double OxigynRate { get; set; }
        public string DoctorId { get; set; }
        public Doctor Doctors { get; set; }
    }
}
