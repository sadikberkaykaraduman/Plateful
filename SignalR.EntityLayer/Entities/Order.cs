using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string OrderTableNumber { get; set; }
        public string OrderDescription { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalPrice { get; set; }
        public bool OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
