using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Career
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareerId { get; set; }

        public ICollection<Student>? Students { get; set; } = new List<Student>();
        
    }
}
