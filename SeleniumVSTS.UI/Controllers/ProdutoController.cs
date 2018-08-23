using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeleniumVSTS.UI.Interfaces;
using SeleniumVSTS.UI.Models;

namespace SeleniumVSTS.UI.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        // GET: Produto
        public ActionResult Index()
        {            
            return View(_produtoRepository.Selecionar());
        }

        // GET: Produto/Details/5
        public ActionResult Details(Guid id)
        {
            var prod = _produtoRepository.ObterPorId(id);

            if (prod == null)            
                return RedirectToAction(nameof(Index));            

            return View(prod);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    model.ProdutoId = Guid.NewGuid();
                    _produtoRepository.Adicionar(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(Guid id)
        {
            var prod = _produtoRepository.ObterPorId(id);

            if (prod == null)
                return RedirectToAction(nameof(Index));

            return View(prod);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    model.ProdutoId = Guid.NewGuid();
                    _produtoRepository.Atualizar(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(Guid id)
        {
            var prod = _produtoRepository.ObterPorId(id);

            if (prod == null)
                return RedirectToAction(nameof(Index));

            return View(prod);
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProdutoViewModel model)
        {
            try
            {
                _produtoRepository.Remover(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}