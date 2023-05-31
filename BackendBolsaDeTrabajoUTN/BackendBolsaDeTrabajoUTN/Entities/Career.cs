using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Career
    {
        //Las carreras serán creadas/actualizadas por el personal de administración.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CareerId { get; set; }
        public string CareerName { get; set; }
        public string CareerAbbreviation { get; set; }
        public string CareerType { get; set; }
        public int CareerTotalSubjects { get; set; }
        //Se puede agregar cualquier campo que se considere necesario.
        public ICollection<Student>? Students { get; set; } = new List<Student>();
        
    }
}
