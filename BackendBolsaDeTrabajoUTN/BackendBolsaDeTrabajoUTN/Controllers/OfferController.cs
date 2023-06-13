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
    }
}