namespace Composite.Products
{
    public class SimpleProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; }

        public SimpleProduct(string name, double price, string brand)
        {
            this.Name = name;
            this.Price = price;
            this.Brand = brand;
        }
    }    
}
