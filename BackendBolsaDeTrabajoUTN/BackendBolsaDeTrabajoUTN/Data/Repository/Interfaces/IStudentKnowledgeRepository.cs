using BackendBolsaDeTrabajoUTN.Entities;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IStudentKnowledgeRepository
    {
        public void AddStudentKnowledge(int knowledgeId, int studentId);
    }
}
