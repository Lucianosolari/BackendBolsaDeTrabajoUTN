using BackendBolsaDeTrabajoUTN.Entities;


namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
   
    public interface ICompanyRepository
    {
        public void CreateCompany(Company newCompany);
        public void RemoveCompany(int id);
        //public void CreateOffer(Offer offer);
        public void CreateOffer(Offer newOffer);
    }
}
