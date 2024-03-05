using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GraduationProject.Helper
{
    public class ApiRespond
    {
        public string Error { get; set; }
        public ApiRespond(string error)
        {
            Error = error;
        }
    }
}
