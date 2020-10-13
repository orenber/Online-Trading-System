using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace OnlineTradingSystem.DAL
{
    public class Registration
    {
        #region data_member
        private DataBase dal;

        private string firstName;
        private string lastName;
        private string city;
        private string phone;

        private string userName;
        private string password;
        private string email;

        private string storeName;
        private string storeAddress;
        private string marketType;
        #endregion

        public Registration()
        {
            dal = new DataBase();

        }

        public string FirstName
        {
            get{ return firstName; }

            set {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        firstName = value;
                    }
                }
        }

        public string LastName
        {
            get { return lastName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

        public string City
        {
            get { return city; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    city = value;
                }
            }
        }

        public string Phone
        {
            get { return phone; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    phone = value;
                }
            }
        }

        public string UserName
        {
            get { return userName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    userName = value;
                }
            }
        }

        public string Password
        {
            get { return password; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                }
            }
        }

        public string Email
        {
            get { return email; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    email = value;
                }
            }
        }

        public string StoreName
        {
            get { return storeName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    storeName = value;
                }
            }
        }

        public string StoreAddress
        {
            get { return storeAddress; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    storeAddress = value;
                }
            }
        }

        public string MarketType
        {
            get { return marketType; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    marketType = value;
                }
            }
        }
 


        #region Validate User name Password Compatible

        public bool validateRegistration(Registration registration)
        {
            bool valid = true;
            try
            {
                dal.sc.Open();

                dal.cmd = new SqlCommand("dbo.spValidateUsernamePassword " +
                 "'"  + registration.email + "'" +
                 ",'" + registration.password + "'", dal.sc);
              

                while (dal.reader.Read())
                {
                    registration.userName = Convert.ToString(dal.reader["UserName"]);
                    registration.email = Convert.ToString(dal.reader["Email"]);
                    registration.password = Convert.ToString(dal.reader["Password"]);
                }

            }
            catch (Exception ex)
            {
                valid = false;
                
                MessageBox.Show(ex.Message);
            }

            finally
            {
                dal.sc.Close();

            }

            return valid;
        }

        #endregion
    }
    }
