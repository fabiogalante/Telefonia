using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Dominio.Servico
{
    public class ServicoLogin : IServicoLogin
    {
        public async Task<DadosAcesso> Login()
        {
            DadosAcesso result = null;

            var config = ConfigurationManager.AppSettings;
            var dados = $"username={config["username"]}&password={config["password"]}&client_id={config["client_id"]}&grant_type=password";

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(config["api_autenticacao"], new StringContent(dados, Encoding.UTF8));

                if (!string.IsNullOrWhiteSpace(response.Content.ToString()))
                    result = JsonConvert.DeserializeObject<DadosAcesso>(await response.Content.ReadAsStringAsync());
            }

            return result;
        }
    }
}
