using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProdutosAg.API.Domain.Entities
{
    public class Fornecedor
    {
        [Key]
        public int Codigo {  get; set; }
        public string Descricao { get; set; }
        public string Cnpj { get; set; }

        public ICollection<Produto> Produtos { get; set; }
    }
}
