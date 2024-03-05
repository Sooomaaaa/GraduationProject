using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Entites
{
    public class Alarm
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Appointment { get; set; }
    }
}
