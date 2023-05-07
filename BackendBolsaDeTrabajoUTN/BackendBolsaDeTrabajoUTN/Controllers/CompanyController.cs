using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;
        

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

       

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

        [HttpPost]
        [Route("createOffer")]
        public IActionResult CreateOffer(AddOfferRequest request)
        {
            try
            {
                Offer newOffer = new()
                {
                   OfferDescription = request.OfferDescription,
                    
                };
                OfferResponse response = new()
                {
                    OfferDescription = newOffer.OfferDescription,
                    
                };
                
                return Created("Meet creado", response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

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





