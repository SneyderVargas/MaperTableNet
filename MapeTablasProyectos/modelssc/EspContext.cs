using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MapeTablasProyectos.modelssc;

public partial class EspContext : DbContext
{
    public EspContext()
    {
    }

    public EspContext(DbContextOptions<EspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barrio> Barrios { get; set; }

    public virtual DbSet<CentroPoblado> CentroPoblados { get; set; }

    public virtual DbSet<EstacionesSurga> EstacionesSurgas { get; set; }

    public virtual DbSet<Municipi> Municipis { get; set; }

    public virtual DbSet<Sectore> Sectores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=192.168.1.200; Port=3307; Database=esp; Uid=dba_surgas; Pwd=Surg@s2023++;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("barrios");

            entity.HasIndex(e => e.UbicacionSui, "FK_ubica_sui");

            entity.HasIndex(e => new { e.Sector, e.Municipio }, "FkSector");

            entity.HasIndex(e => e.Codigo, "Index_1");

            entity.HasIndex(e => e.Municipio, "Municipio");

            entity.HasIndex(e => e.Sector, "Sectores");

            entity.HasIndex(e => e.Zona, "ZONA0");

            entity.Property(e => e.Codigo)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .HasColumnName("CODIGO");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'1'")
                .HasColumnName("activo");
            entity.Property(e => e.Login)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("LOGIN");
            entity.Property(e => e.Municipio)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("MUNICIPIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .HasDefaultValueSql("''")
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Ruta)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .HasColumnName("RUTA");
            entity.Property(e => e.Sector)
                .HasMaxLength(5)
                .HasDefaultValueSql("''")
                .HasColumnName("SECTOR");
            entity.Property(e => e.UbicacionSui)
                .HasDefaultValueSql("'1'")
                .HasComment("Ubicacion SUI para efectos de Informe SUI")
                .HasColumnName("Ubicacion_SUI");
            entity.Property(e => e.Zona)
                .HasDefaultValueSql("'1'")
                .HasColumnName("ZONA");

            entity.HasOne(d => d.MunicipioNavigation).WithMany(p => p.Barrios)
                .HasForeignKey(d => d.Municipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MUNICIPIO98");
        });

        modelBuilder.Entity<CentroPoblado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("centro_poblado");

