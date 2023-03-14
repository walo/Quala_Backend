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
    public class WmonedaConfiguration : IEntityTypeConfiguration<Wmoneda>
    {
        public void Configure(EntityTypeBuilder<Wmoneda> entity)
        {
            entity.HasKey(e => e.MndId);

            entity.ToTable("WMoneda");

            entity.Property(e => e.MndFchReg)
                .HasColumnType("date")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.MndNombre)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
}
