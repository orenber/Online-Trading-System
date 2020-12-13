 
using System.Data.SqlClient;
using System.Configuration;
using OnlineTradingSystem.BL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

 
namespace OnlineTradingSystem.DAL
{
    public class DataBase
    {
        public  SqlConnection sc;
        public SqlCommand cmd;
        public SqlDataAdapter sqldap;
        public SqlDataReader reader;
        public List<BL.Supplier> suppliers;


        public DataBase()
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
                        ID = Convert.ToUInt16(reader["sid"].ToString()),
                        Name = Convert.ToString(reader["sname"]),
                        Address = Convert.ToString(reader["address"]),
                        Phone = Convert.ToUInt16(reader["phone"])

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
 
    }


}
