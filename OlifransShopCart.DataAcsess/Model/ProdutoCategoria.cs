using OlifransShopCart.DataAcsess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.DataAcsess.Model
{
    public class ProdutoCategoria : BaseEntity
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public Produto Produto { get; set; }
        public Categoria Categoria { get; set; }
    }
}
