using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDtos
{
    public class ResultBasketWithProduct
    {
        public int BasketId { get; set; }
        public int BasketProductId { get; set; }
        public string BasketProductName { get; set; }
        public decimal BasketProductCount { get; set; }
        public decimal BasketProductUnitPrice { get; set; }
        public decimal BasketTotalPrice { get; set; }
        public int BasketMenuTableId { get; set; }
    }
}
