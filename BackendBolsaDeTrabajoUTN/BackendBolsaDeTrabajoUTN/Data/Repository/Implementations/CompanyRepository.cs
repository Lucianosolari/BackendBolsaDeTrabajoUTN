
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.DBContexts;


namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
   public class CompanyRepository : ICompanyRepository
   {
        private readonly TPContext _context;
        public CompanyRepository(TPContext context)
        {
            _context = context;
        }


        public void CreateCompany(Company newCompany)
        {
            try
            {
                _context.Companies.Add(newCompany);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void RemoveCompany(int id)
        {
            try
            {
                var company = _context.Companies.FirstOrDefault(s => s.UserId == id);
                company.UserIsActive = false;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Empresa no encontrada");
            }
        }

        public void CreateOffer(Offer newOffer)
        {
            try
            {
                _context.Offers.Add(newOffer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }
        //public Company? GetSingleMeet(int id)
        //{
        //    try
        //    {
        //        return _context.Meets.First(x => x.Id == id);
        //    }
        //    catch
        //    {
        //        throw new Exception("Meet no encontrado");
        //    }
        //}

        //public List<Company> GetMeets()
        //{
        //    try
        //    {
        //        return _context.Meets.ToList();
        //    }
        //    catch
        //    {
        //        throw new Exception("No se pudo traer los meets");
        //    }
        //}

        //public void AddMeet(Company newMeet)
        //{
        //    try
        //    {
        //        _context.Meets.Add(newMeet);
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Error al añadir meet");
        //    }
        //}

        //public void RemoveMeet(int id)
        //{
        //    try
        //    {
        //        _context.Meets.Remove(_context.Meets.First(x => x.Id == id));
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Meet no encontrado");
        //    }
        //}

        //public void EditMeetDate(int id, string newMeetDate)
        //{
        //    try
        //    {
        //        _context.Meets.First(m => m.Id == id).MeetDate = newMeetDate;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Meet no encontrado o parámetros no válidos");
        //    }
        //}

        //public List<Offer> GetTrials(int id)
        //{
        //    return _context.Trials.Where(t => t.MeetId == id).ToList();
        //}
    }

}