using GestaoProdutosAg.API.Application.Services.Interfaces;
using GestaoProdutosAg.API.Domain.Interfaces;
using GestaoProdutosAg.API.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestaoProdutosAg.API.Domain.Entities;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using PagedList;

namespace GestaoProdutosAg.API.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(ProdutoDTO produtoDTO)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(produtoDTO);
                await _produtoRepository.AddAsync(produto);
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

        public async Task<bool> DeleteAsync(int codigo)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(codigo);
                if (produto == null)
                {
                    return false; 
                }

                await _produtoRepository.DeleteAsync(codigo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao deletar o produto " + ex.Message);
            }
        }
        public async Task<IPagedList<ProdutoDTO>> GetAllAsync(int page, int pageSize)
        {
            try
            {
                var produtos = await _produtoRepository.GetAllAsync(page, pageSize);
                var produtosDto = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

                var produtosPagedList = produtosDto.ToPagedList(page, pageSize);
                return produtosPagedList;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocorreu um erro ao recuperar os produtos", ex);
            }
        }

        public async Task<ProdutoDTO> GetByIdAsync(int codigo)
        {
            try
            {
                var produto = await _produtoRepository.GetByIdAsync(codigo);
                var produtoDto = _mapper.Map<ProdutoDTO>(produto);
                return produtoDto;
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(int id, ProdutoDTO produto)
        {
            try
            {
                Produto prod = _mapper.Map<Produto>(produto);
                prod.Codigo = id;
                await _produtoRepository.UpdateAsync(prod);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
