using OlifransShopCart.DataAcsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.Service.Infraestrutura
{
    public interface IProduto
    {
        List<Produto> GetAllProdutos();
        Produto GetProdutoById(int Id);
        void InsertProduto(Produto produto, List<int> categorias);
        void UpdateProduto(Produto produto);
        void DeleteProduto(Produto produto);
        void Save();
    }
}
