using BizCore.Data;
using BizCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BizCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products/Index
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        // GET: Products/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Products model)
        {
            if (ModelState.IsValid)
            {
                // Handle image upload
                if (model.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                    string filePath = Path.Combine(wwwRootPath, "uploads", fileName);

                    // Ensure the directory exists before saving the file
                    string uploadsDirectory = Path.Combine(wwwRootPath, "uploads");
                    if (!Directory.Exists(uploadsDirectory))
                    {
                        Directory.CreateDirectory(uploadsDirectory);
                    }

                    // Write the file to the specified directory
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(fileStream);
                    }

                    model.PictureUrl = $"/uploads/{fileName}";
                }

                _context.Products.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        // GET: Products/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Products model)
        {
            if (id != model.ProductId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

                if (product != null)
                {
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.PurchasePrice = model.PurchasePrice;
                    product.SalesPrice = model.SalesPrice;
                    product.InStock = model.InStock;

                    // Handle image upload
                    if (model.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                        string filePath = Path.Combine(wwwRootPath, "uploads", fileName);

                        // Ensure the directory exists
                        Directory.CreateDirectory(Path.Combine(wwwRootPath, "uploads"));

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(fileStream);
                        }

                        product.PictureUrl = $"/uploads/{fileName}";
                    }

                    _context.Products.Update(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                // Optionally delete the image file
                if (!string.IsNullOrEmpty(product.PictureUrl))
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, product.PictureUrl.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
