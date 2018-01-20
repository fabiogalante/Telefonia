using System.Data.Entity.ModelConfiguration;
using Telefonia.Dominio.Entidades;

namespace Telefonia.Repositorio.Mapeamento
{
    public class LogsMap : EntityTypeConfiguration<Logs>
    {
        public LogsMap()
        {
            // Tabela
            ToTable("LogSistema");

            // Chave primária
            HasKey(p => p.LogSistemaId);

            // Coluna: LogSistemaId - BIGINT | NOT NULL | Ordem: 1
            Property(x => x.LogSistemaId).HasColumnName("LogSistemaId").HasColumnType("BIGINT").IsRequired().HasColumnOrder(1);

            // Coluna: Data - NOT NULL| Ordem: 2
            Property(x => x.Data).HasColumnName("Data").IsRequired().HasColumnOrder(2);

            // Coluna: LogOrigemId - INT | NULL | Ordem: 3
            Property(x => x.LogOrigemId).HasColumnName("LogOrigemId").HasColumnOrder(3);

            // Coluna: Severidade - VARCHAR - Máx 25 caracteres | NULL | Ordem: 4
            Property(x => x.Severidade).HasColumnName("Severidade").HasMaxLength(25).HasColumnOrder(4);

            // Coluna: Mensagem - VARCHAR - Máx caracteres | NOT NULL | Ordem: 5
            Property(x => x.Mensagem).HasColumnName("Mensagem").IsRequired().HasColumnOrder(5);

            // Coluna: ArquivoFonte - VARCHAR - Máx 100 caracteres | NULL | Ordem: 6
            Property(x => x.ArquivoFonte).HasColumnName("ArquivoFonte").HasMaxLength(100).HasColumnOrder(6);

            // Coluna: MetodoFonte - VARCHAR - Máx 100 caracteres | NULL | Ordem: 7
            Property(x => x.MetodoFonte).HasColumnName("MetodoFonte").HasMaxLength(100).HasColumnOrder(7);

            // Coluna: LinhaFonte - Ordem: 8
            Property(x => x.LinhaFonte).HasColumnName("LinhaFonte").HasColumnOrder(8);

            // Coluna: Maquina - VARCHAR - Máx 100 caracteres | NULL | Ordem: 9
            Property(x => x.Maquina).HasColumnName("Maquina").HasMaxLength(100).HasColumnOrder(9);

            // Coluna: Propriedades - VARCHAR - Máx caracteres | NULL | Ordem: 10
            Property(x => x.Propriedades).HasColumnName("Propriedades").HasColumnOrder(10);

            // Coluna: Excecao - VARCHAR - Máx caracteres | NULL | Ordem: 11
            Property(x => x.Excecao).HasColumnName("Excecao").HasColumnOrder(11);

            // Coluna: UsuarioId - INT | NULL | Ordem: 12
            Property(x => x.UsuarioId).HasColumnName("UsuarioId").HasColumnOrder(12);

            // Coluna: LogContextoId - INT | NULL | Ordem: 13
            Property(x => x.LogContextoId).HasColumnName("LogContextoId").HasColumnOrder(13);
        }
    }
}
