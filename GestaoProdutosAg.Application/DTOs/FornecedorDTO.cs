using GestaoProdutosAg.API.Domain.Entities;

namespace GestaoProdutosAg.API.Application.DTOs
{
    public class FornecedorDTO
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }

        //public ICollection<ProdutoDTO> Produtos { get; set; }
    }
}
