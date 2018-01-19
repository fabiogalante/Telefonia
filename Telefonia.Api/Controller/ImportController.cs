using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Api.Controller
{
    public class ImportController : ApiController
    {

        private readonly IServicoImportacao _servicoImportacao;
        //private readonly ipCorpContext _context;

        public ImportController(IServicoImportacao servicoImportacao)
        {
            //_context = context;
            _servicoImportacao = servicoImportacao;
        }

        public IHttpActionResult Obter()
        {
            return Ok();
        }

        public async Task<IEnumerable<Importacao>> List(DateTime date)
        {
            // var response = await Login<LoginResponse>();
            // return await List(response.AccessToken, date);
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<Importacao>> List(string bearer, DateTime date)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            //var url = string.Format(_appSettings.IntegrationEndPoint + " ge {0}", date.ToString("yyyy-MM-dd"));
            //var content = await client.GetStringAsync(url);
            //return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Models.Import>>(content.ToString()));
            throw new NotImplementedException();
        }

        //// GET: api/Import
        //[HttpGet("{startDate}")]
        //public async Task<IActionResult> Import([FromRoute] string startDate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    DateTime dt = DateTime.ParseExact(startDate, "yyyyMMddTHHmmss", CultureInfo.InvariantCulture);

        //    var data = _importService.List(dt).GetAwaiter().GetResult();

        //    _context.Set<Models.Import>().AddRange(data);
        //    await _context.SaveChangesAsync();

        //    return Ok(data.ToList());

        //}
    }
}
