namespace Restorant.WebUI.Dtos.OrderDetailDtos
{
    public class ResultOrderDetailWithProductByOrderIdDto
    {
        public int OrderDetailId { get; set; }
        public string OrderDetailProductName { get; set; }
        public int OrderDetailPiece { get; set; }
        public decimal OrderDetailUnitPrice { get; set; }
        public decimal OrderDetailTotalPrice { get; set; }
        public int OrderDetailOrderId { get; set; }
    }
}
