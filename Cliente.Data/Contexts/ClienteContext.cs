using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Cliente.Entities;

namespace Cliente.Data.Contexts
{
    public class ClienteContext : DbContext
    {
        public DbSet<ClienteDto> Clientes { get; set; }
        public DbSet<TelefoneDto> Telefones { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteDto>().HasMany(e => e.Telefones)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
