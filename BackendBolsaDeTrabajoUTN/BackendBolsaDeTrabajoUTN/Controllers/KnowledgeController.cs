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
    public class KnowledgeController : ControllerBase
    {
        private readonly IKnowledgeRepository _knowledgeRepository;

        public KnowledgeController(IKnowledgeRepository knowledgeRepository)
        {
            _knowledgeRepository = knowledgeRepository;
        }

        [Authorize]
        [HttpGet("knowledge/GetAllKnowledge")]
        public IActionResult GetAllKnowledge()
        {
            var knowledge = _knowledgeRepository.GetAllKnowledge();
            if (knowledge == null)
            {
                return NotFound();
            }
            return Ok(knowledge);
        }
    }
}
