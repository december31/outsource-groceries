using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class Trangchu : System.Web.UI.Page
    {
        private Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Product> listNew = new List<Product>();

            SqlDataReader reader = _database.GetReader("SELECT top 4 * from product");

            // Đọc database
            while (reader.Read())
            {
                listNew.Add(new Product(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader["tensp"].ToString(),
                    reader["url_img"].ToString(),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("gia"))),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("giamgia")))
                ));
            }

            reader.Close();

            string html = "";

            foreach (Product product in listNew)
            {
                html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3 product\">";
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

            listNewProduct.InnerHtml = html;

            reader = _database.GetReader("SELECT top 8 * from product where giamgia <> 0");
            List<Product> listBest = new List<Product>();

            // Đọc database
            while (reader.Read())
            {
                listBest.Add(new Product(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader["tensp"].ToString(),
                    reader["url_img"].ToString(),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("gia"))),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("giamgia")))
                ));
            }

            reader.Close();

            html = "";
            foreach (Product product in listBest)
            {
                // if (count < 8)
                // {
                //     count++;
                // }
                // else
                // {
                //     break;
                // }
                //
                // if (product.Giamgia == 0)
                // {
                //     count--;
                //     continue;
                // }
                // else
                // {
                html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3 product\">";
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
                // }

                listBestProduct.InnerHtml = html;
            }

            if (Request.Form["btnAddCart"] != null)
            {
                List<Cart> carts = (List<Cart>)Session["Cart"];

                //IPHostEntry Ip = new IPHostEntry();
                //string HostName = Dns.GetHostName();
                //Ip = Dns.GetHostByName(HostName);

                if ((bool)Session["login"] == true)
                {
                    Cart cart = new Cart((string)Convert.ToString(Session["id"]),
                        Convert.ToInt32(Request.Form["btnAddCart"]));
                    carts.Add(cart);
                }
                //else
                //{
                //    Cart cart = new Cart(Ip.ToString(), Convert.ToInt32(Request.Form["btnAddCart"]));
                //    carts.Add(cart);
                //}

                Session["Cart"] = carts;
            }

            _database.closeConnection();
        }
    }
}
