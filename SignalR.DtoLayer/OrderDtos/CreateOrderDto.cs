using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDtos
{
    public class CreateOrderDto
    {
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public bool OrderStatus { get; set; }
    }
}
