using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.DiscountDtos
{
    public class GetDiscountDto
    {
        public int DiscountId { get; set; }
        public string DiscountTitle { get; set; }
        public string DiscountAmount { get; set; }
        public string DiscountDescription { get; set; }
        public string DiscountImageUrl { get; set; }
        public bool DiscountStatus { get; set; }
    }
}
