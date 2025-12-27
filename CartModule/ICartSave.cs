namespace CartModule
{
    public interface ICartSave
    {
        void Save(FinalProduct finalProduct);
    }

    public class CartSave : ICartSave
    {
        public void Save(FinalProduct finalProduct)
        {
            // Logic to save the final product to the cart

            Console.WriteLine($"Product {finalProduct.Name} saved to cart with price {finalProduct.DiscountedPrice}");
        }
    }
}
