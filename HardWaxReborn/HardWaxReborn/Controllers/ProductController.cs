using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HardWaxReborn.DAL;
using HardWaxReborn.Domain;
using HardWaxReborn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

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
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Price = x.Price


            }) ;

            return View(productViewModels);
        }

        [HttpPost]
        public ActionResult Order(CustomerViewModel customer)
        {
            CompositeViewModel model = new CompositeViewModel();
            TempData["CustomerId"] = customer.Id;
            TempData["CurrentUser"] = customer.FirstName;
            IEnumerable<Product> productDomains = UOW.ProductRepository.GetAll();
            IEnumerable<ProductViewModel> productViewModels = productDomains.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Price = x.Price


            });
           // IEnumerable<Store> storeDomains = UOW.StoreRepository.GetAll().ToList();
          //  List<StoreViewModel> storeViewModels = new List<StoreViewModel>();
          //  foreach(var store in storeDomains)
         //   {
         //       storeViewModels.Add(new StoreViewModel
          //      {
          //          Id = store.Id
          //      });
                
          //  }
      
          //  model.Products = productViewModels;
          //  model.Stores = storeViewModels;
          //  model.Customer = customer;
         //   model.Cart = new ShoppingCartViewModel();
         //   model.Order = new OrderViewModel();
            return View(productViewModels);

        }

        public ActionResult PlaceOrder (int quantity, int productId)
        {
            ShoppingCart cart = new ShoppingCart();
            //Store store = UOW.StoreRepository.GetAll().Where(s => s.Stock.ContainsKey(productId)).FirstOrDefault();
            Store s = new Store
            {
                Id = 1,
                Name = "Guitar Center"
            };

            cart.Stores.Add(s);
            cart.ProductId_Quantity.Add(productId, quantity);
            Customer customer = UOW.CustomerRepository.GetById((int)TempData["CustomerId"]);
            cart.Customer = customer;
            OrderService os = new OrderService(UOW.ProductRepository);
            Order order = os.PlaceOrder(cart);
            UOW.OrderRepository.Create(order, cart);
            UOW.Save();
            UOW.Dispose();


            return View();
             
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
            return View(productViewModel);
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
