namespace FullStack.WebAPI.Data
{
    public class ProductService
    {
        public static List<Product> products = new()
        {
            new Product{ Id = 1, Name="Ipone 15"},
            new Product{ Id = 2, Name ="Macbook Pro"},
            new Product{ Id = 3, Name = "Samsung S21 5g"},
            new Product{Id = 4, Name="Bluz"}
        };

        //public static List<Category> categories = new List<Category>()
        //{
        //    new Category{ Id = 1, Name ="Elektronik"},
        //    new Category{ Id = 2, Name ="Giyim"}
        //};

        public static Product Create(string name)
        {
            var id = products.Last().Id + 1;
            var product = new Product
            {
                Id = id,
                Name = name,
            };
            products.Add(product);
            return product;
        }

        public static void Update(Product product)
        {
            var updatedProduct = products.SingleOrDefault(x => x.Id == product.Id);
            if (updatedProduct != null)
            {
                updatedProduct.Name = product.Name;
            }
        }

        public static void Delete(int id)
        {
            var removedProduct = products.SingleOrDefault(x => x.Id == id);
            if (removedProduct != null)
            {
                products.Remove(removedProduct);
            }

        }

    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
