using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Domain.Entities
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool Situacao { get; set;}
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }
        public Fornecedor Fornecedor { get; set; }

    }
}
