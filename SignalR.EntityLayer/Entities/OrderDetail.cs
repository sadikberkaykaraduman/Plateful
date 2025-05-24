using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderDetailProductId { get; set; }
        [ForeignKey("OrderDetailProductId")]
        public Product Product { get; set; }
        public int OrderDetailPiece { get; set; }
        public decimal OrderDetailUnitPrice { get; set; }
        public decimal OrderDetailTotalPrice { get; set; }
        public int OrderDetailOrderId { get; set; }
        [ForeignKey("OrderDetailOrderId")]
        public Order Order { get; set; }
    }
}
