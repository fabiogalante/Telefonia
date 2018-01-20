using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Dominio.Servico.Interface
{
    public interface IServicoLog
    {
        Task<IEnumerable<Logs>> Importar(DateTime data);

        Task<IEnumerable<Logs>> ListarPorData(DateTime dataInicial, DateTime dataFinal);
    }
}
