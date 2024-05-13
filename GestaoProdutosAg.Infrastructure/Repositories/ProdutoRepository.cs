using Azure;
using GestaoProdutosAg.API.Domain.Entities;
using GestaoProdutosAg.API.Domain.Interfaces;
using GestaoProdutosAg.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Produto produto)
        {
            try
            {
                await _context.Produtos.AddAsync(produto);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Produto já cadastrado", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocoreu um erro ao adicionar o Produto.", ex);
            }
        }

        public async Task DeleteAsync(int codigo)
        {
            try
            {
                var produto = await _context.Produtos.FindAsync(codigo);
                if (produto != null)
                {
                    produto.Situacao = false;
                    _context.Produtos.Update(produto);
                    await _context.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro ao deletar o produto", ex);
            }

        }

        public async Task<IEnumerable<Produto>> GetAllAsync(int page, int pageSize)
        {
            try
            {
                var produtos = await _context.Produtos.
                                       Include(p => p.Fornecedor)
                                      .Skip((page - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar os produtos. Verifique.", ex);
            }
        }

        public async Task<Produto> GetByIdAsync(int codigo)
        {
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Codigo == codigo);

                if (produto == null)
                {
                    throw new Exception("Produto não encontrado: " + codigo);
                }

                return produto;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao recuperar o produto: " + codigo);
            }
        }

        public async Task UpdateAsync(Produto produto)
        {
            try
            {
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao editar o produto: " + produto.Codigo);
            }
        }

    }
}
