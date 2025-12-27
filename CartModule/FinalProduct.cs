namespace CartModule
{

    public class FinalProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string PromotionDescription { get; set; }
    }
}
