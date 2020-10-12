using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
     
    [Serializable]
    class Product
    {

        private uint code { get; set; }
        private uint price { get; set; }
        private uint supplier_id { get; set; }

        private string name { get; set; }
        private string type { get; set; }
        private string category { get; set; }
        private string manufactor { get; set; }
        private string description { get; set; }

        private string url { get; set; }
        private byte[] img { get; set; }
     
    }





}
