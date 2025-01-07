using BizCore.Data;
using Microsoft.AspNetCore.Mvc;

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
            var suppliers= _context.Suppliers.ToList();
            return View(suppliers);
        }
    }
}
