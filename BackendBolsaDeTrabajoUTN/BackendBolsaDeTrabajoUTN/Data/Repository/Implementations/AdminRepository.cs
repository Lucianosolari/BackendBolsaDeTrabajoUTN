using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.DBContexts;
using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Implementations
{
    public class AdminRepository : IAdminRepository
    {
        private readonly TPContext _context;
        public AdminRepository(TPContext context)
        {
            _context = context;
        }

        public void CreateCareer(Career newCareer)
        {
            try
            {
                _context.Careers.Add(newCareer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void CreateKnowledge(Knowledge newKnowledge)
        {
            try
            {
                _context.Knowledges.Add(newKnowledge);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {


                throw new Exception("el error es" + ex);
            }
        }

        public void DeleteCareer(int id)
        {
            try
            {
                _context.Careers.Remove(_context.Careers.First(x => x.CareerId == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Carrera no encontrada");
            }
        }
        public void DeleteKnowledge(int id)
        {
            try
            {
                _context.Knowledges.Remove(_context.Knowledges.First(x => x.KnowledgeId == id));
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Conocimiento no encontrado");
            }
        }
    }
}
