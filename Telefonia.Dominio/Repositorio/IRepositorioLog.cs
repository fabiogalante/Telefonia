using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Dominio.Repositorio
{
    public interface IRepositorioLog
    {
        void Salvar(IEnumerable<Logs> dados);

        Task<IEnumerable<Logs>> ListarPorData(DateTime dataInicial, DateTime dataFinal);
    }
}
