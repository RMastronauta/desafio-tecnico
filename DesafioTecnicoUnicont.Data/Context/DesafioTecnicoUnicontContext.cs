using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoUnicont.Data.Context
{
    public class DesafioTecnicoUnicontContext : DbContext
    {
        public DesafioTecnicoUnicontContext(DbContextOptions<DesafioTecnicoUnicontContext> options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DesafioTecnicoUnicontContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
