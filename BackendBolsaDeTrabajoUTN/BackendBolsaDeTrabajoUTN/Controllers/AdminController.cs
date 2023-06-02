﻿using Microsoft.AspNetCore.Authorization;
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
    }
}
