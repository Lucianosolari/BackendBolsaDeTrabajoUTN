using BackendBolsaDeTrabajoUTN.Entities;


namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
   
    public interface ICompanyRepository
    {
        public void CreateCompany(Company newCompany);
        public void RemoveCompany(int id);
        //public Company? GetSingleMeet(int id);
        //public List<Company> GetMeets();
        //public void AddMeet(Company newMeet);
        //public void RemoveMeet(int id);
        //public void EditMeetDate(int id, string newMeetDate);
        //public List<Offer> GetTrials(int id);
    }
}
