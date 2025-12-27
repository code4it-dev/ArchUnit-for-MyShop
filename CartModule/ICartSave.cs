using Common;

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
            MyLogger.LogInfo($"Product {finalProduct.Name} saved to cart with price {finalProduct.DiscountedPrice}");
        }
    }
}
