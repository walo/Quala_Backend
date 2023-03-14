using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Data.Configurations
{
    public class WsucursalConfiguration : IEntityTypeConfiguration<Wsucursal>
    {
        public void Configure(EntityTypeBuilder<Wsucursal> entity)
        {
            entity.HasKey(e => e.SucCodigo);

            entity.ToTable("WSucursal");

            entity.Property(e => e.SucDescripcion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.SucDireccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.SucFchReg)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.SucIdentificacion)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Mnd)
                .WithMany(p => p.Wsucursals)
                .HasForeignKey(d => d.MndId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SucMoneda");
        }
    }
}
