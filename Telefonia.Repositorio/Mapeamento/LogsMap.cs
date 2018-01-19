using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Repositorio.Mapeamento
{
    public class LogsMap : EntityTypeConfiguration<Logs>
    {
        public LogsMap() : base()
        {
            this.HasKey(p => p.Id);

            this.ToTable("Logs");
        }
    }
}
