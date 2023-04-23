using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public int Distance { get; set; }
        public string Style { get; set; }

        public string MeetName { get; set; }

        // Cada trial va a pertenecer a un único meet
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        public int CompanytId { get; set; }

       // public List<Student> RegisteredSwimmers { get; set; } = new List<Student>();
    }
}
