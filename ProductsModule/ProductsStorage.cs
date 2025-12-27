namespace ProductsModule
{
    public class ProductsStorage : IProductsStorage
    {
        public Product GetProductDetails(int productId)
        {
            // Simulate fetching product details
            return new Product { Id = productId, Name = "Spaghetti" };
        }
    }
}
