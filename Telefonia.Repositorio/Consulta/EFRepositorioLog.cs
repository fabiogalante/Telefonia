using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;
using Telefonia.Dominio.Repositorio;

namespace Telefonia.Repositorio.Consulta
{
    public class EFRepositorioLog : IRepositorioLog
    {
        private readonly Contexto _contexto;

        public EFRepositorioLog(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Salvar(IEnumerable<Logs> dados)
        {
            try
            {
                foreach (var item in dados)
                {
                    _contexto.Logs.Add(item);
                    //_contexto.Entry(item).State = EntityState.Added;
                    var t = _contexto.Logs.Sql;
                    _contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Logs>> ListarPorData(DateTime dataInicial, DateTime dataFinal)
        {
            return await _contexto.Logs.Where(l => l.Data > dataInicial && l.Data < dataFinal).ToListAsync();
        }
    }
}
