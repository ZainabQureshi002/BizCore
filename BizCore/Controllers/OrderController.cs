using BizCore.Data;
using BizCore.Models;
using BizCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BizCore.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            var model = new OrderCreateViewModel
            {
                Products = _context.Products.Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString()
                }).ToList(),
                Suppliers = _context.Suppliers.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.SupplierId.ToString()
                }).ToList(),
                Customers = _context.Customers.Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.CustomerId.ToString()
                }).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    OrderTypeId = model.Order.OrderTypeId,
                    OrderDate = model.Order.OrderDate,
                    CustomerId = model.Order.CustomerId,
                    SupplierId = model.Order.SupplierId
                };

                // Add OrderItems to the Order
                foreach (var item in model.Order.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };

                    order.OrderItems.Add(orderItem);
                }



                _context.Orders.Add(order);
                
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
