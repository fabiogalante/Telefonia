using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Api.Controller
{
    public class ImportacaoController : ApiController
    {
        private readonly IServicoImportacao _servicoImportacao;

        public ImportacaoController(IServicoImportacao servicoImportacao)
        {
            _servicoImportacao = servicoImportacao;
        }

        public async Task<IHttpActionResult> Importar(string dataInicial)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DateTime data = DateTime.ParseExact(dataInicial, "yyyyMMddTHHmmss", CultureInfo.InvariantCulture);

            string bearer = string.Empty;

            var retorno = await _servicoImportacao.Listar(bearer, data).GetAwaiter().GetResult();

            return Ok(retorno.ToList());

        }
    }
}
