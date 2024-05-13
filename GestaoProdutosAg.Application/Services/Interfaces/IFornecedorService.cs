using GestaoProdutosAg.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Application.Services.Interfaces
{
    public interface IFornecedorService
    {
        Task<FornecedorDTO> GetByIdAsync(int codigo);
        Task<IEnumerable<FornecedorDTO>> GetAllAsync();
        Task AddAsync(FornecedorDTO fornecedor);
        Task UpdateAsync(FornecedorDTO fornecedor);
        Task DeleteAsync(FornecedorDTO fornecedor);

    }
}
