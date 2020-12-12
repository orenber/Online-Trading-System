using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
     
    [Serializable]
    class Product
    {

        private uint _code;
        private uint _price;
        private uint _supplier_id;

        private string _name;
        private string _type;
        private string _category;
        private string _manufactor;
        private string _description;

        private string _url;
        private byte[] _img;



        public uint Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public uint Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public uint Supplier_id
        {
            get { return _supplier_id; }
            set { _supplier_id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Manufactor
        {
            get { return _manufactor; }
            set { _manufactor = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }


        public byte[] Img
        {
            get { return _img; }
            set { _img = value; }
        }









    }





}
