using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackendBolsaDeTrabajoUTN.Helpers;

namespace BackendBolsaDeTrabajoUTNBackendBolsaDeTrabajoUTN.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }


        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = Security.CreateSHA512(value); }
        }

        
        public string Type { get; set; }
        

    }
}
