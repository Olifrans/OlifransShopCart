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
using Microsoft.AspNetCore.Hosting;
using OlifransShopCart.Web.Helper;

namespace OlifransShopCart.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProduto _produto;
        private IMapper _mapper;
        private readonly ICategoria _categoria;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProdutoController(IProduto produto, IMapper mapper, ICategoria categoria, IWebHostEnvironment WebHostEnvironment)
        {
            _produto = produto;
            _mapper = mapper;
            _categoria = categoria;
            webHostEnvironment = WebHostEnvironment;
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


        [HttpPost]
        public IActionResult Create(CreateProdutoViewModel vm)
        {
            FileUpload fileUpload = new FileUpload(webHostEnvironment);
            var selectedCategorias = vm.Categorias.Where(x => x.Selected).Select(x => x.Value).Select(int.Parse);
            string ImageFile = fileUpload.UploadFile(vm.ProdutoImage);
            var produto = new ProdutoPostViewModel
            {
                Nome = vm.Nome,
                Preco = vm.Preco,
                Descricao = vm.Descricao,
                ProdutoImage = ImageFile
            };
            var mappedProduto = _mapper.Map<Produto>(produto);
            _produto.InsertProduto(mappedProduto, selectedCategorias);
            //_produto.InsertProduto(mappedProduto, (List<int>)selectedCategorias);
            _produto.Save();
            return RedirectToAction("index");
        }

        //visto tutp 09 posição 07:00 









        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    var produto = _produto.GetProdutoById(id);
        //    var mappedProduto = _mapper.Map<EditProdutoViewModel>(produto);
        //    return View(mappedProduto);
        //}


        

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var produto = _produto.GetProdutoById(id);
        //    var mappedProduto = _mapper.Map<DeleteProdutoViewModel>(produto);
        //    return View(mappedProduto);
        //}

        //[HttpPost]
        //public IActionResult Delete(DeleteProdutoViewModel vm)
        //{
        //    var mappedProdutoinModel = _mapper.Map<Produto>(vm);
        //    _produto.DeleteProduto(mappedProdutoinModel);
        //    _produto.Save();
        //    return RedirectToAction("Index", "Produtos");
        //}

        //[HttpPost]
        //public IActionResult Edit(EditProdutoViewModel vm)
        //{
        //    var mappedProdutoinModel = _mapper.Map<Produto>(vm);
        //    _produto.UpdateProduto(mappedProdutoinModel);
        //    _produto.Save();
        //    return RedirectToAction("Index", "Produtos");
        //}

        //[HttpPost]
        //public IActionResult Create(CreateProdutoViewModel vm)
        //{
        //    var mappedProdutoinModel = _mapper.Map<Produto>(vm);
        //    _produto.InsertProduto(mappedProdutoinModel);
        //    _produto.Save();
        //    return RedirectToAction("Index", "Produtos");
        //}


    }
}
