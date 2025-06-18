using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vault.Models
{
    internal class InMemoryDbContext(DbContextOptions<InMemoryDbContext> options) : DbContext(options)
    {
        public DbSet<KeyValue> KeyVaule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KeyValue>( entity => entity.HasKey(e => e.Id) );
        }
    }
}
