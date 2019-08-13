using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public class WebDAL
    {
        #region  build Sql conection

        SqlConnection sc = new SqlConnection("Data Source=HASEE-0E7936831;Initial Catalog=Online Trading System DB;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;

        DataSet ds;
        SqlDataAdapter adap;

        #endregion

        #region Import All Store Names

        public List<string> ImportStoreName()
        {

            List<string> StoreName = new List<string>();



            try
            {
                sc.Open();

                cmd = new SqlCommand("dbo.AllStoreName", sc);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    StoreName.Add(Convert.ToString(reader["StoreName"]));

                }


                sc.Close();

            }
            catch (Exception ex)
            {
                sc.Close();


            }
            return StoreName;





        }
        
        #endregion


       


    }
}