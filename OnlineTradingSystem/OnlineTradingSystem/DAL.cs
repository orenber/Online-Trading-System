using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;



namespace OnlineTradingSystem
{
    class DA
    {
        private readonly SqlConnection sc;
        private SqlCommand cmd;
        private readonly SqlDataAdapter sqldap;
        private SqlDataReader reader;
        private List<BL.Supplier> suppliers;

        public DA()
        {
            #region  build Sql conection
            string ConnectionStrings = ConfigurationManager.ConnectionStrings["Online Trading System DBConnectionString"].ConnectionString;
            sc = new SqlConnection(ConnectionStrings);
            sqldap = new SqlDataAdapter();

            #endregion
        }



        public List<BL.Supplier> ImportSupplierData()
        {
            suppliers = new List<BL.Supplier>();
            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.spImportSupplier", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    suppliers.Add(new BL.Supplier
                    {
                        ID = Convert.ToUInt32(reader["sid"].ToString()),
                        Name = Convert.ToString(reader["sname"]),
                        Address = Convert.ToString(reader["address"]),
                        Phone = Convert.ToUInt32(reader["phone"])

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

            return suppliers;

        }


        #region Import Store Data Sql

        public List<Product> ImportSqlData(Store reg)
        {
            List<Product> pro = new List<Product>();
            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.spImportStoreProducts " + reg.StoreId, sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
             
                    pro.Add(new Product()

                    {
                        ID = Convert.ToInt32(reader["code"].ToString()),
                        ProductName = Convert.ToString(reader["pname"]),
                        Category = Convert.ToString(reader["utype"]),
                        Price = Convert.ToInt32(reader["uprice"]),
                        DateUpdate = Convert.ToDateTime(reader["updateDate"]),
                        Description = Convert.ToString(reader["descr"]), 
                        Manufactore = Convert.ToString(reader["manu"]),
                        Url = Convert.ToString(reader["urlink"])
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
                sc.Open();

                cmd = new SqlCommand("dbo.spNumbersId", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    NumberOfId.Add(Convert.ToInt32(reader["code"].ToString()));

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

            List<Store> stores = new List<Store>();

            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.spAllStoreName", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    stores.Add(new Store{
                    
                        Storename=Convert.ToString(reader["bname"]),
                        StoreId=Convert.ToInt16(reader["bid"])
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
            return stores;

        }

        #endregion

        #region Import Store Data By Id
        public Store ImportStoreDataById(Store stor)
        {
            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.spStoreDataById " + stor.StoreId, sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    stor.Storename = Convert.ToString(reader["StoreName"]);
                    stor.StoreId = Convert.ToInt16(reader["StoreId"]);
                    stor.Username = Convert.ToString(reader["ManegerName"]);
                    stor.RegisterDate = Convert.ToDateTime(reader["RegisterDate"]);
                    stor.Marketname = Convert.ToString(reader["Market"]);
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

        public void ExportSqlData(List<Product> prod,Store reg)
        {

            try
            {
                sc.Open();


                //cmd = new SqlCommand("Delete  from [" + reg.Getstorename + "]", sc);
                //cmd.ExecuteNonQuery();
                for (int i = 0; prod.Count > i; i++)
                {
                    cmd = new SqlCommand("dbo.spProductInsertOrUpdate "
                        + reg.StoreId + ","
                        + prod[i].ID + ",'"
                        + prod[i].ProductName + "','"
                        + prod[i].Category + "',"
                        + prod[i].Price + ",'"
                        + prod[i].Description + "','"
                        + prod[i].Manufactore + "','"
                        + prod[i].Url+"'" , sc);

                    cmd.ExecuteNonQuery();
                    if (prod[i].Img==null || prod[i].Img.Length == 0)
                    {
                        continue;
                    }
                    else
                    {
                        ExportImage(prod[i]);
                    }

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


        public void ExportImage(Product prod)
        {
            try
            {
                // export all the image
                cmd = new SqlCommand("dbo.UpdateImage " + prod.ID + ",@img", sc);
                cmd.Parameters.Add(new SqlParameter("@img", prod.Img));
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


        #region Registration Data

        public bool RegistrationData(Store reg)
        {
            bool ok = true;

            try
            {
                sc.Open();

                cmd = new SqlCommand("spRegistrationManager " + "'"
                + reg.Username + "','"
                + reg.Email + "','"
                + reg.Password + "','"
                + reg.Storename + "','"
                + reg.Marketname + "'", sc);
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
   
        public Store ValidateEmailPasswordCompatible(Store reg)
        {
            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.spValidateEmailPassword  " +
                 "'"  + reg.Email + "'" +
                 ",'" + reg.Password + "'", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    reg.StoreId = Convert.ToInt16(reader["bid"]);
                    reg.Storename = Convert.ToString(reader["bname"]);
                    reg.Marketname = Convert.ToString(reader["Market"]);
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
                cmd.Parameters.Add(new SqlParameter("@img", pro[index].Img));
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
                + customer.Email + "','"
                + customer.Password + "'", sc);
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
                 ",'" + cus.Password + "'", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cus.CustomerId = Convert.ToInt32(reader["ID"]);
                    cus.Username = Convert.ToString(reader["UserName"]);
                    cus.Email = Convert.ToString(reader["Email"]);
                    cus.Password = Convert.ToString(reader["Password"]);
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
                cmd = new SqlCommand("dbo.spProductSalesbyStoreId ", sc) { };
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

                cmd = new SqlCommand("CustomerListByStoreId ", sc)
                {
                    CommandType = CommandType.StoredProcedure
                };
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
