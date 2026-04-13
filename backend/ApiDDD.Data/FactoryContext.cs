using Microsoft.EntityFrameworkCore;
using ApiDDD.Domain.Models;
using ApiDDD.Domain.Models.Enums;

namespace ApiDDD.Data
{
    /// <summary>
    /// DbContext principal da aplicação ControleGastos.
    /// Centraliza as entidades persistidas e configura relacionamentos e regras do banco.
    /// </summary>
    public class FactoryContext : DbContext
    {
        public FactoryContext(DbContextOptions<FactoryContext> options) : base(options)
        { }

        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Transacao> Transacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da entidade Pessoa
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Nome).IsRequired().HasMaxLength(200);
                entity.Property(p => p.Idade).IsRequired();
            });

            // Configuração da entidade Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Descricao).IsRequired().HasMaxLength(400);
                entity.Property(c => c.Finalidade).IsRequired();
            });

            // Configuração da entidade Transacao com relacionamentos e cascade delete
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Descricao).IsRequired().HasMaxLength(400);
                entity.Property(t => t.Valor).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(t => t.Tipo).IsRequired();

                // Ao deletar uma Pessoa, suas transações são deletadas em cascata
                entity.HasOne(t => t.Pessoa)
                      .WithMany(p => p.Transacoes)
                      .HasForeignKey(t => t.PessoaId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Categoria não deleta transações em cascata
                entity.HasOne(t => t.Categoria)
                      .WithMany(c => c.Transacoes)
                      .HasForeignKey(t => t.CategoriaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ── Seed Data ─────────────────────────────────────────────────────────────

            modelBuilder.Entity<Pessoa>().HasData(
                new Pessoa { Id = 1, Nome = "João Silva",   Idade = 30 },
                new Pessoa { Id = 2, Nome = "Maria Souza",  Idade = 25 },
                new Pessoa { Id = 3, Nome = "Pedro Alves",  Idade = 17 }
            );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Descricao = "Alimentação",    Finalidade = FinalidadeCategoria.DESPESA }
                // new Categoria { Id = 2, Descricao = "Transporte",     Finalidade = FinalidadeCategoria.DESPESA },
                // new Categoria { Id = 3, Descricao = "Salário",        Finalidade = FinalidadeCategoria.RECEITA },
                // new Categoria { Id = 4, Descricao = "Freelance",      Finalidade = FinalidadeCategoria.RECEITA },
                // new Categoria { Id = 5, Descricao = "Lazer",          Finalidade = FinalidadeCategoria.DESPESA },
                // new Categoria { Id = 6, Descricao = "Investimentos",  Finalidade = FinalidadeCategoria.AMBAS }
            );

            modelBuilder.Entity<Transacao>().HasData(
                new Transacao { Id = 1, Descricao = "Supermercado",        Valor = 350.00m, Tipo = TipoTransacao.DESPESA, CategoriaId = 1, PessoaId = 1 }
                // new Transacao { Id = 2, Descricao = "Uber para o trabalho", Valor = 45.50m,  Tipo = TipoTransacao.DESPESA, CategoriaId = 2, PessoaId = 1 },
                // new Transacao { Id = 3, Descricao = "Salário de março",    Valor = 5000.00m, Tipo = TipoTransacao.RECEITA, CategoriaId = 3, PessoaId = 1 },
                // new Transacao { Id = 4, Descricao = "Almoço",              Valor = 32.00m,  Tipo = TipoTransacao.DESPESA, CategoriaId = 1, PessoaId = 2 },
                // new Transacao { Id = 5, Descricao = "Projeto freelance",   Valor = 1200.00m, Tipo = TipoTransacao.RECEITA, CategoriaId = 4, PessoaId = 2 },
                // new Transacao { Id = 6, Descricao = "Cinema",              Valor = 55.00m,  Tipo = TipoTransacao.DESPESA, CategoriaId = 5, PessoaId = 3 },
                // new Transacao { Id = 7, Descricao = "Lanche",              Valor = 18.00m,  Tipo = TipoTransacao.DESPESA, CategoriaId = 1, PessoaId = 3 }
            );
        }
    }
}