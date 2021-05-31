using AutoMapper;
using OlifransShopCart.DataAcsess.Model;
using OlifransShopCart.Web.ViewModels.CategoriaViewModels;
using OlifransShopCart.Web.ViewModels.ProdutoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlifransShopCart.Web.Helper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Categoria, EditCategoriaViewModel>().ReverseMap();
            CreateMap<Categoria, DetailsCategoriaViewModel>();
            CreateMap<Categoria, DeleteCategoriaViewModel>().ReverseMap();
            CreateMap<CreateCategoriaViewModel, Categoria>();


            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Produto, DetailsProdutoViewModel>().
                ForMember(dest=>dest.CategoriaNomes, opt=>opt.MapFrom(src=>src.Categorias.Select(x=>x.Categoria.Nome).ToList()));

            CreateMap<ProdutoPostViewModel, Produto>();

            //CreateMap<Produto, EditProdutoViewModel>().ReverseMap();           
            //CreateMap<Produto, DeleteProdutoViewModel>().ReverseMap();
            //CreateMap<CreateProdutoViewModel, Produto>();


        }
    }
}
