using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifransShopCart.Web.ViewModels.ProdutoViewModels
{
    public class ProdutoPostViewModel
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Descricao { get; set; }
        public string ProdutoImage { get; set; }
    }
}
