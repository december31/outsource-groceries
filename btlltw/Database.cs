using System;
using System.Data.SqlClient;

namespace btlltw
{
    public class Database
    {

        private SqlConnection conn;

        public SqlConnection GetConnection()
        {
            string connecttionString = "Data Source=groceries.mssql.somee.com;" +
                                       "Initial Catalog=groceries;" +
                                       "User id=dec_31_SQLLogin_1;" +
                                       "Password=gvstelp8my;";

            SqlConnection conn = new SqlConnection(connecttionString);

            conn.Open();


            return conn;
        }

        public SqlDataReader GetReader(String query)
        {
            SqlCommand cmd = new SqlCommand(query);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.GetConnection();

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public void ExecuteNonQuery(String query)
        {
            SqlCommand cmd = new SqlCommand(query);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = this.GetConnection();
            cmd.ExecuteNonQuery();
            closeConnection();
        }

        public void closeConnection()
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }
    }
}
