using GestaoProdutosAg.API.Domain.Entities;
using GestaoProdutosAg.API.Domain.Interfaces;
using GestaoProdutosAg.API.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationDbContext _context;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            try
            {
                await _context.Fornecedores.AddAsync(fornecedor);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Fornecedor já cadastrado.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocoreu um erro ao adicionar o Fornecedor.");
            }
        }

        public Task DeleteAsync(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fornecedor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> GetByIdAsync(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }
    }
}
