namespace FI.AtividadeEntrevista.DML
{
    /// <summary>
    /// Classe que representa um Beneficiário vinculado a um Cliente
    /// </summary>
    public class Beneficiario
    {
        /// <summary>
        /// Id do beneficiário
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do beneficiário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF do beneficiário
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Id do cliente associado
        /// </summary>
        public long IdCliente { get; set; }
    }
}
