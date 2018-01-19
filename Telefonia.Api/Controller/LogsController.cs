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
    public class LogsController : ApiController
    {
        private readonly IServicoLog _servicoLog;

        public LogsController(IServicoLog servicoLog)
        {
            _servicoLog = servicoLog;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Obter()
        {
            var logs = await _servicoLog.Listar();

            return Ok(logs);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Obter(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var logs = await _servicoLog.ObterPorId(id);

            if (logs == null)
                return NotFound();

            return Ok(logs);
        }

        [HttpGet]
        public async Task<IHttpActionResult> ObterPorDada(DateTime dataInicial, DateTime dataFinal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var logs = await _servicoLog.ListarPorData(dataInicial, dataFinal);

            if (logs == null)
                return NotFound();

            return Ok(logs);
        }

        [HttpPut]
        public async Task<IHttpActionResult> Alterar(Logs log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (log.Id <= 0)
                return BadRequest();

            await _servicoLog.Alterar(log);

            return NoContent();
        }

        [HttpPost]
        public async Task<IHttpActionResult> Gravar(Logs log)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _servicoLog.Inserir(log);

            return Ok(log.Id);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Excluir(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var logSistema = await _servicoLog.Excluir(id);

            if (logSistema == null)
                return NotFound();
            
            return Ok(logSistema);
        }
    }
}
