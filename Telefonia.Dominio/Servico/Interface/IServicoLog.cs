using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Dominio.Servico.Interface
{
    public interface IServicoLog
    {
        Task<IEnumerable<Logs>> Listar();
        
        Task<IEnumerable<Logs>> ListarPorData(DateTime dataInicial, DateTime dataFinal);

        Task<Logs> ObterPorId(long id);
        Task Excluir(long id);
        void Inserir(Logs log);
        Task Alterar(Logs log);
    }
}
