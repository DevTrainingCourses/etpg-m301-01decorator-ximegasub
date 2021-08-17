namespace Composite.Products
{
    using System;
    using System.Collections.Generic;

    public class CompositeProduct
    {
        private List<SimpleProduct> Products = new List<SimpleProduct>();

        public CompositeProduct(String name)
        {

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

        public void SetPrice(double price)
        {
            throw new NotSupportedException();
        }

        public void AddProduct(SimpleProduct product)
        {
            this.Products.Add(product);
        }

        public bool RemoveProduct(SimpleProduct product)
        {
            return this.Products.Remove(product);
        }
    }
}