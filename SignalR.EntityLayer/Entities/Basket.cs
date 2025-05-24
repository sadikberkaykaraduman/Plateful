using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }
        public int BasketProductId { get; set; }
        [ForeignKey("BasketProductId")]
        public Product Product { get; set; }
        public decimal BasketProductCount { get; set; }
        public decimal BasketProductUnitPrice { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public int BasketMenuTableId { get; set; }
        [ForeignKey("BasketMenuTableId")]
        public MenuTable MenuTable { get; set; }
    }
}
