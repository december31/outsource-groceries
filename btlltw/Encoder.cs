using System;
using System.Text;

namespace G19EShop
{
    public static class Encoder
    {
        public static string Encode(string text)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }
    }

    public static class Constants
    {
        public static readonly string ConnectionString = "Data Source=btlwebb.mssql.somee.com;" +
                                                         "Initial Catalog=btlwebb;" +
                                                         "User id=dec_31_SQLLogin_1;" +
                                                         "Password=gvstelp8my;";
    }
}
