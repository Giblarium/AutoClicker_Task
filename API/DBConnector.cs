using Microsoft.Data.SqlClient;

namespace API
{
    public class DBConnector
    {
        public SqlConnection connect = null;

        //подключение к базе
        string connectDB = "Data Source=desktop-h1m2m0p;Initial Catalog=1C_connect;Persist Security Info=True;User ID=Connect1C;Password=2102;TrustServerCertificate=true";
        public void OpenConnection()
        {
            connect.Open(); 
        }
        public void CloseConnection()
        {
            connect.Close();
        }
        public DBConnector()
        {
            connect = new SqlConnection(connectDB);
        }
    }
}
