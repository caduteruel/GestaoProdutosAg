using AutoMapper;
using GestaoProdutosAg.API.Application.DTOs;
using GestaoProdutosAg.API.Application.Services.Interfaces;
using GestaoProdutosAg.API.Domain.Entities;
using GestaoProdutosAg.API.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
           _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(FornecedorDTO fornecedorDTO)
        {
            try
            {
                Fornecedor fornecedor = _mapper.Map<Fornecedor>(fornecedorDTO);
                await _fornecedorRepository.AddAsync(fornecedor);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task DeleteAsync(FornecedorDTO fornecedor)
        {
            throw new NotImplementedException();
        }


        public Task<IEnumerable<FornecedorDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<FornecedorDTO> GetByIdAsync(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FornecedorDTO fornecedor)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<FornecedorDTO>> IFornecedorService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<FornecedorDTO> IFornecedorService.GetByIdAsync(int codigo)
        {
            throw new NotImplementedException();
        }
    }
}
