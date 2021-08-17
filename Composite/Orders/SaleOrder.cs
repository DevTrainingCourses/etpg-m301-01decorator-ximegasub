namespace Composite.Orders
{
    using Composite.Products;
    using System;
    using System.Collections.Generic;

    public class SaleOrder
    {

        private long OrderId;
        private string Customer;
        private List<SimpleProduct> Products = new List<SimpleProduct>();

        public SaleOrder(long orderId, string customer)
        {
            this.OrderId = orderId;
            this.Customer = customer;
        }

        public double GetPrice()
        {
            double price = 0d;
            foreach (SimpleProduct child in Products)
            {
                price += child.Price;
            }
            return price;
        }

        public void AddProduct(SimpleProduct product)
        {
            Products.Add(product);
        }

        public void PrintOrder()
        {
            Console.WriteLine("\\\n============================================="
                    + "\nOrden: " + OrderId + "\nCustomer: " + Customer
                    + "\nProducts:\n");
            foreach (SimpleProduct prod in Products)
            {
                Console.WriteLine(prod.Name + "\t\t\t$ "
                        + prod.Price.ToString("###,##0.0000"));
            }
            Console.WriteLine("Total: " + GetPrice().ToString("###,##0.0000")
                    + "\n=============================================");
        }

        public long GetOrderId()
        {
            return OrderId;
        }

        public void SetOrderId(long orderId)
        {
            this.OrderId = orderId;
        }

        public string GetCustomer()
        {
            return Customer;
        }

        public void SetCustomer(string customer)
        {
            this.Customer = customer;
        }

        public List<SimpleProduct> GetProducts()
        {
            return Products;
        }

        public void SetProducts(List<SimpleProduct> products)
        {
            this.Products = products;
        }
    }
}
