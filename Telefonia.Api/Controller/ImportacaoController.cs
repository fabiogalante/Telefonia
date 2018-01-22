using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Api.Controller
{
    [Route("api/importacao")]
    public class ImportacaoController : ApiController
    {
        private readonly IServicoLog _servicoLog;

        public ImportacaoController(IServicoLog servicoLog)
        {
            _servicoLog = servicoLog;
        }

        [HttpGet]
        [Route("importar")]
        public async Task<IHttpActionResult> Importar(string strData)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            DateTime dataInicial = Convert.ToDateTime(strData);

            var retorno = await _servicoLog.Importar(dataInicial);

            return Ok(retorno.ToList());

        }
    }
}
