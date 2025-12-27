namespace PromotionsModule
{
    public interface IPromotionsService
    {
        IEnumerable<Promotion> GetActivePromotions();
    }
}
