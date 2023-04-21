using BackendBolsaDeTrabajoUTN.Data.Repository.Interfaces;
using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;
using BackendBolsaDeTrabajoUTN.Services.Interfaces;

namespace BackendBolsaDeTrabajoUTN.Services.Implementations
{
    public class AutenticacionService : ICustomAuthenticationService
    {
        private readonly IStudentRepository _swimmerRepository;

        public AutenticacionService(IStudentRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }
        
        public Student? ValidateSwimmer(AuthenticationRequestBody authenticationRequest)
        {
            if (string.IsNullOrEmpty(authenticationRequest.UserName) || string.IsNullOrEmpty(authenticationRequest.Password))
                return null;
            return _swimmerRepository.ValidateSwimmer(authenticationRequest);
        }
    }
}
