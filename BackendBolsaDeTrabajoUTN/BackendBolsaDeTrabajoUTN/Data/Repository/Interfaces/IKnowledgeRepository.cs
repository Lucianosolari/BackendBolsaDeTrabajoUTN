using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IKnowledgeRepository
    {
        public ActionResult<IEnumerable<Knowledge>> GetAllKnowledge();
    }
}
