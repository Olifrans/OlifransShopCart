using OlifransShopCart.DataAcsess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.DataAcsess.Model
{
    public class Produto : BaseEntity
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Descricao { get; set; }
        public string ProdutoImage { get; set; }
        public ICollection<ProdutoCategoria> Categorias { get; set; } = new List<ProdutoCategoria>();
    }
}
