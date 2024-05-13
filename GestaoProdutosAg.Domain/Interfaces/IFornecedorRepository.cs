using GestaoProdutosAg.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> GetByIdAsync(int codigo);
        Task<IEnumerable<Fornecedor>> GetAllAsync();
        Task AddAsync(Fornecedor fornecedor);
        Task UpdateAsync(Fornecedor fornecedor);
        Task DeleteAsync(Fornecedor fornecedor);
    }
}
