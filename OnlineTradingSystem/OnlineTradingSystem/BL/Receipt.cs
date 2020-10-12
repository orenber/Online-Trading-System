using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Receipt
    {
        private uint bid { get; set; }
        private DateTime date { get; set; }
        private DateTime time { get; set; }
        private string type { get; set; }
        private uint total { get; set; }
    }
}
