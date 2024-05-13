using GestaoProdutosAg.API.Application.DTOs;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Application.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> GetByIdAsync(int codigo);
        Task<IPagedList<ProdutoDTO>> GetAllAsync(int page, int pageSize);
        Task AddAsync(ProdutoDTO produto);
        Task UpdateAsync(int id, ProdutoDTO produto);
        Task<bool> DeleteAsync(int codigo);
    }
}
