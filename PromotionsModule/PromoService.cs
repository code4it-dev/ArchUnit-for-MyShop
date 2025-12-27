namespace PromotionsModule
{
    public class PromoService : IPromotionsService
    {
        public IEnumerable<Promotion> GetActivePromotions()
        {
            return new List<Promotion>
            {
                new Promotion { Id = 1, Description = "Summer Sale", DiscountPercentage = 15.0m },
                new Promotion { Id = 2, Description = "Black Friday Deal", DiscountPercentage = 25.0m }
            };
        }
    }
}
