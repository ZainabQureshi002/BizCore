using System.Data;

namespace BizCore.Models.ViewModels
{
    public class DataTableCreator
    {
        public DataTable CreateOrderTable()
        {
            var orderTable = new DataTable("Order");

            orderTable.Columns.Add("OrderId", typeof(int));
            orderTable.Columns.Add("CustomerId", typeof(int));
            orderTable.Columns.Add("SupplierId", typeof(int));
            orderTable.Columns.Add("OrderTypeId", typeof(int));
            orderTable.Columns.Add("OrderDate", typeof(DateTime));

            return orderTable;
        }

        public DataTable CreateOrderItemTable()
        {
            var orderItemTable = new DataTable("OrderItem");

            orderItemTable.Columns.Add("OrderItemId", typeof(int));
            orderItemTable.Columns.Add("OrderId", typeof(int)); // Foreign Key to Order
            orderItemTable.Columns.Add("ProductId", typeof(int));
            orderItemTable.Columns.Add("Quantity", typeof(int));
            orderItemTable.Columns.Add("UnitPrice", typeof(decimal));

            return orderItemTable;
        }

        public DataTable CreateCustomerTable()
        {
            var customerTable = new DataTable("Customer");

            customerTable.Columns.Add("CustomerId", typeof(int));
            customerTable.Columns.Add("Name", typeof(string));
            customerTable.Columns.Add("Email", typeof(string));
            customerTable.Columns.Add("Phone", typeof(string));

            return customerTable;
        }

        public DataTable CreateSupplierTable()
        {
            var supplierTable = new DataTable("Supplier");

            supplierTable.Columns.Add("SupplierId", typeof(int));
            supplierTable.Columns.Add("Name", typeof(string));
            supplierTable.Columns.Add("Email", typeof(string));
            supplierTable.Columns.Add("Phone", typeof(string));

            return supplierTable;
        }

        public DataTable CreateOrderTypeTable()
        {
            var orderTypeTable = new DataTable("OrderType");

            orderTypeTable.Columns.Add("OrderTypeId", typeof(int));
            orderTypeTable.Columns.Add("TypeName", typeof(string));

            return orderTypeTable;
        }

        public DataTable CreateProductTable()
        {
            var productTable = new DataTable("Product");

            productTable.Columns.Add("ProductId", typeof(int));
            productTable.Columns.Add("Name", typeof(string));
            productTable.Columns.Add("Price", typeof(decimal));

            return productTable;
        }
    }
}

