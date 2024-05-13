using AutoMapper;
using GestaoProdutosAg.API.Application.DTOs;
using GestaoProdutosAg.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>();
            //.ForMember(dto => dto.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor));

            CreateMap<Produto, ProdutoDTO>();
                //.ForMember(dto => dto.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor));

            CreateMap<FornecedorDTO, Fornecedor>();
            CreateMap<Fornecedor, FornecedorDTO>();
        }
    }
}
