using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volunteering.Models
{
    public class Opportunity
    {
        [Key]
        public int Opp_ID { get; set; }

        [Required]
        public string Opp_Name { get; set; }
        [Required]
        public string Opp_Description { get; set; }
        [Required]
        public string Opp_Brief { get; set; }
        [Required]
        public string Opp_Published { get; set; }
        [Required]
        public string Opp_FormLink { get; set; }
        [Required]
        public DateTime Opp_Start { get; set; }
        [Required]
        public DateTime Opp_End { get; set; }
        [Required]
        public DateTime Opp_RegisterStart { get; set; }
        [Required]
        public DateTime Opp_RegisterEnd { get; set; }
        [Required]
        [DisplayName("Sector")]
        [ForeignKey("Sector")]
        public int Sector_ID { get; set; }
        public Sector? Sector { get; set; }
        public ICollection<Volunteer>? Volunteers { get; set; }

    }
}
