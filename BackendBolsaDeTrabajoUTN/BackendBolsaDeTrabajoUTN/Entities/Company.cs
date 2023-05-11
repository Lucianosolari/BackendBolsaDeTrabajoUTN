using BackendBolsaDeTrabajoUTN.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendBolsaDeTrabajoUTN.Entities
{
    public class Company : User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int CompanyId { get; set; }

        //[Required]
        public string CompanyCUIT { get; set; }

        //[Required]
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public int CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyWebPage { get; set; }

         public string CompanyContactPerson { get; set; }

        public string CompanyType { get; set; }

        public string CompanyState { get; set; }

        public string CompanyDocumentation { get; set; }

       
        public List<Offer> AnnouncedOffers { get; set; } = new List<Offer>();


    }
}
