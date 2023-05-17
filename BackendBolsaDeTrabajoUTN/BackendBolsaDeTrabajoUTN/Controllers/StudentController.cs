// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using System.Security.AccessControl;


namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {

        private readonly IStudentOfferRepository _studentOfferRepository;
        
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentOfferRepository studentOfferRepository, IStudentRepository studentRepository)
        {

            _studentOfferRepository = studentOfferRepository;
            
            _studentRepository = studentRepository;
        }

        [HttpPost]
        [Route("createStudent")]
        public IActionResult CreateStudent(AddStudentRequest request)
        {

                try
                {
                List<Student> students = _studentRepository.GetStudents();
                ValidateDNI(students, request.DocumentNumber);
                ValidateFile(students, request.File);
                ValidateUserName(students, request.UserName);

                Student newStudent = new()
                {
                        UserName = request.UserName,
                        Password = request.Password,                       
                        File = request.File,
                        Name = request.Name,
                        Surname = request.Surname,
                        UserEmail = request.UserEmail,
                        AltEmail = request.AltEmail,
                        DocumentType = request.DocumentType,
                        DocumentNumber = request.DocumentNumber,
                        CUIL_CUIT = request.CUIL_CUIT,
                        Birth = request.Birth,
                        Sex = request.Sex,
                        CivilStatus = request.CivilStatus,
                       
                    };
                    StudentResponse response = new()
                    {
                        File = newStudent.File,
                        Name = newStudent.Name,
                        Surname = newStudent.Surname,

                    };
                    _studentRepository.CreateStudent(newStudent);
                    return Created("Estudiante creado", response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
           
        }


        [Authorize]
        [HttpPost("{offerId}/Students/{studentId}")]
        public ActionResult AddStudentToOffer(int offerId, int studentId)
        {
            try
            {
                _studentOfferRepository.AddStudentToOffer(offerId, studentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{studentId}/Offers")]
        public ActionResult GetStudentToOffers(int studentId)
        {
            try
            {
                var offers = _studentOfferRepository.GetStudentToOffers(studentId);
                return Ok(offers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("deleteStudent")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentRepository.RemoveStudent(id);
                return Ok("Alumno borrado del sistema.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateDNI(List<Student> students, int DNI)
        {
            var inUse = students.FirstOrDefault(s => s.DocumentNumber == DNI);
            if (inUse != null)
            {
                throw new Exception("DNI ya registrado");
            }
        }
        [NonAction]
        public void ValidateFile(List<Student> students, int file)
        {
            var inUse = students.FirstOrDefault(s => s.File == file);
            if (inUse != null)
            {
                throw new Exception("Legajo ya registrado");
            }
        }

        [NonAction]
        public void ValidateUserName(List<Student> students, string userName)
        {
            var inUse = students.FirstOrDefault(s => s.UserName == userName);
            if (inUse != null)
            {
                throw new Exception("Nombre de usuario ya utilizado");
            }
        }
    }
}
