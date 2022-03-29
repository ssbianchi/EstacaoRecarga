using Microsoft.EntityFrameworkCore;
using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Infra.Dados.Config
{
    public class EstacaoRecargaDbContext : DbContext
    {
        public DbSet<EstacaoRecarga> EstacaoRecargas { get; set; }

        public EstacaoRecargaDbContext()
        {

        }

        public EstacaoRecargaDbContext(DbContextOptions<EstacaoRecargaDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(GetConnectionString());

            base.OnConfiguring(optionsBuilder);
        }

        private string GetConnectionString()
        {
            //Alterar para configurações desejadas:
            return "Server=(localdb)\\MSSQLLocalDB;Database=EstacaoRepositorioDB;Trusted_Connection=True;";
        }
    }
}
