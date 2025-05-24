namespace Restorant.WebUI.Dtos.OrderDtos
{
    public class ResultOrderDto
    {
        public int OrderId { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
