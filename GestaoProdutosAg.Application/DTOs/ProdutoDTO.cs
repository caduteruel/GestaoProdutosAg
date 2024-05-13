namespace GestaoProdutosAg.API.Application.DTOs
{
    public class ProdutoDTO
    {
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }

        public void Validate()
        {
            if (DataValidade < DataFabricacao)
            {
                throw new ArgumentException("A data de validade não pode ser menor que a data de fabricação.");
            }
        }
    }
}
