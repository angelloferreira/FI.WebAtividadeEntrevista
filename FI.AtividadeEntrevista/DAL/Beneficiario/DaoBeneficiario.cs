using FI.AtividadeEntrevista.DML;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FI.AtividadeEntrevista.DAL
{
    internal class DaoBeneficiario : AcessoDados
    {
        internal long Incluir(Beneficiario beneficiario)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("Nome", beneficiario.Nome),
                new SqlParameter("Cpf", beneficiario.Cpf),
                new SqlParameter("IdCliente", beneficiario.IdCliente)
            };

            DataSet ds = base.Consultar("FI_SP_IncBeneficiario", parametros, adapter);

            long id = 0;
            if (ds.Tables[0].Rows.Count > 0)
                long.TryParse(ds.Tables[0].Rows[0][0].ToString(), out id);

            return id;
        }

        internal void Excluir(long id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("Id", id)
            };

            base.Executar("FI_SP_DelBeneficiario", parametros);
        }

        internal List<Beneficiario> ListarPorCliente(long idCliente)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("IdCliente", idCliente)
            };

            DataSet ds = base.Consultar("FI_SP_ConsBeneficiariosCliente", parametros, adapter);
            return Converter(ds);
        }

        private List<Beneficiario> Converter(DataSet ds)
        {
            List<Beneficiario> lista = new List<Beneficiario>();

            if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    Beneficiario ben = new Beneficiario
                    {
                        Id = row.Field<long>("Id"),
                        Nome = row.Field<string>("Nome"),
                        Cpf = row.Field<string>("Cpf"),
                        IdCliente = row.Field<long>("IdCliente")
                    };

                    lista.Add(ben);
                }
            }

            return lista;
        }
    }
}
