using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Data.Repository.Implementations;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;
        

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpPost]
        [Route("createCompany")]
        public IActionResult CreateCompany(AddCompanyRequest request)
        {
            //var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            //if (userType == "Admin")
            //{
                try
                {
                    Company newCompany = new()
                    {
                        // datos de la empresa
                        UserName = request.UserName,
                        Password = request.Password,
                        CompanyCUIT = request.CompanyCUIT,
                        CompanyLine = request.CompanyLine,
                        CompanyName = request.CompanyName,
                        CompanyAddress = request.CompanyAddress,
                        CompanyLocation = request.CompanyLocation,
                        CompanyPostalCode = request.CompanyPostalCode,
                        CompanyPhone = request.CompanyPhone,
                        UserIsActive = true,

                        // datos de contacto
                        CompanyWebPage = request.CompanyWebPage,
                        CompanyPersonalName = request.CompanyPersonalName,
                        CompanyPersonalSurname = request.CompanyPersonalSurname,
                        CompanyPersonalJob = request.CompanyPersonalJob,
                        CompanyPersonalPhone = request.CompanyPersonalPhone,
                        UserEmail = request.UserEmail,
                        CompanyRelationContact = request.CompanyRelationContact,
                        CompanyPendingConfirmation = true
                    };
                    CompanyResponse response = new()
                    {
                        CompanyName = newCompany.CompanyName,
                    };
                    _companyRepository.CreateCompany(newCompany);
                    return Created("Empresa creada", response);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            //}
            //else
            //{
            //    return BadRequest("El usuario no esta autorizado para crear ofertas");
            //}
        }

        [Authorize]
        [HttpDelete] //Cambiar a put (modifica UserIsActive de True a False)
        [Route("deleteCompany/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _companyRepository.RemoveCompany(id);
                return Ok("Empresa borrada del sistema.");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("createOffer")]
        public IActionResult CreateOffer(AddOfferRequest request)
        {
            var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
            if (userType == "Company")
            {
                try
                {
                    Offer newOffer = new()
                    {
                        OfferTitle = request.OfferTitle,
                        OfferSpecialty = request.OfferSpecialty,
                        OfferDescription = request.OfferDescription,
                        CreatedDate = request.CreatedDate,
                        CompanyId = request.CompanyId,
                    };
                    OfferResponse response = new()
                    {
                        OfferTitle = newOffer.OfferTitle,
                        OfferSpecialty = newOffer.OfferSpecialty,
                        OfferDescription = newOffer.OfferDescription,
                        CreatedDate = newOffer.CreatedDate,

                    };
                    _companyRepository.CreateOffer(newOffer);
                    return Created("Oferta creada", response);
                }
                catch (Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
            {
                return BadRequest("El usuario no esta autorizado para crear ofertas");
            }
        }
    }
}





