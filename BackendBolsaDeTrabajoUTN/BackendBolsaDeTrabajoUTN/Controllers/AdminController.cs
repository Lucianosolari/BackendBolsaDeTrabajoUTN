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

        [HttpPost]
        [Route("createCareer")]
        public IActionResult CreateCareer(AddCareerRequest request)
        {
            try
            {
                Career newCareer = new()
                {
                    CareerName = request.CareerName,
                    CareerAbbreviation = request.CareerAbbreviation,
                    CareerType = request.CareerType,
                    CareerTotalSubjects = request.CareerTotalSubjects
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
    }
}
