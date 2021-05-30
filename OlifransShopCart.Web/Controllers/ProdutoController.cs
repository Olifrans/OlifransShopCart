using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OlifransShopCart.Service.Infraestrutura;
using OlifransShopCart.Web.ViewModels.ProdutoViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OlifransShopCart.DataAcsess.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OlifransShopCart.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProduto _produto;
        private IMapper _mapper;
        private readonly ICategoria _categoria;

        public ProdutoController(IProduto produto, IMapper mapper, ICategoria categoria)
        {
            _produto = produto;
            _mapper = mapper;
            _categoria = categoria;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var produtoList = _produto.GetAllProdutos();
            var mappedProdutos = _mapper.Map<List<ProdutoViewModel>>(produtoList);
            return View(mappedProdutos);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var singleProduto = _produto.GetProdutoById(id);
            var mappedProduto = _mapper.Map<DetailsProdutoViewModel>(singleProduto);
            return View(mappedProduto);
        }



        [HttpGet]
        public IActionResult Create()
        {
            CreateProdutoViewModel vm = new CreateProdutoViewModel();
            vm.Categorias = _categoria.GetAllCategorias().Select(x => new SelectListItem()
            {
                Text=x.Nome,
                Value=x.Id.ToString(),
            }).ToList();
            return View(vm);
        }












        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produto = _produto.GetProdutoById(id);
            var mappedProduto = _mapper.Map<EditProdutoViewModel>(produto);
            return View(mappedProduto);
        }


        

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produto = _produto.GetProdutoById(id);
            var mappedProduto = _mapper.Map<DeleteProdutoViewModel>(produto);
            return View(mappedProduto);
        }

        [HttpPost]
        public IActionResult Delete(DeleteProdutoViewModel vm)
        {
            var mappedProdutoinModel = _mapper.Map<Produto>(vm);
            _produto.DeleteProduto(mappedProdutoinModel);
            _produto.Save();
            return RedirectToAction("Index", "Produtos");
        }

        [HttpPost]
        public IActionResult Edit(EditProdutoViewModel vm)
        {
            var mappedProdutoinModel = _mapper.Map<Produto>(vm);
            _produto.UpdateProduto(mappedProdutoinModel);
            _produto.Save();
            return RedirectToAction("Index", "Produtos");
        }

        [HttpPost]
        public IActionResult Create(CreateProdutoViewModel vm)
        {
            var mappedProdutoinModel = _mapper.Map<Produto>(vm);
            _produto.InsertProduto(mappedProdutoinModel);
            _produto.Save();
            return RedirectToAction("Index", "Produtos");
        }


    }
}
