using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository
{
    public class OfferRepository : IOfferRepository
    {
        
        private readonly TPContext _context;
        public OfferRepository(TPContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Offer>> GetOffersByCompany(int companyId)
        {
            try
            {
                return _context.Offers.Where(o => o.CompanyId == companyId).ToList();
            }
            catch
            {
                throw new Exception("La empresa no tiene ofertas");
            }
        }


        public ActionResult<IEnumerable<Offer>> GetOffers()
        {
            try
            {
                return _context.Offers.Include(o => o.Company).ToList();
            }
            catch
            {
                throw new Exception("No se encontraron ofertas");
            }
        }
    }
}