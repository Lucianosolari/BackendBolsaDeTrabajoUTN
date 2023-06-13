using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;
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


        public void CreateStudent(Student newStudent)
        {
            try
            {
                _context.Students.Add(newStudent);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void AddStudentAdressInfo(int id, AddStudentAdressInfoRequest newStudentAdressInfo)
        {
            try
            {
                // domicilio familiar
                _context.Students.First(s => s.UserId == id).FamilyStreet = newStudentAdressInfo.FamilyStreet;
                _context.Students.First(s => s.UserId == id).FamilyStreetNumber = newStudentAdressInfo.FamilyStreetNumber;
                _context.Students.First(s => s.UserId == id).FamilyStreetLetter = newStudentAdressInfo.FamilyStreetLetter;
                _context.Students.First(s => s.UserId == id).FamilyFloor = newStudentAdressInfo.FamilyFloor;
                _context.Students.First(s => s.UserId == id).FamilyDepartment = newStudentAdressInfo.FamilyDepartment;
                _context.Students.First(s => s.UserId == id).FamilyCountry = newStudentAdressInfo.FamilyCountry;
                _context.Students.First(s => s.UserId == id).FamilyProvince = newStudentAdressInfo.FamilyProvince;
                _context.Students.First(s => s.UserId == id).FamilyLocation = newStudentAdressInfo.FamilyLocation;
                _context.Students.First(s => s.UserId == id).FamilyPersonalPhone = newStudentAdressInfo.FamilyPersonalPhone;
                _context.Students.First(s => s.UserId == id).FamilyOtherPhone = newStudentAdressInfo.FamilyOtherPhone;

                // domicilio personal
                _context.Students.First(s => s.UserId == id).PersonalStreet = newStudentAdressInfo.PersonalStreet;
                _context.Students.First(s => s.UserId == id).PersonalStreetNumber = newStudentAdressInfo.PersonalStreetNumber;
                _context.Students.First(s => s.UserId == id).PersonalStreetLetter = newStudentAdressInfo.PersonalStreetLetter;
                _context.Students.First(s => s.UserId == id).PersonalFloor = newStudentAdressInfo.PersonalFloor;
                _context.Students.First(s => s.UserId == id).PersonalDepartment = newStudentAdressInfo.PersonalDepartment;
                _context.Students.First(s => s.UserId == id).PersonalCountry = newStudentAdressInfo.PersonalCountry;
                _context.Students.First(s => s.UserId == id).PersonalProvince = newStudentAdressInfo.PersonalProvince;
                _context.Students.First(s => s.UserId == id).PersonalLocation = newStudentAdressInfo.PersonalLocation;
                _context.Students.First(s => s.UserId == id).PersonalPersonalPhone = newStudentAdressInfo.PersonalPersonalPhone;
                _context.Students.First(s => s.UserId == id).PersonalOtherPhone = newStudentAdressInfo.PersonalOtherPhone;

                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Estudiante no encontrado o parámetros no válidos");
            }
        }

        public void AddStudentUniversityInfo(int id, AddStudentUniversityInfoRequest newStudentUniversityInfo)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.UserId == id);

                if (student != null)
                {
                    student.Specialty = newStudentUniversityInfo.Specialty;
                    student.ApprovedSubjectsQuantity = newStudentUniversityInfo.ApprovedSubjectsQuantity;
                    student.SpecialtyPlan = newStudentUniversityInfo.SpecialtyPlan;
                    student.CurrentStudyYear = newStudentUniversityInfo.CurrentStudyYear;
                    student.StudyTurn = newStudentUniversityInfo.StudyTurn;
                    student.AverageMarksWithPostponement = newStudentUniversityInfo.AverageMarksWithPostponement;
                    student.AverageMarksWithoutPostponement = newStudentUniversityInfo.AverageMarksWithoutPostponement;
                    student.CollegeDegree = newStudentUniversityInfo.CollegeDegree;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Estudiante no encontrado");
                }
            }
            catch
            {
                throw new Exception("Parámetros no válidos");
            }
        }

        public void UploadStudentCV(CVFile CV)
        {
            try
            {
                _context.CVFiles.Add(CV);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Problema al cargar el archivo");
            }
        }


        public void RemoveStudent(int id)
        {
            try
            {
                var student = _context.Students.FirstOrDefault(s => s.UserId == id);
                student.UserIsActive = false;
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Usuario no encontrado");
            }
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
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
