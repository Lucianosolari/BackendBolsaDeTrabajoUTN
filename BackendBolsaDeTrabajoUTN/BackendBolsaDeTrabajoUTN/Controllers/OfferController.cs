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
   
    public class OfferController : ControllerBase
    {


        private readonly TPContext _context;
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository, TPContext context)
        {
            _offerRepository = offerRepository;
            _context = context;
        }

        



        [Authorize]
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

        [HttpGet("Offers")]
        public IActionResult GetOffers()
        {
            var offers = _offerRepository.GetOffers();
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