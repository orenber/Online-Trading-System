using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
   public class Supplier
    {
        #region data member
        private uint supplier_id { get; set; }
        private string name { get; set; }
        private uint phone { get; set; }
        private string address { get; set; }
        #endregion







        #region property
        public uint ID
        {

            get { return supplier_id; }
            set { supplier_id = value; }

        }

        public uint Phone
        {

            get { return phone; }
            set { phone = value; }

        }

        public string Name
        {

            get { return name; }
            set { name = value; }

        }

        public string Address
        {

            get { return address; }
            set { address = value; }

        }
        #endregion

    }












}
