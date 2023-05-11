using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BackendBolsaDeTrabajoUTN.Data.Repository;
using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using System.Security.Claims;
using BackendBolsaDeTrabajoUTN.DBContexts;

namespace BackendBolsaDeTrabajoUTN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OfferController : ControllerBase
    {


        private readonly TPContext _context;
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository, TPContext context)
        {
            _offerRepository = offerRepository;
            _context = context;
        }

        //[HttpGet]
        //[Route("getAllTrials")]
        //public IActionResult GetAllTrials()
        //{
        //        List<OfferResponse> trialsToReturn = new();
        //        List<Offer> trials = _trialRepository.GetTrials();
        //        foreach (var trial in trials)
        //        {
        //            trial.MeetName = _trialRepository.GetTrialMeetName(trial.MeetId);
        //            trial.RegisteredSwimmers = _trialRepository.GetRegisteredSwimmers(trial.Id);
        //            OfferResponse response = new()
        //            {
        //                Id = trial.Id,
        //                Distance = trial.Distance,
        //                Style = trial.Style,
        //                MeetName = trial.MeetName,
        //                RegisteredSwimmers = trial.RegisteredSwimmers,
        //                MeetId = trial.MeetId,
        //            };
        //            trialsToReturn.Add(response);
        //        }
        //        return Ok(trialsToReturn);
        //}

        //[HttpGet]
        //[Route("getTrialById/{id}")]
        //public IActionResult GetTrialByiD(int id)
        //{
        //    Offer? trial = _trialRepository.GetSingleTrial(id);
        //    trial.MeetName = _trialRepository.GetTrialMeetName(trial.MeetId);
        //    trial.RegisteredSwimmers = _trialRepository.GetRegisteredSwimmers(trial.Id);
        //    OfferResponse response = new()
        //    {
        //        Id = trial.Id,
        //        Distance = trial.Distance,
        //        Style = trial.Style,
        //        MeetName = trial.MeetName,
        //        RegisteredSwimmers = trial.RegisteredSwimmers,
        //        MeetId = trial.MeetId
        //    };
        //    return Ok(response);
        //}

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
                _offerRepository.CreateOffer(newOffer);
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

       


        [HttpGet("ByCompany/{companyId}")]
        public IActionResult GetOffersByCompany(int companyId)
        {
            var offers = _offerRepository.GetOffersByCompany(companyId);

            if (offers == null)
            {
                return NotFound();
            }

            return Ok(offers);
        }

        //[HttpDelete]
        //[Route("deleteTrial/{id}")]
        //public IActionResult DeleteTrial(int id)
        //{
        //    try
        //    {
        //        _trialRepository.RemoveTrial(id);
        //        return Ok("Trial borrado");
        //    }
        //    catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut]
        //[Route("modifyTrialDistance/{id}/{newDistance}")]
        //public IActionResult ModifyTrialDistance(int id, int newDistance)
        //{
        //    try
        //    {
        //        _trialRepository.EditTrialDistance(id, newDistance);
        //        return Ok("Distancia modificada");
        //    }
        //    catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}

        //[HttpPut]
        //[Route("modifyTrialStyle/{id}/{newStyle}")]
        //public IActionResult ModifyTrialStyle(int id, string newStyle)
        //{
        //    try
        //    {
        //        _trialRepository.EditTrialStyle(id, newStyle);
        //        return Ok("Estilo modificado");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}


        //[NonAction]
        //public void ValidateIdCompany(List<Company> companies, int companyId)
        //{
        //    var company = _context.Companies.FirstOrDefault(c => c.Id == request.CompanyId);
        //    if (company == null)
        //    {
        //        return BadRequest("El ID de la empresa no es válido");
        //    }
        //}

        //[NonAction]
        //public void ValidateMeetId(List<Company> meets, int meetId)
        //{
        //    var meetExists = meets.FirstOrDefault(m => m.Id == meetId);
        //    if (meetExists == null)
        //    {
        //        throw new Exception("Meet no encontrado, revisar Id.");
        //    }
        //}
    }
}