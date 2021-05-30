using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifransShopCart.Web.ViewModels.ProdutoViewModels
{
    public class CreateProdutoViewModel
    {
        public string Nome { get; set; }

        public float Preco { get; set; }

        public string Descricao { get; set; }

        public IFormFile ProdutoImage { get; set; }

        public List<SelectListItem> Categorias { get; set; }
    }
}
