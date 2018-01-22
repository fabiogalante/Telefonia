using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Telefonia.Dominio.Entidades;
using Telefonia.Repositorio.Mapeamento;

namespace Telefonia.Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto(string connectionString) : base(connectionString)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Logs> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new LogsMap());

            modelBuilder.Entity<Logs>().HasKey(p => new { p.LogSistemaId });
            modelBuilder.Entity<Logs>().Property(p => p.LogSistemaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            base.OnModelCreating(modelBuilder);
        }
    }
}
