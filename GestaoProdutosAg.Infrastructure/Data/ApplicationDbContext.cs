using GestaoProdutosAg.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração de Produto
            modelBuilder.Entity<Produto>()
                .HasKey(p => p.Codigo); 

            // Configuração de Fornecedor
            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.Codigo); 

            modelBuilder.Entity<Fornecedor>()
                .Property(f => f.Cnpj)
                .IsRequired();

            // Configuração do relacionamento
            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fornecedor) 
                .WithMany(f => f.Produtos) 
                .HasForeignKey(p => p.CodigoFornecedor) 
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
