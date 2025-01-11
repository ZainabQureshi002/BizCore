using BizCore.Data;
using BizCore.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BizCore.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }

        [HttpGet]
        [HttpGet]
        public IActionResult Details(int id)
        {
            // Find supplier by ID
            var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                return NotFound(); // Return 404 if not found
            }
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
      
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                // Add the new supplier to the database
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            // If validation fails, return the same view with errors
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Update(supplier);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);  
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var supplier = _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = _context.Suppliers.SingleOrDefault(s => s.SupplierId == id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

}

