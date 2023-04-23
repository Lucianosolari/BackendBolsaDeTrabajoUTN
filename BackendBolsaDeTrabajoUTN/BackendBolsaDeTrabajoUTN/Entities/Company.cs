using BackendBolsaDeTrabajoUTNBackendBolsaDeTrabajoUTN.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Company : User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }

        [Required]
        public string CuitCompany { get; set; }

        [Required]
        public string NameCompany { get; set; }

        public string AddressCompany { get; set; }

        public int PhoneCompany { get; set; }

        public string EmailCompany { get; set; }

        public string WebPageCompany { get; set; }

         public string ContactPersonCompany { get; set; }

        public string TypeCompany { get; set; }

        public string StateCompany { get; set; }

        public string DocumentationCompany { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }


    }
}
