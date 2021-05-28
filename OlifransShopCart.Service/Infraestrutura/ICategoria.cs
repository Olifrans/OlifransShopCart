using OlifransShopCart.DataAcsess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlifransShopCart.Service.Infraestrutura
{
    public interface ICategoria
    {
        List<Categoria> GetAllCategorias();
        Categoria GetCategoriaById(int Id);
        void InsertCategoria(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        void DeleteCategoria(Categoria categoria);
        void Save();
    }
}
