using GestorUsuarios.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Data.Configurations
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> entity)
        {
            entity.ToTable("Tarea");

            entity.Property(e => e.FechaInicio).HasColumnType("datetime");

            entity.Property(e => e.FechaTermino).HasColumnType("datetime");

            entity.Property(e => e.NombreTarea)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation)
                .WithMany(p => p.Tareas)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tarea_Usuario");
        }
    }
}
