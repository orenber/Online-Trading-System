 
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineTradingSystem.DAL
{
    public class DataBase
    {
        public  SqlConnection sc;
        public SqlCommand cmd;
        public SqlDataAdapter sqldap;
        public SqlDataReader reader;

        public DataBase()
        {
            #region  build Sql conection

            string ConnectionStrings = ConfigurationManager.ConnectionStrings["Online Trading System DBConnectionString"].ConnectionString;
            sc = new SqlConnection(ConnectionStrings);
            SqlDataAdapter sqldap = new SqlDataAdapter();

            #endregion
        }

    }


}
