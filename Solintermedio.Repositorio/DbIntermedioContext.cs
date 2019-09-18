using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolIntermedio.Entidades;
using SolIntermedio.Entidades.DTO;

namespace Solintermedio.Repositorio
{
    public class DbIntermedioContext : DbContext
    {
        public DbIntermedioContext() : base("BdConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Opcion> Opcion { get; set; }
    }
}
