using System.ComponentModel.DataAnnotations;

namespace FI.WebAtividadeEntrevista.Models
{
    public class BeneficiarioModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome deve ter até 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter 11 dígitos numéricos")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório")]
        public long IdCliente { get; set; }
    }
}
