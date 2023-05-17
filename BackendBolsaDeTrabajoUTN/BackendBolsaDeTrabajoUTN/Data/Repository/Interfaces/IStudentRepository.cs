using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IStudentRepository
    {
       
        public ICollection<Offer> GetOffers(int id);
        public void CreateStudent(Student newStudent);
        public void RemoveStudent(int id);
        public List<Student> GetStudents();
        //public Student? GetSingleSwimmer(int id);
        //public void AddSwimmer(Student swimmer);
        //public void RemoveSwimmer(int id);
        //public void EditSwimmerName(int id, string newName);
        //public void EditSwimmerSurname(int id, string surname);

        //List<Offer> GetExistingTrials();
        //public string GetAttendedTrial(int id);
    }
}
