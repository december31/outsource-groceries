using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class DanhMucSanPham : System.Web.UI.Page
    {
        private Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            // string path = "listProduct.xml";
            //
            //
            // if (File.Exists(Server.MapPath(path)))
            // {
            //     // Đọc file
            //     System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Product>));
            //     StreamReader file = new StreamReader(Server.MapPath(path));
            //
            //     list = (List<Product>)reader.Deserialize(file);
            //     list = list.OrderByDescending(Product => Product.Id).ToList();
            //     file.Close();
            // }

            int categoryId = Convert.ToInt32(Request.QueryString["id"]);

            List<Product> list = new List<Product>();

            SqlDataReader reader = _database.GetReader($"SELECT * FROM Product INNER JOIN category ON category.id = Product.category_id WHERE category.id = {categoryId}");
            while (reader.Read())
            {
                list.Add(new Product(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader["tensp"].ToString(),
                    reader["url_img"].ToString(),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("gia"))),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("giamgia")))
                ));
            }

            string html = "";
            html += "<div class=\"row rcontent\">";

            foreach (Product product in list)
            {
                html += "<div class=\"col-xs-15 col-sm-3 col-md-4 col-lg-4 product\">";
                html += "<a href=ChiTietMatHang.aspx?id=" + product.Id + ">";
                html += "<div class=\"anhproduct\">" +
                        "<img src=\"" + product.Url_img + "\" width=\"100%\" alt=\"\">" +
                        "</div>";
                if (product.Giamgia > 0)
                {
                    html += "<div class=\"infoproduct\">";
                    html += "<center><p>" + product.Giamgia + " %</p></center>";
                    html += "</div>";
                    html += "<div class=\"infonew\">";
                    html += "<center><p>sale</p></center>";
                    html += "</div>";
                }

                html += "<div class=\"addclass\">";
                html += "<center>";
                html += "<div class=\"iconadd\">";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddWish\">" +
                        "<i class=\"fa fa-heart - o\" aria-hidden=\"true\"></i>" +
                        "</button>";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + product.Id + "\" name=\"btnAddCart\">" +
                        "<i class=\"fa fa-shopping-cart\" aria-hidden=\"true\"></i>" +
                        "</button>";
                html += "</div>";
                html += "</center>";
                html += "<center>";
                html += "<h4>" + product.Tensp + "</h4>";
                if (product.Giamgia > 0)
                {
                    html += "<h5 class=\"colorprice\"><b>" + product.Gia * (100 - product.Giamgia) / 100 +
                            " vnd</b> &nbsp<del><i>" + product.Gia + " vnd</i></del></h5>";
                }
                else
                {
                    html += "<h5 class=\"colorprice\"><b>" + product.Gia + " vnd</b></h5>";
                }

                html += "</center>";
                html += "</div>";
                html += "</a>";
                html += "</div>";
            }

            html += "</div>";

            listProduct.InnerHtml = html;
            _database.closeConnection();
        }
    }
}
