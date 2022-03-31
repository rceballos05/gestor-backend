using System;
using GestorUsuarios.Core.Entities;
using GestorUsuarios.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestorUsuarios.Infraestructure.Data
{
    public partial class GestionContext : DbContext
    {
        public GestionContext()
        {
        }

        public GestionContext(DbContextOptions<GestionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new TareaConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());

        }

    }
}
