﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineTradingSystem
{
  public  class Uregistration
    {

        
        #region DAta Member
        //DAta Member
        private string password;
        private string email;
        private string username;
        private string marketname;
        private string storename;
   

        #endregion

        #region constructor
        //defulte c'tor
        public   Uregistration()
        {
 
        }

        //1.oveloded constructor
        public Uregistration(string Password, string Usernamem, string Marketname, string Tabelname)
        {
            password = Password;
            username = Usernamem;
            marketname = Marketname;
            storename = Tabelname;
        }

        //2.oveloded constructor
        public Uregistration(string Password, string Username,string Email)
        {
            password = Password;
            username = Username;
            email = Email;

        }

        #endregion

        #region Properties
        //Propertise Method
        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        public string Password
        {
            get { return password; }
            set { password = value; }

        }

        public string Username
        {

            get { return username; }
            set { username = value; }

        }

        public string Marketname
        {
            get { return marketname; }
            set { marketname = value; }

        }

        public string Storename
        {
            get { return storename; }
            set { storename = value; }

        } 
        #endregion

     
    }




    [Serializable]
     class Product
    {
        public Int32 ID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public DateTime DateUpdate { get; set; }
        public string Description { get; set; }
        public string Manufactore { get; set; }
        public byte[] Img { get; set; }
        public string Url { get; set; }



        #region Method
        /* find the next id number that is not listed in the
         * data base and  not in the data gridview
         */
        public int FindNextNum(List<Int32> NumberId)
        {
           
            
            int Next = 1;

            for (int j = 0; NumberId.Count > j; j++)
            {
                for (int i = 0; NumberId.Count > i; i++)
                {


                    if (NumberId[i] == Next)
                    {
                       
                        Next ++;
                        continue;

                    }




                }
                


            }
            return Next;
        }
        // add product to the List
        public List<Product> AddList(List<Product> products, List<Int32> NumbersId)

        {
            List<Int32> Newnumberid = new List<Int32>();
            for (Int32 i = 0; products.Count > i; i++)
            {
                Newnumberid.Add(products[i].ID);
            
            }


             
            NumbersId = (NumbersId.Union(Newnumberid)).ToList();


                products.Add(new Product()
                {
                    ID = FindNextNum(NumbersId),

                    DateUpdate = DateTime.Now

                });



            return products;
        
        
        }
        #endregion

    }

    [Serializable]
     class Goods_bought
     {
        public Int32 OrderID { get; set; }
        public Int32 CustomerId { get; set; }
        
        public  int StoreId { get; set; }
        public Int32 ProductID { get; set; }
        public DateTime OrderDate { get; set; }
     
     }

    [Serializable]
     class Customer
     {
        private readonly object p;

        public Customer(object p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        public Customer()
        {
            // TODO: Complete member initialization
        }
         public Int32 CustomerId { get; set; }
         public string Username { get; set; }
         public string Email { get; set; }
         public string Password { get; set; }
         public DateTime RegisterDate { get; set; }
     
     }


    public class Store : Uregistration
     {
       

         public Store()
         { }

        public Store(string email,string password)
        {
            // TODO: Complete member initialization
            Password = password;
            Email = email;
       
           
        }
 
         public Int32 StoreId { get; set; }
         public DateTime RegisterDate { get; set; }

     }

      
        
       

      


}
