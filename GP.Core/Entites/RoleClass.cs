using System.Runtime.Serialization;

namespace GraduationProject.Helper
{
    public class RoleClass
    {
        public enum Roles
        {
            [EnumMember(Value = "Doctor")] // to store in Database as Panding not 0
            Doctor,
            [EnumMember(Value = "Patient")] // to store in Database as Payment Received not 1
            Patient,
            [EnumMember(Value = "Admin")] // to store in Batabase as Payment Failed not 2
            Admin
        }
    }
}
