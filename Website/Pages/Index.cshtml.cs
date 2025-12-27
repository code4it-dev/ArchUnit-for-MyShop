using CartModule;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductsModule;
using PromotionsModule;
using System.Threading.Tasks;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductsStorage _productsStorage;
        private readonly IPromotionsService _promotionsService;
        private readonly ICartSave _cart;

        public IndexModel(IProductsStorage productsStorage, IPromotionsService promotionsService, ICartSave cart)
        {
            _productsStorage = productsStorage;
            _promotionsService = promotionsService;
            _cart = cart;
        }

        public async Task OnGet()
        {
            var product = GetProduct(123);
            var promotions = GetPromotions();
            var finalProductInfo = ApplyPromotionsToProduct(product, promotions);
            SaveToCart(finalProductInfo);

        }

        private void SaveToCart(FinalProduct finalProductInfo)
        {
            _cart.Save(finalProductInfo);
        }

        private FinalProduct ApplyPromotionsToProduct(Product product, IEnumerable<Promotion> promotions)
        {
            var validPromo = promotions.FirstOrDefault();
            if (validPromo != null)
            {
                var discountedPrice = product.Price - (product.Price * validPromo.DiscountPercentage / 100);
                return new FinalProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    OriginalPrice = product.Price,
                    DiscountedPrice = discountedPrice,
                    PromotionDescription = validPromo.Description
                };
            }
            else
            {
                return new FinalProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    OriginalPrice = product.Price,
                    DiscountedPrice = product.Price,
                    PromotionDescription = null
                };
            }
        }

        private IEnumerable<Promotion> GetPromotions()
        {
            return _promotionsService.GetActivePromotions();
        }

        public Product GetProduct(int productId)
        {
            return _productsStorage.GetProductDetails(productId);
        }
    }
}
