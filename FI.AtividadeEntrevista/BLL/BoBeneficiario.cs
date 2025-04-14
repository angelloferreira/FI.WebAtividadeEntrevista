using FI.AtividadeEntrevista.DAL;
using FI.AtividadeEntrevista.DML;
using System.Collections.Generic;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoBeneficiario
    {
        private DaoBeneficiario _dao = new DaoBeneficiario();

        /// <summary>
        /// Inclui um novo beneficiário
        /// </summary>
        public long Incluir(Beneficiario beneficiario)
        {
            // Aqui você pode adicionar validações de negócio, se necessário
            return _dao.Incluir(beneficiario);
        }

        /// <summary>
        /// Lista os beneficiários de um cliente
        /// </summary>
        public List<Beneficiario> ListarPorCliente(long idCliente)
        {
            return _dao.ListarPorCliente(idCliente);
        }

        /// <summary>
        /// Exclui um beneficiário
        /// </summary>
        public void Excluir(long id)
        {
            _dao.Excluir(id);
        }
    }
}
