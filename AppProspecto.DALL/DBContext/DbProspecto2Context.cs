using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AppProspecto.MODELS;

namespace AppProspecto.DALL.DBContext;

public partial class DbProspecto2Context : DbContext
{
    public DbProspecto2Context()
    {
    }

    public DbProspecto2Context(DbContextOptions<DbProspecto2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<FileData> FileData { get; set; }

    public virtual DbSet<ProspectoFile> ProspectoFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DB_Prospecto2; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FileData>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__FileData__775AFE7207B6D6B4");

            entity.Property(e => e.IdFile).HasColumnName("idFile");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Extension)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("extension");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdProspecto).HasColumnName("idProspecto");
            entity.Property(e => e.MimeType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mimeType");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Path)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("path");

            entity.HasOne(d => d.IdProspectoNavigation).WithMany(p => p.FileData)
                .HasForeignKey(d => d.IdProspecto)
                .HasConstraintName("FK__FileData__idPros__3E52440B");
        });

        modelBuilder.Entity<ProspectoFile>(entity =>
        {
            entity.HasKey(e => e.IdProspecto).HasName("PK__Prospect__B7A63E96AE3974CD");

            entity.ToTable("ProspectoFile");

            entity.Property(e => e.IdProspecto).HasColumnName("idProspecto");
            entity.Property(e => e.Contacto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("contacto");
            entity.Property(e => e.Detalle)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("detalle");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.Fachadaimg)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fachadaimg");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Idauditor).HasColumnName("idauditor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("razonSocial");
            entity.Property(e => e.Url)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
