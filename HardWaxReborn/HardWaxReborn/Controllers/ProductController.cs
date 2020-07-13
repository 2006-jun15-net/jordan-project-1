using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardWaxReborn.DAL;
using HardWaxReborn.Domain;
using HardWaxReborn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HardWaxReborn.Controllers
{
    public class ProductController : Controller
    {
        public UnitOfWork UOW { get; }

        public ProductController(UnitOfWork uow)
        {
            UOW = uow ?? throw new ArgumentNullException(nameof(uow));
        }
        // GET: ProductController
        public ActionResult Index()
        {
            IEnumerable<Product> productDomains = UOW.ProductRepository.GetAll();
            IEnumerable<ProductViewModel> productViewModels = productDomains.Select(x => new ProductViewModel
            {
                Name = x.Name,
                Type = x.Type,
                Price = x.Price


            });

            return View(productViewModels);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product product = UOW.ProductRepository.GetById(id);
            ProductViewModel productViewModel = new ProductViewModel{
                Name = product.Name,
                Type = product.Type,
                Price = product.Price
                
            };
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
