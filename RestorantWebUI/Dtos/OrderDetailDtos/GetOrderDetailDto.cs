namespace Restorant.WebUI.Dtos.OrderDetailDtos
{
    public class GetOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderDetailProductId { get; set; }
        public int OrderDetailPiece { get; set; }
        public decimal OrderDetailUnitPrice { get; set; }
        public decimal OrderDetailTotalPrice { get; set; }
        public int OrderDetailOrderId { get; set; }
    }
}
