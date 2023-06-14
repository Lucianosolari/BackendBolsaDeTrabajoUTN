using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.DBContexts;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class KnowledgeRepository : IKnowledgeRepository
    {
        private readonly TPContext _context;
        public KnowledgeRepository(TPContext context)
        {
            _context = context;
        }

        public ActionResult<IEnumerable<Knowledge>> GetAllKnowledge()
        {
            try
            {
                return _context.Knowledges.Where(k => k.KnowledgeIsActive==true).ToList();
            }
            catch
            {
                throw new Exception("No se encontraron conocimientos");
            }
        }
    }
}
