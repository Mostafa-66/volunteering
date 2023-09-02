using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volunteering.Models
{
    public class Volunteer
    {
        [Key]
        public int Volun_ID { get; set; }
        [Required]
        public string Volun_First_Name { get; set; }
        [Required]
        public string Volun_Last_Name { get; set; }
        [Required]
        [EmailAddress]
        public string Volun_Email { get; set; }
        [Required]
        [Phone]
        public string Volun_Phone { get; set; }
        [Required]
        [DisplayName("Opportunity")]
        [ForeignKey("Opportunity")]
        public int Oppor_ID { get; set; }
        public Opportunity? Opportunity { get; set; }
    }
}
