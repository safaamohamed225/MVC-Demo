namespace Demo.Models.ProductSampleData
{
    public class ProductSampleData
    {

        public List<Product> Products;

        public ProductSampleData()
        {
            Products = new List<Product>();
            Products.Add(new Product { Id = 1, Name = "phone1", Description = "p1", Price = 10000, Image = "1.jfif" });
            Products.Add(new Product { Id = 2, Name = "phone2", Description = "p2", Price = 20000, Image = "1.jfif" });
            Products.Add(new Product { Id = 3, Name = "phone3", Description = "p3", Price = 30000, Image = "2.jfif" });
            Products.Add(new Product { Id = 4, Name = "phone4", Description = "p4", Price = 40000, Image = "3.jfif" });
            Products.Add(new Product { Id = 5, Name = "phone5", Description = "p5", Price = 50000, Image = "3.jfif" });

        }
        public List<Product> GetAll()
        {
            return Products;
        }
        public Product GetById(int id)
        {
            return Products.FirstOrDefault(d => d.Id == id);
        }
    }
}
