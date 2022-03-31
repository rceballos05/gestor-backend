using GestorUsuarios.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuario");

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Cargo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.Property(e => e.FechaNacimiento).HasColumnType("date");

            entity.Property(e => e.Fono)
                .HasMaxLength(12)
                .IsUnicode(false);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            entity.Property(e => e.Rut)
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.IdLoginNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdLogin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Login");
        }
    }
}
