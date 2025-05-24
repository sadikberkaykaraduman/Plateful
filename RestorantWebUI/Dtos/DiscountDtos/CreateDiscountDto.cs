namespace Restorant.WebUI.Dtos.DiscountDtos
{
    public class CreateDiscountDto
    {
        public string DiscountTitle { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountImageUrl { get; set; }
        public bool DiscountStatus { get; set; }
    }
}
