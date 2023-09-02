using System.ComponentModel.DataAnnotations;

namespace Volunteering.Models
{
    public class Admin
    {
        [Key]
        public int Admin_ID { get; set; }
        [Required]
        public string Admin_Name { get; set;}
        [Required]
        [EmailAddress]
        public string Admin_Email { get; set;}
        [Required]
        public string Admin_Password { get; set; }
        [Required]
        [Range(14,14)]
        public string Admin_SSN { get; set; }


    }
}
