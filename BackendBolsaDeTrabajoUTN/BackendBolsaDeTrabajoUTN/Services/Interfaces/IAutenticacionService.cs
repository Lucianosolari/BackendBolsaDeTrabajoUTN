using BackendBolsaDeTrabajoUTN.Entities;
using BackendBolsaDeTrabajoUTN.Models;

namespace BackendBolsaDeTrabajoUTN.Services.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Student? ValidateSwimmer(AuthenticationRequestBody authenticationRequestBody);
    }
}
