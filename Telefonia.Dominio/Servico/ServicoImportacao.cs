using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Repositorio;
using Telefonia.Dominio.Servico.Interface;

namespace Telefonia.Dominio.Servico
{
    public class ServicoImportacao : IServicoImportacao
    {
        private readonly IRepositorioImportacao _repositorioImportacao;

        public ServicoImportacao(IRepositorioImportacao repositorioImportacao)
        {
            _repositorioImportacao = repositorioImportacao;
        }
        
        public Task<IEnumerable<Importacao>> Listar(string bearer, DateTime date)
        {
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
            //var url = string.Format(_appSettings.IntegrationEndPoint + " ge {0}", date.ToString("yyyy-MM-dd"));
            //var content = await client.GetStringAsync(url);
            //return await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<Importacao>>(content.ToString()));
            throw new NotImplementedException();
        }
    }
}
