using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FI.WebAtividadeEntrevista.Models;
using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;

namespace FI.WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {
        private BoBeneficiario _boBeneficiario = new BoBeneficiario();

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                Response.StatusCode = 400;
                return Json(string.Join(Environment.NewLine, erros));
            }

            var beneficiario = new Beneficiario
            {
                Nome = model.Nome,
                Cpf = model.CPF,
                IdCliente = model.IdCliente
            };

            model.Id = _boBeneficiario.Incluir(beneficiario);
            return Json("Beneficiário incluído com sucesso");
        }

        [HttpPost]
        public JsonResult ListarPorCliente(long idCliente)
        {
            try
            {
                var lista = _boBeneficiario.ListarPorCliente(idCliente);

                var resultado = lista.Select(b => new BeneficiarioModel
                {
                    Id = b.Id,
                    Nome = b.Nome,
                    CPF = b.Cpf,
                    IdCliente = b.IdCliente
                }).ToList();

                return Json(new { Result = "OK", Records = resultado });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Excluir(long id)
        {
            try
            {
                _boBeneficiario.Excluir(id);
                return Json("Beneficiário excluído com sucesso");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json("Erro ao excluir: " + ex.Message);
            }
        }
    }
}
