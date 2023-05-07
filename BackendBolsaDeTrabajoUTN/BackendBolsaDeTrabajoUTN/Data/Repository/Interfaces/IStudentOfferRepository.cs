using BackendBolsaDeTrabajoUTN.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IStudentOfferRepository
    {
        void AddStudentToOffer(int offerId, int studentId);
       
    }
}
