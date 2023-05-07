using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class StudentOfferRepository : IStudentOfferRepository
    {
        private readonly TPContext _context;
        public StudentOfferRepository(TPContext context)
        {
            _context = context;
        }

        public async void AddStudentToOffer(int offerId, int studentId)
        {
            var offer = await _context.Offers.FindAsync(offerId);
            var student = await _context.Students.FindAsync(studentId);

            if (offer == null || student == null)
            {
                throw new Exception("No existe la oferta o el estudiante");
            }

            if (offer.Students.Any(s => s.UserId == student.UserId))
            {
                throw new Exception("El estudiante ya esta asociado a esta oferta.");
            }

            offer.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public List<Offer> GetStudentToOffers(int studentId)
        {
            var offers = _context.StudentOffers
                .Where(so => so.StudentId == studentId)
                .Select(so => so.Offer)
                .ToList();

            return offers;
        }


    }
}
