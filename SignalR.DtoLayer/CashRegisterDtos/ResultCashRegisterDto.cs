using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.CashRegisterDtos
{
    public class ResultCashRegisterDto
    {
        public int CashRegisterId { get; set; }
        public decimal CashRegisterAmount { get; set; }
    }
}
