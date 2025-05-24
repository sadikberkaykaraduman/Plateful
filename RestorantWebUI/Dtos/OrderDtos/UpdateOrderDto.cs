namespace Restorant.WebUI.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int OrderId { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
