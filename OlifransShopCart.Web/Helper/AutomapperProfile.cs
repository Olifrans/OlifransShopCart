using AutoMapper;
using OlifransShopCart.DataAcsess.Model;
using OlifransShopCart.Web.ViewModels.CategoriaViewModels;
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
        }
    }
}
