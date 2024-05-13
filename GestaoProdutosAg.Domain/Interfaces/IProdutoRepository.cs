using GestaoProdutosAg.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(int codigo);
        Task<IEnumerable<Produto>> GetAllAsync(int page, int pageSize);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int codigo);
    }
}
