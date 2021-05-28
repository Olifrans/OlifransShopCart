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
    public class CategoriaRepo : ICategoria
    {
        private readonly OlifransDbContext _context;
        public CategoriaRepo(OlifransDbContext context)
        {
            _context = context;
        }

        public void DeleteCategoria(Categoria categoria)
        {
            _context.Categorias.Remove(categoria);
        }

        public List<Categoria> GetAllCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetCategoriaById(int Id)
        {
            return _context.Categorias.Where(a => a.Id == Id).FirstOrDefault();
        }

        public void InsertCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateCategoria(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
        }
    }
}
