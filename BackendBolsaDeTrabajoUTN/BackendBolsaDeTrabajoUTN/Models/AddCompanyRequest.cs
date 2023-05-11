using BackendBolsaDeTrabajoUTN.Entities;



namespace BackendBolsaDeTrabajoUTN.Models
{
    public class AddCompanyRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyCUIT { get; set; }
        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public int CompanyPhone { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyWebPage { get; set; }

        public string CompanyContactPerson { get; set; }

        public string CompanyType { get; set; }

        public string CompanyState { get; set; }

        public string CompanyDocumentation { get; set; }
    }
}
