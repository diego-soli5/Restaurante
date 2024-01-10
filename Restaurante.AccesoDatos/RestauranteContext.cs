using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Restaurante.Entidades;

namespace Restaurante.AccesoDatos;

public partial class RestauranteContext : DbContext
{
    public RestauranteContext()
    {
    }

    public RestauranteContext(DbContextOptions<RestauranteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TrestCliente> TrestCliente { get; set; }

    public virtual DbSet<TrestMenu> TrestMenu { get; set; }

    public virtual DbSet<TrestMesa> TrestMesa { get; set; }

    public virtual DbSet<TrestReservacion> TrestReservacion { get; set; }

    public virtual DbSet<TrestTipomenu> TrestTipomenu { get; set; }

    public virtual DbSet<TrestUsuario> TrestUsuario { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrestCliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Cliente");

            entity.ToTable("TREST_CLIENTE");

            entity.Property(e => e.Id).HasColumnName("TN_IdCliente");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TcAp1)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap1");
            entity.Property(e => e.TcAp2)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Ap2");
            entity.Property(e => e.TcCorreoElectronico)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_CorreoElectronico");
            entity.Property(e => e.TcNombre)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
            entity.Property(e => e.TcNumTelefono)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TC_NumTelefono");
        });

        modelBuilder.Entity<TrestMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TREST_ME__7B8DE5AA5AF3F637");

            entity.ToTable("TREST_MENU");

            entity.Property(e => e.Id).HasColumnName("TN_IdMenu");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TcDscMenu)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_DscMenu");
            entity.Property(e => e.TdPrecio)
                .HasColumnType("decimal(19, 2)")
                .HasColumnName("TD_Precio");
            entity.Property(e => e.TnIdTipoMenu).HasColumnName("TN_IdTipoMenu");

            entity.HasOne(d => d.TrestTipomenu).WithMany(p => p.TrestMenu)
                .HasForeignKey(d => d.TnIdTipoMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TREST_MEN__TN_Id__300424B4");
        });

        modelBuilder.Entity<TrestMesa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Mesa");

            entity.ToTable("TREST_MESA");

            entity.Property(e => e.Id).HasColumnName("TN_IdMesa");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TcDscMesa)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_DscMesa");
        });

        modelBuilder.Entity<TrestReservacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TREST_RE__46A5B8DC98A9EC8F");

            entity.ToTable("TREST_RESERVACION");

            entity.Property(e => e.Id).HasColumnName("TN_NumReservacion");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TfFecReserva)
                .HasColumnType("datetime")
                .HasColumnName("TF_FecReserva");
            entity.Property(e => e.TnCantidad).HasColumnName("TN_Cantidad");
            entity.Property(e => e.TnIdCliente).HasColumnName("TN_IdCliente");
            entity.Property(e => e.TnIdMenu).HasColumnName("TN_IdMenu");
            entity.Property(e => e.TnIdMesa).HasColumnName("TN_IdMesa");

            entity.HasOne(d => d.TnIdClienteNavigation).WithMany(p => p.TrestReservacion)
                .HasForeignKey(d => d.TnIdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TREST_RES__TN_Id__32E0915F");

            entity.HasOne(d => d.TnIdMenuNavigation).WithMany(p => p.TrestReservacion)
                .HasForeignKey(d => d.TnIdMenu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TREST_RES__TN_Id__31EC6D26");

            entity.HasOne(d => d.TnIdMesaNavigation).WithMany(p => p.TrestReservacion)
                .HasForeignKey(d => d.TnIdMesa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TREST_RES__TN_Id__30F848ED");
        });

        modelBuilder.Entity<TrestTipomenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_TipoMenu");

            entity.ToTable("TREST_TIPOMENU");

            entity.Property(e => e.Id).HasColumnName("TN_IdTipoMenu");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TcDscTipoMenu)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_DscTipoMenu");
        });

        modelBuilder.Entity<TrestUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TREST_US__1182D56D0A49D553");

            entity.ToTable("TREST_USUARIO");

            entity.HasIndex(e => e.TcCorreoElectronico, "UQ__TREST_US__44745D74A7B1BB28").IsUnique();

            entity.HasIndex(e => e.TcNombreUsuario, "UQ__TREST_US__7C7E1FE0EF7DA100").IsUnique();

            entity.Property(e => e.Id).HasColumnName("TN_IdUsuario");
            entity.Property(e => e.TbEstado).HasColumnName("TB_Estado");
            entity.Property(e => e.TcContrasena)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("TC_Contrasena");
            entity.Property(e => e.TcCorreoElectronico)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TC_CorreoElectronico");
            entity.Property(e => e.TcNombre)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_Nombre");
            entity.Property(e => e.TcNombreUsuario)
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("TC_NombreUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
