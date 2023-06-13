using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class StudentOfferRepository : IStudentOfferRepository
    {
        private readonly TPContext _context;
        public StudentOfferRepository(TPContext context)
        {
            _context = context;
        }

        public void AddStudentToOffer(int offerId, int studentId)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.OfferId == offerId);
            var student = _context.Students.FirstOrDefault(s => s.UserId == studentId);

            if (offer == null || student == null)
            {
                throw new Exception("No existe la oferta o el estudiante");
            }

            var isAssociated = _context.StudentOffers.Any(os => os.StudentId == student.UserId && os.OfferId == offerId);
            if (isAssociated)
            {
                throw new Exception("El estudiante ya está asociado a esta oferta.");
            }

            offer.Students.Add(student);
            _context.SaveChanges();
        }



        public List<Offer> GetStudentToOffers(int studentId)
        {
            var offers = _context.StudentOffers
                .Where(so => so.StudentId == studentId)
                .Select(so => new Offer
                {
                    OfferId = so.Offer.OfferId,
                    OfferTitle = so.Offer.OfferTitle,
                    OfferSpecialty = so.Offer.OfferSpecialty,
                    OfferDescription = so.Offer.OfferDescription,
                    CreatedDate = so.Offer.CreatedDate,
                    Company = new Company
                    {
                        CompanyName = so.Offer.Company.CompanyName,
                        CompanyLocation = so.Offer.Company.CompanyLocation,
                        CompanyLine = so.Offer.Company.CompanyLine
                    },
                })
                .ToList();

            return offers;
        }



    }
}
