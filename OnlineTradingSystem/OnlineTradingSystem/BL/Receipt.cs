using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Receipt
    {
        private uint _bid;
        private uint _total;
        private DateTime _date;
        private DateTime _time;
        private string _type;


        public uint Bid { get => _bid ; set=>_bid = value ; }
        public uint Total { get => _total; set => _total = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public string Type { get => _type; set => _type = value; }


    }




}
