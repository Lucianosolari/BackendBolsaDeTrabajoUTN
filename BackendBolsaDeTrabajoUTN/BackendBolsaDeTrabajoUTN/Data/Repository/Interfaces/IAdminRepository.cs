﻿using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;

namespace BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces
{
    public interface IAdminRepository
    {
        public void CreateCareer(Career newCareer);
    }
}
