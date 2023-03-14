using System;
using Core.Entities;
using Infraestructura.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infraestructura.Data
{
    public partial class QDbContext : DbContext
    {
        public QDbContext()
        {
        }

        public QDbContext(DbContextOptions<QDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Wmoneda> Wmoneda { get; set; }
        public virtual DbSet<Wsucursal> Wsucursal { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=tcp:ins-dllo-test-01.public.33e082952ab4.database.windows.net,3342;Initial Catalog=TestDB;Persist Security Info=False;User ID=prueba;Password=pruebaconcepto;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new WmonedaConfiguration());
            modelBuilder.ApplyConfiguration(new WsucursalConfiguration());

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
