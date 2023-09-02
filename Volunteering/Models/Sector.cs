using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volunteering.Models
{
    public class Sector
    {
        [Key]
        public int Sec_ID { get; set; }
        [Required]
        public string Sec_Name { get; set; }
        public ICollection<Opportunity>? Opportunities { get; set; }

    }
}
