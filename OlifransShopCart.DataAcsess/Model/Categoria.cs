using OlifransShopCart.DataAcsess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.DataAcsess.Model
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public ICollection<ProdutoCategoria> Produtos { get; set; } = new List<ProdutoCategoria>();
    }
}
