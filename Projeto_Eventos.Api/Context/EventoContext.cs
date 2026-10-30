using Microsoft.EntityFrameworkCore;
using Projeto_Eventos.Api.Entities;

namespace Projeto_Eventos.Api.Context
{
    public class EventoContext : DbContext
    {
        public EventoContext(DbContextOptions<EventoContext> options) : base(options)  { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mapeamento das entidades para as tabelas
            modelBuilder.Entity<Evento>().ToTable("TB_EVENTOS", t =>  t.HasCheckConstraint("ct_preco", "[PRECO] >= 0"));
            modelBuilder.Entity<Convidado>().ToTable("TB_CONVIDADOS");
            modelBuilder.Entity<Inscricao>().ToTable("TB_INSCRICOES");

            // mapeamento das ptopriedades para as colunas
            modelBuilder.Entity<Evento>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<Evento>().Property(p => p.Descricao).HasColumnName("DESCRICAO").HasMaxLength(45).IsRequired();
            modelBuilder.Entity<Evento>().Property(p => p.Data).HasColumnName("DATAEVENTO").IsRequired();
            modelBuilder.Entity<Evento>().Property(p => p.Preco).HasColumnName("PRECO").IsRequired();

            modelBuilder.Entity<Convidado>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<Convidado>().Property(p => p.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Convidado>().Property(p => p.Email).HasColumnName("EMAIL").HasMaxLength(200).IsRequired();

            modelBuilder.Entity<Inscricao>().Property(p => p.Id).HasColumnName("ID");
            modelBuilder.Entity<Inscricao>().Property(p => p.EventoId).HasColumnName("IDEVENTO");
            modelBuilder.Entity<Inscricao>().Property(p => p.ConvidadoId).HasColumnName("IDCONVIDADO");
            modelBuilder.Entity<Inscricao>().Property(p => p.Preco).HasColumnName("PRECO").IsRequired();
            modelBuilder.Entity<Inscricao>().Property(p => p.DataInscricao).HasColumnName("DATAINSCRICAO").IsRequired()
                .HasDefaultValueSql("GETDATE()", "df_data");
        }
    }
}
