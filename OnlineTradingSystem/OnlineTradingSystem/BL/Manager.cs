using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem.BL
{
    class Manager
    {
        private uint id;
        private uint bid;

        private string firstName;
        private string lastName;
        private string city;
        private string phone;

        private string userName;
        private string password;
        private string email;


        public uint Id { get => id; set => id = value; }
        public uint Bid { get => bid; set => bid = value; }

        public string FirstName { get => firstName; set =>firstName= value;}
        public string LastName { get => lastName; set => lastName = value; }
        public string City { get => city; set => city = value; }
        public string Phone { get => phone; set => phone = value; }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
    }
}
