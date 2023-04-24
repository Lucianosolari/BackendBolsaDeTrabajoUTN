using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Helpers;
using BackendBolsaDeTrabajoUTN.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly TPContext _context;
        public StudentRepository(TPContext context)
        {
            _context = context;
        }

        public ICollection<Offer> GetOffers(int id)
        {
            return _context.Students.Include(a => a.Offers).Where(a => a.UserId == id).Select(a => a.Offers).FirstOrDefault() ?? new List<Offer>();
        }

        public Student? ValidateUser(AuthenticationRequestBody dto)
        {
            var HashPassword = Security.CreateSHA512(dto.Password);
            return _context.Students.SingleOrDefault(u => u.UserName == dto.UserName && u.Password == Security.CreateSHA512(dto.Password));
        }

        //public Student? GetSingleSwimmer(int id)
        //{
        //    try
        //    {
        //        return _context.Swimmers.First(x => x.Id == id);
        //    }
        //    catch
        //    {
        //        throw new Exception("Nadador no encontrado");
        //    }
        //}

        //public void AddSwimmer(Student swimmer)
        //{
        //    try
        //    {
        //        _context.Swimmers.Add(swimmer);
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Error al añadir nadador");
        //    }
        //}

        //public void RemoveSwimmer(int id)
        //{
        //    try
        //    {
        //        _context.Swimmers.Remove(_context.Swimmers.First(x => x.Id == id));
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Nadador no encontrado");
        //    }
        //}

        //public void EditSwimmerName(int id, string newName)
        //{
        //    try
        //    {
        //            _context.Swimmers.First(x => x.Id == id).Name = newName;
        //            _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Nadador no encontrado o parámetros no válidos");
        //    }
        //}
        //public void EditSwimmerSurname(int id, string newSurname)
        //{
        //    try
        //    {
        //        _context.Swimmers.First(x => x.Id == id).Surname = newSurname;
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        throw new Exception("Nadador no encontrado o parámetros no válidos");
        //    }
        //}

        //public List<Offer> GetExistingTrials()
        //{
        //    return _context.Trials.ToList();
        //}

        //public string GetAttendedTrial(int id)
        //{
        //    var style = _context.Trials.First(t => t.Id == id).Style;
        //    var distance = _context.Trials.First(t => t.Id == id).Distance;
        //    var meetName = _context.Trials.First(t => t.Id == id).MeetName;

        //    var attendedTrial = style + " " + distance + " metros" + " (" + meetName + ")";
        //    return attendedTrial;
        //}
    }
}
