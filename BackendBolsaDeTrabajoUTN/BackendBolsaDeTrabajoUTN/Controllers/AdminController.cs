using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using System.Security.AccessControl;
using System.Security.Claims;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [Authorize]
        [HttpPost]
        [Route("createCareer")]
        public IActionResult CreateCareer(AddCareerRequest request)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            { 
                try
            {
                Career newCareer = new()
                {
                    CareerName = request.CareerName,
                    CareerAbbreviation = request.CareerAbbreviation,
                    CareerType = request.CareerType,
                    CareerTotalSubjects = request.CareerTotalSubjects,
                    CareerIsActive = true
                };
                CareerResponse response = new()
                {
                    CareerName = newCareer.CareerName,
                    CareerAbbreviation = newCareer.CareerAbbreviation,
                    CareerType = newCareer.CareerType,
                    CareerTotalSubjects = newCareer.CareerTotalSubjects
                };
                _adminRepository.CreateCareer(newCareer);
                return Created("Carrera creada", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para crear Carreras");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("createKnowledge")]
        public IActionResult CreateKnowledge(AddKnowledgeRequest request) 
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                try
            {
                Knowledge newKnowledge = new()
                {

                    Type = request.Type,
                    Level = request.Level,
                    KnowledgeIsActive = true
                };
                
                _adminRepository.CreateKnowledge(newKnowledge);
                return Ok("Conocimiento creado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para crear Conocimientos");
            }
        }

        [Authorize]
        [HttpDelete] //Cambiar a put (modifica CareerIsActive de True a False)
        [Route("deleteCareer")]
        public IActionResult DeleteCareer(int id)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                try
            {
                _adminRepository.DeleteCareer(id);
                return Ok("Carrera borrada");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para borrar carreras");
            }
        }

        [Authorize]
        [HttpDelete] //Cambiar a put (modifica KnowledgeIsActive de True a False)
        [Route("deleteKnowledge")]
        public IActionResult DeleteKnowledge(int id)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                try
                {
                    _adminRepository.DeleteKnowledge(id);
                    return Ok("Conocimiento borrado");
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para borrar conocimientos");
            }
        }

        //[Authorize]
        [HttpDelete]
        [Route("deleteUser")] //Cambiar a put (modifica UserIsActive de True a False)
        public IActionResult DeleteUser(int id)
        {
            //var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            //if (userType == "Admin")
            //{
                try
                {
                    _adminRepository.DeleteUser(id);
                    return Ok("Usuario borrado");
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            //}
            //else
            //{
            //    return BadRequest("El usuario no esta autorizado para borrar usuarios");
            //}
        }

        [Authorize]
        [HttpDelete] //Cambiar a put (modifica OfferIsActive de True a False)
        [Route("deleteOffer")]
        public IActionResult DeleteOffer(int id)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                try
                {
                    _adminRepository.DeleteOffer(id);
                    return Ok("Oferta borrado");
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para borrar Ofertas");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("getAllCompanyPending")]
        public IActionResult GetAllCompanyPending()
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                try
            {
                List<Company> pendingCompanies = _adminRepository.CompanyPending();
                return Ok(pendingCompanies);
            }
            catch (Exception ex)
            {
                
                return Problem(ex.Message);
            }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para lista empresas");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("updateCompanyPending/{companyId}")]
        public IActionResult UpdateCompanyPendingConfirmation(int companyId)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Admin")
            {
                    try
                     {
                        _adminRepository.UpdateCompanyPending(companyId);
                        return Ok(new { Message = "Estado cambiado"});
                     }
                    catch (Exception ex)
                     {
                        // Manejo de errores
                        return Problem(ex.Message);
                    }
            }
            else
            {
                    return BadRequest("El usuario no esta autorizado para modificar estado de empresas");
            }
        }
    }
}
