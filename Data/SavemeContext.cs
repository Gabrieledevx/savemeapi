using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Saveme.Models;

namespace Saveme.Data;

public partial class SavemeContext : DbContext
{
    public SavemeContext(DbContextOptions<SavemeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adopcion> Adopcions { get; set; }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Animalespecial> Animalespecials { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Donacion> Donacions { get; set; }

    public virtual DbSet<Eventoadopcion> Eventoadopcions { get; set; }

    public virtual DbSet<Participanteevento> Participanteeventos { get; set; }

    public virtual DbSet<Perfilanimal> Perfilanimals { get; set; }

    public virtual DbSet<Perfilanimalespecial> Perfilanimalespecials { get; set; }

    public virtual DbSet<Proveedoradopcion> Proveedoradopcions { get; set; }

    public virtual DbSet<Proveedorrescate> Proveedorrescates { get; set; }

    public virtual DbSet<Ubicacion> Ubicacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Valoracion> Valoracions { get; set; }

    public virtual DbSet<Veterinario> Veterinarios { get; set; }

    public virtual DbSet<Visitasveterinario> Visitasveterinarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Adopcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("adopcion");

            entity.HasIndex(e => e.AnimalId, "animal_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.ComentariosAdicionales)
                .HasColumnType("text")
                .HasColumnName("comentarios_adicionales");
            entity.Property(e => e.FechaAdopcion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_adopcion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Adopcions)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("adopcion_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Adopcions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("adopcion_ibfk_1");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("animal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Especie)
                .HasMaxLength(255)
                .HasColumnName("especie");
            entity.Property(e => e.NecesidadesEspeciales)
                .HasMaxLength(255)
                .HasColumnName("necesidades_especiales");
            entity.Property(e => e.Personalidad)
                .HasMaxLength(255)
                .HasColumnName("personalidad");
            entity.Property(e => e.Tamano)
                .HasMaxLength(255)
                .HasColumnName("tamano");
        });

        modelBuilder.Entity<Animalespecial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("animalespecial");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Discapacidad)
                .HasMaxLength(255)
                .HasColumnName("discapacidad");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Especie)
                .HasMaxLength(255)
                .HasColumnName("especie");
            entity.Property(e => e.NecesidadesEspecialesAdicionales)
                .HasMaxLength(255)
                .HasColumnName("necesidades_especiales_adicionales");
            entity.Property(e => e.Personalidad)
                .HasMaxLength(255)
                .HasColumnName("personalidad");
            entity.Property(e => e.Tamano)
                .HasMaxLength(255)
                .HasColumnName("tamano");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("comentario");

            entity.HasIndex(e => e.PerfilAnimalEspecialId, "perfil_animal_especial_id");

            entity.HasIndex(e => e.PerfilAnimalId, "perfil_animal_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("fecha_hora");
            entity.Property(e => e.PerfilAnimalEspecialId).HasColumnName("perfil_animal_especial_id");
            entity.Property(e => e.PerfilAnimalId).HasColumnName("perfil_animal_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.PerfilAnimalEspecial).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PerfilAnimalEspecialId)
                .HasConstraintName("comentario_ibfk_3");

            entity.HasOne(d => d.PerfilAnimal).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PerfilAnimalId)
                .HasConstraintName("comentario_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("comentario_ibfk_1");
        });

        modelBuilder.Entity<Donacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("donacion");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FechaDonacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_donacion");
            entity.Property(e => e.Monto)
                .HasPrecision(10, 2)
                .HasColumnName("monto");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Donacions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("donacion_ibfk_1");
        });

        modelBuilder.Entity<Eventoadopcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("eventoadopcion");

            entity.HasIndex(e => e.UbicacionId, "ubicacion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Eventoadopcions)
                .HasForeignKey(d => d.UbicacionId)
                .HasConstraintName("eventoadopcion_ibfk_1");
        });

        modelBuilder.Entity<Participanteevento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("participanteevento");

            entity.HasIndex(e => e.EventoAdopcionId, "evento_adopcion_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EventoAdopcionId).HasColumnName("evento_adopcion_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.EventoAdopcion).WithMany(p => p.Participanteeventos)
                .HasForeignKey(d => d.EventoAdopcionId)
                .HasConstraintName("participanteevento_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Participanteeventos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("participanteevento_ibfk_2");
        });

        modelBuilder.Entity<Perfilanimal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perfilanimal");

            entity.HasIndex(e => e.AnimalId, "animal_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Perfilanimals)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("perfilanimal_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Perfilanimals)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("perfilanimal_ibfk_2");
        });

        modelBuilder.Entity<Perfilanimalespecial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("perfilanimalespecial");

            entity.HasIndex(e => e.AnimalEspecialId, "animal_especial_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalEspecialId).HasColumnName("animal_especial_id");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_publicacion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.AnimalEspecial).WithMany(p => p.Perfilanimalespecials)
                .HasForeignKey(d => d.AnimalEspecialId)
                .HasConstraintName("perfilanimalespecial_ibfk_1");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Perfilanimalespecials)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("perfilanimalespecial_ibfk_2");
        });

        modelBuilder.Entity<Proveedoradopcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedoradopcion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.InformacionVerificacion)
                .HasColumnType("text")
                .HasColumnName("informacion_verificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Proveedorrescate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("proveedorrescate");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.InformacionVerificacion)
                .HasColumnType("text")
                .HasColumnName("informacion_verificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Ubicacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ubicacion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(255)
                .HasColumnName("ciudad");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Pais)
                .HasMaxLength(255)
                .HasColumnName("pais");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Valoracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("valoracion");

            entity.HasIndex(e => e.PerfilAnimalEspecialId, "perfil_animal_especial_id");

            entity.HasIndex(e => e.PerfilAnimalId, "perfil_animal_id");

            entity.HasIndex(e => e.UsuarioId, "usuario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComentarioAdicional)
                .HasColumnType("text")
                .HasColumnName("comentario_adicional");
            entity.Property(e => e.PerfilAnimalEspecialId).HasColumnName("perfil_animal_especial_id");
            entity.Property(e => e.PerfilAnimalId).HasColumnName("perfil_animal_id");
            entity.Property(e => e.Puntuacion).HasColumnName("puntuacion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.PerfilAnimalEspecial).WithMany(p => p.Valoracions)
                .HasForeignKey(d => d.PerfilAnimalEspecialId)
                .HasConstraintName("valoracion_ibfk_3");

            entity.HasOne(d => d.PerfilAnimal).WithMany(p => p.Valoracions)
                .HasForeignKey(d => d.PerfilAnimalId)
                .HasConstraintName("valoracion_ibfk_2");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Valoracions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("valoracion_ibfk_1");
        });

        modelBuilder.Entity<Veterinario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("veterinario");

            entity.HasIndex(e => e.UbicacionId, "ubicacion_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(255)
                .HasColumnName("correo_electronico");
            entity.Property(e => e.Especialidad)
                .HasMaxLength(255)
                .HasColumnName("especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

            entity.HasOne(d => d.Ubicacion).WithMany(p => p.Veterinarios)
                .HasForeignKey(d => d.UbicacionId)
                .HasConstraintName("veterinario_ibfk_1");
        });

        modelBuilder.Entity<Visitasveterinario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("visitasveterinario");

            entity.HasIndex(e => e.AnimalId, "animal_id");

            entity.HasIndex(e => e.VeterinarioId, "veterinario_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.FechaVisita)
                .HasColumnType("datetime")
                .HasColumnName("fecha_visita");
            entity.Property(e => e.VeterinarioId).HasColumnName("veterinario_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Visitasveterinarios)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("visitasveterinario_ibfk_1");

            entity.HasOne(d => d.Veterinario).WithMany(p => p.Visitasveterinarios)
                .HasForeignKey(d => d.VeterinarioId)
                .HasConstraintName("visitasveterinario_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
