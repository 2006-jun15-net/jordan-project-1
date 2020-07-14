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
    public class CustomerController : Controller
    {
        public UnitOfWork UOW { get; set; }

        public CustomerController(UnitOfWork uow)
        {
            UOW = uow;

        }
   
        // GET: CustomerController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomerViewModel cvm)
        {
           Customer customer = UOW.CustomerRepository.GetAll().Where(c => c.UserName == cvm.UserName).FirstOrDefault();
            CustomerViewModel viewModel = new CustomerViewModel();
            if (customer == null)
            {
                viewModel.FirstName = cvm.FirstName;
                viewModel.LastName = cvm.LastName;
                viewModel.UserName = cvm.UserName;
                viewModel.Id = 404;
                // return RedirectToAction(nameof(Create),viewModel);
               return RedirectToAction(nameof(Create), new { Id = 404, FirstName = cvm.FirstName, LastName = cvm.LastName, UserName = cvm.UserName });
            } else
            {
                viewModel.Id = customer.Id;
               return RedirectToAction(nameof(Details),new {Id = (viewModel.Id) });
            }
            
        }



        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
           var customer = UOW.CustomerRepository.GetById(id);
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.FirstName = customer.FirstName;
            customerViewModel.LastName = customer.LastName;
            customerViewModel.UserName = customer.UserName;
            return View(customerViewModel);
        }



        // POST: CustomerController/Create
        [HttpGet]
        
        public ActionResult Create(int id, string firstName, string lastName, string userName)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var customer = new Customer(id, firstName, lastName, userName);
                    UOW.CustomerRepository.Insert(customer);
                    UOW.Save();
                    var tempCustomer = UOW.CustomerRepository.GetAll().Where(c => c.UserName == userName).FirstOrDefault();
                    int tempId = tempCustomer.Id;
                    UOW.Dispose();
                    return RedirectToAction(nameof(Details),new { id = (tempId) });
                }
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
