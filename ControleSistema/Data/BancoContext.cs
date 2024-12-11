using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleSistema.Data.Map;
using ControleSistema.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleSistema.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}