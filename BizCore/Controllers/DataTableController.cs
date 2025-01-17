using Microsoft.AspNetCore.Mvc;
using BizCore.Models.ViewModels;
using System.Data;

namespace BizCore.Controllers
{
    public class DataTableController : Controller
    {
        private readonly DataTableCreator _tableCreator;

        public DataTableController()
        {
            _tableCreator = new DataTableCreator();
        }

        public IActionResult Index()
        {
            // Create DataTables
            var orderTable = _tableCreator.CreateOrderTable();
            orderTable.Rows.Add(1, 101, null, 1, DateTime.Now);
            orderTable.Rows.Add(2, null, 201, 2, DateTime.Now.AddDays(-1));

            var customerTable = _tableCreator.CreateCustomerTable();
            customerTable.Rows.Add(101, "John Doe", "john@example.com", "123-456-7890");
            customerTable.Rows.Add(102, "Jane Smith", "jane@example.com", "098-765-4321");

            // Store tables in ViewBag for now
            ViewBag.OrderTable = orderTable;
            ViewBag.CustomerTable = customerTable;

            return View();
        }

        public IActionResult Details(string tableName)
        {
            DataTable dataTable;

            // Example: Load specific table based on input
            switch (tableName)
            {
                case "Order":
                    dataTable = _tableCreator.CreateOrderTable();
                    dataTable.Rows.Add(1, 101, null, 1, DateTime.Now);
                    dataTable.Rows.Add(2, null, 201, 2, DateTime.Now.AddDays(-1));
                    break;
                case "Customer":
                    dataTable = _tableCreator.CreateCustomerTable();
                    dataTable.Rows.Add(101, "John Doe", "john@example.com", "123-456-7890");
                    dataTable.Rows.Add(102, "Jane Smith", "jane@example.com", "098-765-4321");
                    break;
                default:
                    dataTable = null;
                    break;
            }

            if (dataTable == null)
                return NotFound();

            ViewBag.DataTable = dataTable;
            return View();
        }
    }
}
