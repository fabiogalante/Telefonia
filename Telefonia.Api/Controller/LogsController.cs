using System;
using System.Threading.Tasks;
using System.Web.Http;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Api.Controller
{
    [Route("api/logs")]
    public class LogsController : ApiController
    {
        private readonly IServicoLog _servicoLog;

        public LogsController(IServicoLog servicoLog)
        {
            _servicoLog = servicoLog;
        }

        [HttpGet]
        [Route("obter")]
        public async Task<IHttpActionResult> ObterPorData(string strDataInicial, string strDataFinal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var logs = await _servicoLog.ListarPorData(Convert.ToDateTime(strDataInicial), Convert.ToDateTime(strDataFinal));

            if (logs == null)
                return NotFound();

            return Ok(logs);
        }
    }
}
