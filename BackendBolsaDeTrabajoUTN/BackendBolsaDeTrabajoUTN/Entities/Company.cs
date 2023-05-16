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

        // datos de la empresa

        public string CompanyName { get; set; } //razón social
        public string CompanyCUIT { get; set; }
        public string CompanyLine { get; set; } //rubro
        public string CompanyAddress { get; set; }
        public string CompanyLocation { get; set; }
        public string CompanyPostalCode { get; set; }
        public int CompanyPhone { get; set; }
        public string CompanyWebPage { get; set; }

        // datos de contacto
        public string CompanyPersonalName { get; set; }
        public string CompanyPersonalSurname { get; set; }
        public string CompanyPersonalJob { get; set; }
        public int CompanyPersonalPhone { get; set; }
        public string CompanyRelationContact { get; set; } //ver


        public bool CompanyPendingConfirmation { get; set; }

        //[ForeignKey("UserId")]
        //public User User { get; set; }
        //public int UserId { get; set; }

        public List<Offer> AnnouncedOffers { get; set; } = new List<Offer>();


    }
}
