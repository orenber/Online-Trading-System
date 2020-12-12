using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Stock
    {
        private uint _code;
        private uint _bid;
        private uint _units;

        public uint Code { get => _code; set => _code = value; }
        public uint Bid { get => _bid; set => _bid = value; }
        public uint Units { get => _units; set => _units = value; }

    }
}
