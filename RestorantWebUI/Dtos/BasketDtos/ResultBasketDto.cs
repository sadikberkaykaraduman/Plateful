

namespace Restorant.WebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int BasketId { get; set; }
        public int BasketProductId { get; set; }
        public decimal BasketProductCount { get; set; }
        public decimal BasketProductUnitPrice { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public int BasketMenuTableId { get; set; }
    }
}
