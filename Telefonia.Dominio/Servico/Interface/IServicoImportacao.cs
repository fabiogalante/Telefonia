using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Dominio.Servico.Interface
{
    public interface IServicoImportacao
    {
        Task<IEnumerable<Importacao>> Listar(string bearer, DateTime data);
    }
}
