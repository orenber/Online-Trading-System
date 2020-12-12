using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Store
    {
        private uint _id;
        private string _name;
        private string _address;

        public uint Id { get => _id; set => _id = value;}
        public string Name { get => _name; set => _name = value; }
        public string Address { get => _address; set => _address = value; }

    }
}
