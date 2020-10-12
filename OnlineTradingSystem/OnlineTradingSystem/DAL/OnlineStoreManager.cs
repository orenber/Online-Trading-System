using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OnlineTradingSystem.DAL
{
   

    class OnlineStore
    {

        private DAL dal;

        public OnlineStore() {
          

         }

        #region Import Store Data Sql

        public List<BL.Product> import_product_data(Store reg)
        {
            List<BL.Product> product = new List<BL.Product>();
            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.ImportStore " + reg.StoreId, sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (Convert.IsDBNull((reader["Image"])))
                    {

                        continue;
                    }
                    pro.Add(new Product()

                    {
                        ID = Convert.ToInt32(reader["ID"].ToString()),
                        ProductName = Convert.ToString(reader["ProductName"]),
                        Category = Convert.ToString(reader["Category"]),
                        Price = Convert.ToInt32(reader["Price"]),
                        Count = Convert.ToInt32(reader["Count"]),
                        DateUpdate = Convert.ToDateTime(reader["DateUpdate"]),
                        Instock = Convert.ToBoolean(reader["Instock"]),
                        Description = Convert.ToString(reader["Description"]),
                        img = (byte[])(reader["Image"]),
                        url = Convert.ToString(reader["url"])

                    }
                       );

                }
                //cmd.ExecuteNonQuery();
                //ds = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally
            {
                sc.Close();
            }

            return pro;

        }

        #region Import List Numbers of all Id


        public List<Int32> ImportListNumberId()
        {

            List<Int32> NumberOfId = new List<Int32>();
            try
            {
            
             .sc.Open();
                cmd = new SqlCommand("dbo.NumbersId", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NumberOfId.Add(Convert.ToInt32(reader["ID"].ToString()));

                }
                //cmd.ExecuteNonQuery();
                //ds = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }
            finally
            {
                sc.Close();

            }

            return NumberOfId;
        }
        #endregion

        public List<Store> ImportStoreName()
        {

            List<Store> store = new List<Store>();

            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.AllStoreName", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    store.Add(new Store
                    {

                        Getstorename = Convert.ToString(reader["StoreName"]),
                        StoreId = Convert.ToInt16(reader["StoreId"])
                    });



                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            finally

            {

                sc.Close();

            }
            return store;

        }

        #endregion

        #region Import Store Data By Id
        public Store ImportStoreDataById(BL.Store store)
        {

            try
            {
                
                dal.sc.Open();
                
                dal.cmd = new SqlCommand("dbo.StoreDataById " + store.bid, dal.sc);
           

                while (dal.reader.Read())
                {

                    store.name = Convert.ToString(dal.reader["StoreName"]);
                    store.bid = Convert.ToUInt32(dal.reader["StoreId"]);
                    store = Convert.ToString(dal.reader["ManegerName"]);
                 
                    store.Getmarketname = Convert.ToString(dal.reader["Market"]);

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

            finally
            {

                sc.Close();



            }

            return stor;


        }
        #endregion

        #region Export Store Data to Sql

        public void ExportSqlData(List<Product> prod, Store reg)
        {

            try
            {
                sc.Open();


                //cmd = new SqlCommand("Delete  from [" + reg.Getstorename + "]", sc);
                //cmd.ExecuteNonQuery();
                for (int i = 0; prod.Count > i; i++)
                {
                    cmd = new SqlCommand("dbo.InsertUpdate "

                    + reg.StoreId + ","
                    + prod[i].ID + ",'"
                    + prod[i].ProductName + "','"
                    + prod[i].Category + "',"
                    + prod[i].Price + ","
                    + prod[i].Instock + ","
                    + prod[i].Count + ",'"
                    + prod[i].DateUpdate + "','"
                    + prod[i].Description + "','"
                    + prod[i].url + "'", sc);

                    cmd.ExecuteNonQuery();
                    // export all the image
                    cmd = new SqlCommand("dbo.UpdateImage " + prod[i].ID + ",@img", sc);
                    cmd.Parameters.Add(new SqlParameter("@img", prod[i].img));
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }


            finally
            {
                sc.Close();


            }




        }

        #endregion

        #region Registration Data

        public bool RegistrationData(Store reg)
        {
            bool ok = true;

            try
            {
                sc.Open();


                cmd = new SqlCommand("UserData " + "'"
                + reg.Getpassword + "','"
                + reg.Getusername + "','"
                + reg.Getmarketname + "','"
                + reg.Getstorename + "'", sc);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ok = false;

            }

            finally
            {
                sc.Close();
            }


            return ok;

        }

        #endregion

        #region Log in Validation
        public Store reg = new Store();
        public Store ValidateUsernamePasswordCompatible(Store reg)
        {


            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.ValidateUsernamePassword  " +
                 "'" + reg.Getusername + "'" +
                 ",'" + reg.Getpassword + "'", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reg.Getstorename = Convert.ToString(reader["StoreName"]);
                    reg.Getmarketname = Convert.ToString(reader["Market"]);
                    reg.StoreId = Convert.ToInt16(reader["StoreId"]);
                    reg.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

            finally
            {
                sc.Close();



            }


            return reg;


        }

        #endregion

        #region Save Image TO sql Database
        public void SaveImageToSql(List<Product> pro, int index)
        {



            try
            {

                sc.Open();
                cmd = new SqlCommand("dbo.UpdateImage " + pro[index].ID + ",@img", sc);
                cmd.Parameters.Add(new SqlParameter("@img", pro[index].img));
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);



            }
            finally
            {

                sc.Close();

            }



        }
        #endregion

        #region Registration

        public void Insertnewclient(Customer customer)
        {


            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.InsertNewCustomer '"
                + customer.Username + "','"
                + customer.email + "','"
                + customer.password + "'", sc);

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }


            finally
            {
                sc.Close();


            }




        }

        #endregion

        #region Validate User name Password Compatible

        public Customer ValidateUsernamePasswordCompatible(Customer cus)
        {


            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.ValidateUsernamePasswordWeb  " +
                 "'" + cus.Username + "'" +
                 ",'" + cus.password + "'", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cus.CustomerId = Convert.ToInt32(reader["ID"]);
                    cus.Username = Convert.ToString(reader["UserName"]);
                    cus.email = Convert.ToString(reader["Email"]);
                    cus.password = Convert.ToString(reader["Password"]);
                    cus.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }

            finally
            {
                sc.Close();



            }





            return cus;





        }

        #endregion

        #region Export Customer Goods
        public void ExportCustomerGoods(List<Goods_bought> goods)
        {


            try
            {
                sc.Open();


                for (int i = 0; goods.Count > i; i++)
                {
                    cmd = new SqlCommand("dbo.ExportGoods "
                    + goods[i].ProductID + ","
                    + goods[i].StoreId + ","
                    + goods[i].CustomerId, sc);
                    cmd.ExecuteNonQuery();


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }


            finally
            {
                sc.Close();


            }



        }
        #endregion

        #region Product Sales by Store Id

        public DataTable Product_Sales_by_Store_Id(Store sto)
        {




            try
            {


                sc.Open();


                cmd = new SqlCommand("ProductSalesbyStoreId ", sc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@shopeid", sto.StoreId);
                cmd.ExecuteNonQuery();
                GetTable(cmd);





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }


            finally
            {
                sc.Close();


            }
            return GetTable(cmd);



        }
        #endregion

        #region Get Table
        public DataTable GetTable(SqlCommand cmd)
        {
            sqldap.SelectCommand = cmd;
            DataTable table = new DataTable();
            sqldap.Fill(table);
            return table;


        }
        #endregion

        #region  Customer List By Store Id

        public DataTable Customer_List_By_Store_Id(Store sto)
        {

            try
            {


                sc.Open();


                cmd = new SqlCommand("CustomerListByStoreId ", sc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@shopeid", sto.StoreId);
                cmd.ExecuteNonQuery();
                GetTable(cmd);





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);


            }


            finally
            {
                sc.Close();


            }
            return GetTable(cmd);


        }

        #endregion
    }
}
