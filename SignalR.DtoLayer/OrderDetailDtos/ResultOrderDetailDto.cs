using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDetailDtos
{
    public class ResultOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderDetailProductId { get; set; }
        public int OrderDetailPiece { get; set; }
        public decimal OrderDetailUnitPrice { get; set; }
        public decimal OrderDetailTotalPrice { get; set; }
        public int OrderDetailOrderId { get; set; }
    }
}
