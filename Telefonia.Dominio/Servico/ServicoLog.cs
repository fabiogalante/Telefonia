using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Repositorio;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Dominio.Servico
{
    public class ServicoLog : IServicoLog
    {
        private readonly IRepositorioLog _repositorioLog;
        private readonly IServicoLogin _servicoLogin;

        public ServicoLog(IServicoLogin servicoLogin, IRepositorioLog repositorioLog)
        {
            _servicoLogin = servicoLogin;
            _repositorioLog = repositorioLog;
        }

        public async Task<IEnumerable<Logs>> Importar(DateTime data)
        {
            var config = ConfigurationManager.AppSettings;
            var login = await _servicoLogin.Login();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", login.AccessToken);

            var conteudo = await httpClient.GetStringAsync($"{config["api_integracao"]}?$filter=Data ge {data:yyyy-MM-dd}");

            var dados = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Logs>>(conteudo));

            /*dados = new List<Logs>()
            {
                new Logs{
                    LogSistemaId= 346842,

                }
            }*/

            if(dados != null)
                _repositorioLog.Salvar(dados);

            return dados;
        }

        public async Task<IEnumerable<Logs>> ListarPorData(DateTime dataInicial, DateTime dataFinal)
        {
            return await _repositorioLog.ListarPorData(dataInicial, dataFinal);
        }
    }
}
