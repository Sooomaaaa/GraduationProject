using System.ComponentModel.DataAnnotations;

namespace GraduationProject.Dtos
{
    public class regiterDto
    {
        [Required]
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Gender { get; set; }
        [Phone]
        public string phoneNumber { get; set; }
        public string pictureUrl { get; set; }


    }
}
