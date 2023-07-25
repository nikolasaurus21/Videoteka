using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ViewResult Index()
        {
            var customers = _context.Customers
                .Include(c => c.MembershipType)
                .Include(x => x.CustomerType)
                .Select(x => new CustomerViewModel
                {
                    Id= x.Id,
                    Name = x.Name,
                    MembershipTypeName = x.MembershipType.Name,
                    CustomerTypeName= x.CustomerType.Name,
                    BirthDate = (DateTime)x.BirthDate,
                    Notifications= x.Notifications,
                })
                .ToList();

            return View(customers);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customer customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.MembershipTypes = _context.MembershipTypes.ToList();
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();

            var viewModel = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                BirthDate = (DateTime)customer.BirthDate,
                MembershipTypeId = customer.MembershipTypeId,
                CustomerTypeId = customer.CustomerTypeId,
                Notifications = customer.Notifications
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Edit(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = _context.Customers.Find(viewModel.Id);

                if (customer == null)
                {
                    return HttpNotFound();
                }

                customer.Name = viewModel.Name;
                customer.BirthDate = viewModel.BirthDate;
                customer.MembershipTypeId = viewModel.MembershipTypeId;
                customer.CustomerTypeId = viewModel.CustomerTypeId;
                customer.Notifications = viewModel.Notifications;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MembershipTypes = _context.MembershipTypes.ToList();
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();

            return View(viewModel);
        }
        
        public ActionResult Create()
        {
            
            var viewModel = new CustomerViewModel();
            ViewBag.MembershipTypes = _context.MembershipTypes.ToList();
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                var customer = new Customer
                {
                    Name = viewModel.Name,
                    BirthDate = viewModel.BirthDate,
                    MembershipTypeId = viewModel.MembershipTypeId,
                    CustomerTypeId = viewModel.CustomerTypeId,
                    Notifications = viewModel.Notifications
                };

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.MembershipTypes = _context.MembershipTypes.ToList();
            ViewBag.CustomerTypes = _context.CustomerTypes.ToList();

            return View(viewModel);
        }
        
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers
                .Include(m => m.MembershipType)
                .Include(c => c.CustomerType)
                .FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var customerViewModel = new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                MembershipTypeName = customer.MembershipType.Name,
                CustomerTypeName = customer.CustomerType.Name,
                BirthDate = (DateTime)customer.BirthDate,
                Notifications = customer.Notifications,
            };

            return View(customerViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}