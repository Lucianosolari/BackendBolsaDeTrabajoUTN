using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Helpers;
using BackendBolsaDeTrabajoUTN.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TPContext _context;
        public AdminRepository(TPContext context)
        {
            _context = context;
        }

        public void CreateCareer(Career newCareer)
        {
            try
            {
                _context.Careers.Add(newCareer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }
    }
}
