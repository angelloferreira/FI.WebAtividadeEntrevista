using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FI.AtividadeEntrevista.DML; // ← Certifique-se de importar seu namespace de Beneficiario

namespace WebAtividadeEntrevista.Models
{
    /// <summary>
    /// Classe de Modelo de Cliente
    /// </summary>
    public class ClienteModel
    {
        public long Id { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Cidade { get; set; }

        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Digite um e-mail válido")]
        public string Email { get; set; }

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Nacionalidade { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string CPF { get; set; }

        public string Telefone { get; set; }

        /// <summary>
        /// Beneficiários em formato JSON (vindo do JavaScript)
        /// </summary>
        public string BeneficiariosJson { get; set; } // ← Adicionado

        /// <summary>
        /// Lista de Beneficiários deserializada (para uso interno)
        /// </summary>
        public List<Beneficiario> Beneficiarios // ← Opcional: já retorna a lista pronta
        {
            get
            {
                if (string.IsNullOrWhiteSpace(BeneficiariosJson))
                    return new List<Beneficiario>();

                try
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Beneficiario>>(BeneficiariosJson);
                }
                catch
                {
                    return new List<Beneficiario>();
                }
            }
        }
    }
}
