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
        private readonly DataBase _dal;

        private string _firstName;
        private string _lastName;
        private string _city;
        private string _phone;

        private string _userName;
        private string _password;
        private string _email;

        private string _storeName;
        private string _storeAddress;
        private string _marketType;
        #endregion

        public Registration()
        {
            _dal = new DataBase();

        }

        public string FirstName
        {
            get{ return _firstName; }

            set {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        _firstName = value;
                    }
                }
        }

        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _lastName = value;
                }
            }
        }

        public string City
        {
            get { return _city; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _city = value;
                }
            }
        }

        public string Phone
        {
            get { return _phone; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _phone = value;
                }
            }
        }

        public string UserName
        {
            get { return _userName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _userName = value;
                }
            }
        }

        public string Password
        {
            get { return _password; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _password = value;
                }
            }
        }

        public string Email
        {
            get { return _email; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _email = value;
                }
            }
        }

        public string StoreName
        {
            get { return _storeName; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _storeName = value;
                }
            }
        }

        public string StoreAddress
        {
            get { return _storeAddress; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _storeAddress = value;
                }
            }
        }

        public string MarketType
        {
            get { return _marketType; }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _marketType = value;
                }
            }
        }
 


        #region Validate User name Password Compatible

        public bool ValidateRegistration(Registration registration)
        {
            bool valid = true;
            try
            {
                _dal.sc.Open();

                _dal.cmd = new SqlCommand("dbo.spValidateUsernamePassword " +
                 "'"  + registration.Email + "'" +
                 ",'" + registration.Password + "'", _dal.sc);
              

                while (_dal.reader.Read())
                {
                    registration.UserName = Convert.ToString(_dal.reader["UserName"]);
                    registration.Email = Convert.ToString(_dal.reader["Email"]);
                    registration.Password = Convert.ToString(_dal.reader["Password"]);
                }

            }
            catch (Exception ex)
            {
                valid = false;
                
                MessageBox.Show(ex.Message);
            }

            finally
            {
                _dal.sc.Close();

            }

            return valid;
        }

        #endregion
    }
    }
