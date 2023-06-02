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
                        UserName = request.UserName,
                        Password = request.Password,
                        CompanyCUIT = request.CompanyCUIT,
                        CompanyLine = request.CompanyLine,
                        CompanyName = request.CompanyName,
                        CompanyAddress = request.CompanyAddress,
                        CompanyLocation = request.CompanyLocation,
                        CompanyPostalCode = request.CompanyPostalCode,
                        CompanyPhone = request.CompanyPhone,
                        UserEmail = request.CompanyEmail,
                        CompanyWebPage = request.CompanyWebPage,

                        CompanyPersonalName = request.CompanyPersonalName,
                        CompanyPersonalSurname = request.CompanyPersonalSurname,
                        CompanyPersonalJob = request.CompanyPersonalJob,
                        CompanyPersonalPhone = request.CompanyPersonalPhone,
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
        [HttpDelete]
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

        //[Authorize]
        //[HttpPost]
        //[Route("createOffer")]
        //public IActionResult CreateOffer(AddOfferRequest request)
        //{
        //    var userType = User.Claims.FirstOrDefault(c => c.Type == "userType")?.Value;
        //    if (userType == "Company")
        //    {
        //        try
        //        {
        //            Offer newOffer = new()
        //            {
        //                OfferTitle = request.OfferTitle,
        //                OfferSpecialty = request.OfferSpecialty,
        //                OfferDescription = request.OfferDescription,
        //                CreatedDate = request.CreatedDate,
        //                CompanyId = request.CompanyId,
        //            };
        //            OfferResponse response = new()
        //            {
        //                OfferTitle = newOffer.OfferTitle,
        //                OfferSpecialty = newOffer.OfferSpecialty,
        //                OfferDescription = newOffer.OfferDescription,
        //                CreatedDate = newOffer.CreatedDate,

        //            };
        //            _offerRepository.CreateOffer(newOffer);
        //            return Created("Oferta creada", response);
        //        }
        //        catch (Exception ex)
        //        {
        //            return Problem(ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("El usuario no esta autorizado para crear ofertas");
        //    }
        //}


        //[HttpGet]
        //[Route("getAllMeets")]
        //public IActionResult GetAllMeets()
        //{

        //    try
        //    {
        //        List<CompanyResponse> companiesToReturn = new List<CompanyResponse>();
        //        List<Company> company = _companyRepository.GetMeets(); //!!
        //        foreach (var company in companies)
        //        {
        //            company.Companies = _companyRepository.GetTrials(meet.Id);
        //            CompanyResponse response = new()
        //            {
        //                Id = meet.Id,
        //                MeetName = meet.MeetName,
        //                MeetDate = meet.MeetDate,
        //                MeetPlace = meet.MeetPlace,
        //                Trials = meet.Trials,
        //            };
        //            companiesToReturn.Add(response);
        //        }
        //        return Ok(meetsToReturn);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpGet]
        //[Route("getMeetById/{id}")]
        //public IActionResult GetMeetById(int id)
        //{
        //    try
        //    {
        //        Company? meet = _meetRepository.GetSingleMeet(id);
        //        meet.Trials = _meetRepository.GetTrials(meet.Id);
        //        CompanyResponse response = new()
        //        {
        //            MeetName = meet.MeetName,
        //            MeetDate = meet.MeetDate,
        //            MeetPlace = meet.MeetPlace,
        //            Id = meet.Id,
        //            Trials = meet.Trials
        //        };
        //        return Ok(response);
        //    }
        //    catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}



        //[HttpDelete]
        //[Route("deleteMeet/{id}")]
        //public IActionResult DeleteMeet(int id)
        //{
        //    try
        //    {
        //        _meetRepository.RemoveMeet(id);
        //        return Ok("Meet borrado");
        //    }
        //    catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut]
        //[Route("modifyMeetDate/{id}/{newMeetDate}")]
        //public IActionResult ModifyMeetDate (int id, string newMeetDate)
        //{
        //    try
        //    {
        //        _meetRepository.EditMeetDate(id, newMeetDate);
        //        return Ok("Fecha modificada");
        //    }
        //    catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}
    }
}





