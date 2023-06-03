using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IAdminRepository
    {
        public void CreateCareer(Career newCareer);
        public void CreateKnowledge(Knowledge newKnowledge);
        public void DeleteCareer(int id);
        public void DeleteKnowledge(int id);
    }
}