            entity.HasIndex(e => e.Coddane, "ukcodigo").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo)
                .HasDefaultValueSql("'0'")
                .HasColumnName("activo");
            entity.Property(e => e.Coddane).HasColumnName("coddane");
            entity.Property(e => e.FechaSistema)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("fecha_sistema");
            entity.Property(e => e.FkMunicipio)
                .HasMaxLength(2)
                .HasDefaultValueSql("'00'")
                .IsFixedLength()
                .HasColumnName("fk_municipio");
            entity.Property(e => e.Login)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("login");
            entity.Property(e => e.Nombrecentro)
                .HasMaxLength(60)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("nombrecentro");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('CENTRO POBLADO','CABECERA MUNICIPAL')")
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<EstacionesSurga>(entity =>
        {
            entity.HasKey(e => e.IdEstacion).HasName("PRIMARY");

            entity.ToTable("estaciones_surgas");

            entity.HasIndex(e => e.TipogasSui, "FK_estaciones_surgas_sui_tipo_gas_id");

            entity.HasIndex(e => e.Servicio, "idx_servicio");

            entity.HasIndex(e => e.Tipogas, "idxtipogas");

            entity.Property(e => e.IdEstacion)
                .HasComment("Especifica el Codigo de la Estacion")
                .HasColumnName("id_estacion");
            entity.Property(e => e.Cabecera)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cabecera");
            entity.Property(e => e.Centro)
                .HasMaxLength(4)
                .HasDefaultValueSql("'0'")
                .HasColumnName("CENTRO");
            entity.Property(e => e.Material)
                .HasMaxLength(4)
                .HasDefaultValueSql("'0'")
                .HasComment("CODIGO DE MATERIAL SAP")
                .HasColumnName("MATERIAL");
            entity.Property(e => e.MercadoCreg)
                .HasMaxLength(240)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasComment("Item par especificar el mercado dependienso de los valores quer envien para el informe")
                .HasColumnName("MERCADO_CREG");
            entity.Property(e => e.Municipio)
                .HasMaxLength(2)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Nombre)
                .HasMaxLength(60)
                .HasDefaultValueSql("''");
            entity.Property(e => e.OrdenInforme)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'")
                .IsFixedLength();
            entity.Property(e => e.PucCostoNiif)
                .HasDefaultValueSql("'0'")
                .HasColumnName("puc_costo_niif");
            entity.Property(e => e.PucCostoTrib)
                .HasDefaultValueSql("'0'")
                .HasColumnName("puc_costo_trib");
            entity.Property(e => e.PucInvenNiif)
                .HasDefaultValueSql("'0'")
                .HasColumnName("puc_inven_niif");
            entity.Property(e => e.PucInvenTrib)
                .HasDefaultValueSql("'0'")
                .HasColumnName("puc_inven_trib");
            entity.Property(e => e.Sector)
                .HasMaxLength(2)
                .HasDefaultValueSql("'0'")
                .HasComment("Linea de producto en SAP")
                .HasColumnName("SECTOR");
            entity.Property(e => e.Servicio)
                .HasMaxLength(1)
                .HasDefaultValueSql("'O'");
            entity.Property(e => e.Solicitante)
                .HasMaxLength(11)
                .HasDefaultValueSql("'0'")
                .HasColumnName("SOLICITANTE");
            entity.Property(e => e.Tipogas)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .HasColumnName("tipogas");
            entity.Property(e => e.TipogasSui)
                .HasDefaultValueSql("'-1'")
                .HasColumnName("tipogas_sui");
        });

        modelBuilder.Entity<Municipi>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("municipi");

            entity.HasIndex(e => e.Codigo, "Index_1");

            entity.HasIndex(e => e.FkAgencia, "fk_agencia_municipio");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.HasIndex(e => e.Departamento, "municipi_ibfk_1");

            entity.Property(e => e.Codigo)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("CODIGO");
            entity.Property(e => e.Dane)
                .HasMaxLength(10)
                .HasDefaultValueSql("''")
                .HasColumnName("DANE");
            entity.Property(e => e.Departamento).HasColumnName("DEPARTAMENTO");
            entity.Property(e => e.Dian18)
                .HasMaxLength(5)
                .HasDefaultValueSql("'00000'")
                .IsFixedLength()
                .HasColumnName("DIAN1_8");
            entity.Property(e => e.FkAgencia)
                .HasDefaultValueSql("'-1'")
                .HasComment("Fk agencia desde base de datos ESP1")
                .HasColumnName("fk_agencia");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(3)
                .IsFixedLength()
                .HasColumnName("LOGIN");
            entity.Property(e => e.MercadoCreeg)
                .HasMaxLength(20)
                .HasColumnName("Mercado_creeg");
            entity.Property(e => e.Msnm)
                .HasDefaultValueSql("'0'")
                .HasComment("Metros Sobre el Nivel del MAR Provisional para el Calculo del Factor de Corrección")
                .HasColumnName("MSNM");
            entity.Property(e => e.Nombre)
                .HasMaxLength(35)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Poder).HasColumnName("PODER");
            entity.Property(e => e.Prioridad).HasColumnName("PRIORIDAD");
            entity.Property(e => e.PucCosteoGas)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("PUC_COSTEO_GAS");
            entity.Property(e => e.PucCosteoInvenGas)
                .HasMaxLength(20)
                .HasDefaultValueSql("''")
                .HasColumnName("PUC_COSTEO_INVEN_GAS");
            entity.Property(e => e.Tipogas)
                .HasMaxLength(30)
                .HasDefaultValueSql("''")
                .HasColumnName("TIPOGAS");
        });

        modelBuilder.Entity<Sectore>(entity =>
        {
            entity.HasKey(e => e.Codigo).HasName("PRIMARY");

            entity.ToTable("sectores");

            entity.HasIndex(e => new { e.Ciclo, e.Municipio }, "Fk_Deta_ciclo");

            entity.HasIndex(e => e.Municipio, "Fk_municipio");

            entity.HasIndex(e => e.Estacion, "fk_estacion");

            entity.HasIndex(e => e.Mercado, "fk_mercado");

            entity.HasIndex(e => new { e.Codigo, e.Ciclo }, "ind_cod_ciclo").IsUnique();

            entity.Property(e => e.Codigo)
                .HasMaxLength(5)
                .HasDefaultValueSql("''")
                .HasColumnName("CODIGO");
            entity.Property(e => e.Ciclo)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("CICLO");
            entity.Property(e => e.Dane)
                .HasDefaultValueSql("'0'")
                .HasColumnName("DANE");
            entity.Property(e => e.Descripcio)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("DESCRIPCIO");
            entity.Property(e => e.Estacion)
                .HasDefaultValueSql("'0'")
                .HasColumnName("ESTACION");
            entity.Property(e => e.Mercado)
                .HasDefaultValueSql("'-1'")
                .HasColumnName("MERCADO");
            entity.Property(e => e.Municipio)
                .HasMaxLength(2)
                .HasDefaultValueSql("''")
                .IsFixedLength()
                .HasColumnName("MUNICIPIO");
            entity.Property(e => e.Ruta)
                .HasMaxLength(4)
                .HasDefaultValueSql("''")
                .HasColumnName("RUTA");
            entity.Property(e => e.TipoGas)
                .HasMaxLength(3)
                .HasDefaultValueSql("''")
                .HasColumnName("Tipo_gas");

            entity.HasOne(d => d.EstacionNavigation).WithMany(p => p.Sectores)
                .HasForeignKey(d => d.Estacion)
                .HasConstraintName("fk_estacion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
