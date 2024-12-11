using System.ComponentModel.DataAnnotations;

namespace ControleSistema.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite seu email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

    }
}
