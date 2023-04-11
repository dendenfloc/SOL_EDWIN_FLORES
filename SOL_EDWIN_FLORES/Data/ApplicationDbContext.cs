using SOL_EDWIN_FLORES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            //base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("SYSTEM");
            //modelBuilder.Entity<libros>().ToTable("libros", "SYSTEM");
            //modelBuilder.Entity<usuarios>().ToTable("usuarios", "SYSTEM");
            //modelBuilder.Entity<prestamos>().ToTable("prestamos", "SYSTEM");
            //modelBuilder.HasDefaultSchema("SYSTEM")
            //    .Properties()
            //    .Configure(c => c.HasColumnName(c.ClrPropertyInfo.Name.ToUpperInvariant));
        }
        public DbSet<USUARIOS> USUARIOS { get; set; }
        public DbSet<LIBROS> LIBROS { get; set; }
        public DbSet<PRESTAMOS> PRESTAMOS { get; set; }
    }
}
