// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using System.Security.AccessControl;
using System.Security.Claims;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {

        private readonly IStudentOfferRepository _studentOfferRepository;
        
        private readonly IStudentRepository _studentRepository;

        private readonly TPContext _context;

        public StudentController(IStudentOfferRepository studentOfferRepository, IStudentRepository studentRepository, TPContext context)
        {

            _studentOfferRepository = studentOfferRepository;
            
            _studentRepository = studentRepository;

            _context = context;
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
        [HttpPut]
        [Route("addStudentAdressInfo")]
        public IActionResult addStudentAdressInfo(AddStudentAdressInfoRequest newStudentAdressInfo)
        {
            try
            {
                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _studentRepository.AddStudentAdressInfo(id, newStudentAdressInfo);
                return Ok(new { message = "Domicilios modificados" });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("updateStudentUniversityInfo")]
        public IActionResult addStudentUniversityInfo(AddStudentUniversityInfoRequest newStudentUniversityInfo)
        {
            try
            {
                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                _studentRepository.AddStudentUniversityInfo(id, newStudentUniversityInfo);
                return Ok(new { message = "Datos universitarios modificados" });
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
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
        [HttpDelete] //Cambiar a put (modifica UserIsActive de True a False)
        [Route("deleteStudent/{id}")]
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

        [Authorize]
        [HttpPost]
        [Route("uploadCV")]
        public IActionResult UploadCV(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("No se ha enviado ningún archivo.");
                }

                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                // Obtener el studentId del claim
                string studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(studentId))
                {
                    return BadRequest("No esta logeado como estudiante.");
                }

                CVFile cvFile = new CVFile
                {
                    Name = file.FileName,
                    File = fileBytes,
                    StudentId = int.Parse(studentId)
                };

                _studentRepository.UploadStudentCV(cvFile);

                return Ok(new { message = "Archivo guardado exitosamente en la base de datos." });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("downloadCV")]
        public IActionResult DownloadCV()
        {
            // Obtener el studentId del claim
            string studentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest("No esta logeado como estudiante, o no cargo su CV.");
            }

            CVFile cvFile = _context.CVFiles.FirstOrDefault(c => c.StudentId == int.Parse(studentId));

            if (cvFile == null)
            {
                return NotFound("No se encontró el archivo.");
            }

            return File(cvFile.File, "application/octet-stream", cvFile.Name);
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
