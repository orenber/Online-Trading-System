using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Customer
    {
        private uint id;
        private string name;
        private uint phone_number;

        public uint Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public uint Phone_number { get => phone_number; set => phone_number = value; }
       
    }
}