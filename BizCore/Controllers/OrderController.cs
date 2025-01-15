using System.Numerics;
using BizCore.Data;
using BizCore.Models;
using BizCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Index()
        {
            var orders = _context.Orders
       .Select(o => new OrderViewModel
       {
           OrderId = o.OrderId,
           OrderType = o.OrderTypeId == 1 ? "Customer Order" : "Supplier Order",
           CustomerName = o.CustomerId != null ? o.Customer.Name : null,
           SupplierName = o.SupplierId != null ? o.Supplier.Name : null,
           OrderDate = o.OrderDate,
           TotalPrice = o.OrderItems.Sum(i => i.Quantity * i.UnitPrice)
       }).ToList();
            return View(orders);
        }
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Where(o => o.OrderId == id)
                .Select(o => new OrderDetailsViewModel
                {
                    OrderId = o.OrderId,
                    OrderType = o.OrderTypeId == 1 ? "Customer Order" : "Supplier Order",
                    CustomerName = o.CustomerId != null ? o.Customer.Name : null,
                    SupplierName = o.SupplierId != null ? o.Supplier.Name : null,
                    OrderDate = o.OrderDate,
                    TotalPrice = o.OrderItems.Sum(i => i.Quantity * i.UnitPrice),
                    Items = o.OrderItems.Select(i => new OrderItemViewModel
                    {
                        ProductName = i.Product.Name,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice,
                        TotalPrice = i.Quantity * i.UnitPrice
                    }).ToList()
                })
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        // GET: Order/Edit/3
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Fetch order details from the database
            var order = _context.Orders
                .Include(o => o.OrderItems) // Include related order items
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound(); // Return 404 if the order does not exist
            }

            // Prepare the ViewModel
            var viewModel = new OrderEditViewModel
            {
                OrderId = order.OrderId,
                OrderTypeId = order.OrderTypeId,
                CustomerId = order.CustomerId,
                SupplierId = order.SupplierId,
                OrderDate = order.OrderDate,
                Customers = _context.Customers
                    .Select(c => new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.CustomerId.ToString()
                    })
                    .ToList(),
                Suppliers = _context.Suppliers
                    .Select(s => new SelectListItem
                    {
                        Text = s.Name,
                        Value = s.SupplierId.ToString()
                    })
                    .ToList(),
                Products = _context.Products
                    .Select(p => new SelectListItem
                    {
                        Text = p.Name,
                        Value = p.ProductId.ToString()
                    })
                    .ToList(),
                OrderItems = order.OrderItems
                    .Select(oi => new OrderItemEditViewModel
                    {
                        OrderItemId = oi.OrderItemId,
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        // POST: Order/Edit/2
        // POST: Order/Edit/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OrderEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing order from the database
                var order = _context.Orders
                    .Include(o => o.OrderItems) // Include related order items
                    .FirstOrDefault(o => o.OrderId == viewModel.OrderId);

                if (order == null)
                {
                    return NotFound(); // Return 404 if the order does not exist
                }

                // Update the main order fields
                order.OrderTypeId = viewModel.OrderTypeId;
                order.CustomerId = viewModel.CustomerId;
                order.SupplierId = viewModel.SupplierId;
                order.OrderDate = viewModel.OrderDate;

                // Remove existing order items before adding new ones
                order.OrderItems.Clear();

                // Add updated order items to the order
                foreach (var item in viewModel.OrderItems)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };

                    order.OrderItems.Add(orderItem);
                }

                // Save the changes to the database
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Order updated successfully!";
                return RedirectToAction("Index"); // Redirect to the order list or details page
            }

            // If validation fails, re-populate dropdowns and return the view with errors
            viewModel.Customers = _context.Customers
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.CustomerId.ToString()
                })
                .ToList();
            viewModel.Suppliers = _context.Suppliers
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.SupplierId.ToString()
                })
                .ToList();
            viewModel.Products = _context.Products
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.ProductId.ToString()
                })
                .ToList();

            return View(viewModel); // Return the view with validation errors
        }

        // GET: Order/Delete/3
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            var viewModel = new OrderDeleteViewModel
            {
                OrderId = order.OrderId,
                OrderType = order.OrderTypeId == 1 ? "Customer Order" : "Supplier Order",
                CustomerName = _context.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId)?.Name,
                SupplierName = _context.Suppliers.FirstOrDefault(s => s.SupplierId == order.SupplierId)?.Name,
                OrderDate = order.OrderDate,
                TotalItems = order.OrderItems.Count,
                TotalPrice = order.OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice)
            };

            return View(viewModel);
        }

        // POST: Order/Delete/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            _context.OrderItems.RemoveRange(order.OrderItems);
            _context.Orders.Remove(order);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}


  




