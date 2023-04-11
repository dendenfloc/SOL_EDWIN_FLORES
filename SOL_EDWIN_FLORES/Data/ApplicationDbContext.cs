using SOL_EDWIN_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SOL_EDWIN_FLORES.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("ApplicationDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");
            modelBuilder.HasDefaultSchema("SYSTEM")
                .Properties()
                .Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name));
        }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<libros> libros { get; set; }
        public DbSet<prestamos> prestamos { get; set; }
    }
}
