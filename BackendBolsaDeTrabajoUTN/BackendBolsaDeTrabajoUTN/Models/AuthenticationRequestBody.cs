using System.ComponentModel.DataAnnotations;

namespace BackendBolsaDeTrabajoUTN.Models
{
	public class AuthenticationRequestBody
	{
		public string Password { get; set; }
		public string UserName { get; set; }

		public string UserType { get; set; }
	}
}

