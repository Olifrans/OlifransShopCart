using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlifransShopCart.DataAcsess.Model;
using OlifransShopCart.Repo.Infraestrutura;
using OlifransShopCart.Web.ViewModels.CategoriaViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controle Categorias
/// </summary>

namespace OlifransShopCart.Web.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoria _categoria;
        private IMapper _mapper;


        public CategoriasController(ICategoria categoria, IMapper mapper)
        {
            _categoria = categoria;
            _mapper = mapper;
        }
              
        public IActionResult Index()
        {
            var AllCategorias = _categoria.GetAllCategorias();
            var mappedCategorias = _mapper.Map<List<CategoriaViewModel>>(AllCategorias);
            return View(mappedCategorias);



            //List<CategoriaViewModel> vm = new List<CategoriaViewModel>();                        
            //foreach (var item in AllCategorias)
            //{
            //    vm.Add(new CategoriaViewModel
            //    {
            //        Id = item.Id,
            //        Nome = item.Nome,
            //    });
            //}
            //Nuget install-package automapper
            //Nuget add-migration init
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoria = _categoria.GetCategoriaById(id);
            var mappedCategoria = _mapper.Map<EditCategoriaViewModel>(categoria);
            return View(mappedCategoria);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var categoria = _categoria.GetCategoriaById(id);
            var mappedCategoria = _mapper.Map<DetailsCategoriaViewModel>(categoria);
            return View(mappedCategoria);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categoria = _categoria.GetCategoriaById(id);
            var mappedCategoria = _mapper.Map<DeleteCategoriaViewModel>(categoria);
            return View(mappedCategoria);
        }

        [HttpPost]
        public IActionResult Delete(DeleteCategoriaViewModel vm)
        {
            var mappedCategoriainModel = _mapper.Map<Categoria>(vm);
            _categoria.DeleteCategoria(mappedCategoriainModel);
            _categoria.Save();
            return RedirectToAction("Index", "Categorias");
        }

        [HttpPost]
        public IActionResult Edit(EditCategoriaViewModel vm)
        {           
            var mappedCategoriainModel = _mapper.Map<Categoria>(vm);
            _categoria.UpdateCategoria(mappedCategoriainModel);
            _categoria.Save();
            return RedirectToAction("Index", "Categorias");
        }

        [HttpPost]
        public IActionResult Create(CreateCategoriaViewModel vm)
        {
            var mappedCategoriainModel = _mapper.Map<Categoria>(vm);
            _categoria.InsertCategoria(mappedCategoriainModel);
            _categoria.Save();
            return RedirectToAction("Index", "Categorias");
        }


    }
}
