using Microsoft.EntityFrameworkCore;
using OlifransShopCart.DataAcsess.Model;
using OlifransShopCart.Service.Data;
using OlifransShopCart.Service.Infraestrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.Service.Repositories
{
    public class ProdutoRepo : IProduto
    {
        private readonly OlifransDbContext _context;

        public ProdutoRepo(OlifransDbContext context)
        {
            _context = context;
        }

        public void DeleteProduto(Produto produto)
        {
            _context.Produtos.Remove(produto);
        }

        public List<Produto> GetAllProdutos()
        {
            return _context.Produtos.ToList();
        }

        public Produto GetProdutoById(int Id)
        {
            return _context.Produtos.Include(a => a.Categorias).ThenInclude(b => b.Categoria).Where(y => y.Id == Id).FirstOrDefault();
        }



        //public void InsertProduto(Produto produto)
        //{
        //    _context.Produtos.Add(produto);
        //}


        public void InsertProduto(Produto produto, List<int> categorias)
        {
            foreach (var item in categorias)
            {
                produto.Categorias.Add(new ProdutoCategoria()
                {
                    Produto=produto,
                    CategoriaId=item
                });
            }
            _context.Produtos.Add(produto);
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateProduto(Produto produto)
        {
            _context.Produtos.Update(produto);
        }
    }
}
