using Finanzauto.Pagos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.Pagos.Infrastructure.Persistence;

public class ClientsDbContext : DbContext
{
    public ClientsDbContext(DbContextOptions<ClientsDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public virtual DbSet<Payment> FzPagosOnLines { get; set; }
    public virtual DbSet<Param> FzParametros { get; set; }
    public virtual DbSet<PaymentOrigin> FzTipoOrigenPagos { get; set; }
    public virtual DbSet<PaymentType> FzTipoPagos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Idpago);

            entity.ToTable("fz_PagosOnLine");

            entity.Property(e => e.Idpago)
                .ValueGeneratedNever()
                .HasColumnName("IDPago");
            entity.Property(e => e.CodEstadoRespuestaSignature)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.DatosRespuestaPayU).HasMaxLength(2200);
            entity.Property(e => e.EstadoLectura).HasColumnName("estadoLectura");
            entity.Property(e => e.FechaSincronizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaTransaccion).HasColumnType("datetime");
            entity.Property(e => e.FechaValidacionPayu)
                .HasColumnType("datetime")
                .HasColumnName("fecha_validacion_payu");
            entity.Property(e => e.IdtipoOrigen).HasColumnName("IDTipoOrigen");
            entity.Property(e => e.IdtipoPago)
                .HasDefaultValue(1)
                .HasColumnName("IDTipoPago");
            entity.Property(e => e.ReferencePolPayu)
                .HasMaxLength(255)
                .HasColumnName("reference_pol_payu");
            entity.Property(e => e.ResponseCodePolPayu)
                .HasMaxLength(255)
                .HasColumnName("response_code_pol_payu");
            entity.Property(e => e.ResponseMessagePolPayu)
                .HasMaxLength(255)
                .HasColumnName("response_message_pol_payu");
            entity.Property(e => e.StatePolPayu)
                .HasMaxLength(255)
                .HasColumnName("state_pol_payu");
            entity.Property(e => e.ValorPayu)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("valor_payu");
            entity.Property(e => e.ValorWeb).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdtipoOrigenNavigation).WithMany(p => p.FzPagosOnLines)
                .HasForeignKey(d => d.IdtipoOrigen)
                .HasConstraintName("FK_fz_PagosOnLine_fz_TipoOrigenPago");
        });

        modelBuilder.Entity<Param>(entity =>
        {
            entity.HasKey(e => e.Idparametro);

            entity.ToTable("fz_Parametros");

            entity.Property(e => e.Idparametro)
                .ValueGeneratedNever()
                .HasColumnName("IDParametro");
            entity.Property(e => e.Parametro).HasMaxLength(50);
        });

        modelBuilder.Entity<PaymentOrigin>(entity =>
        {
            entity.ToTable("fz_TipoOrigenPago");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago);

            entity.ToTable("fz_TipoPagos");

            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");
        });

        base.OnModelCreating(modelBuilder);
    }
}
