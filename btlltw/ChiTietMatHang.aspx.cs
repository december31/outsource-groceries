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
    public partial class ChiTietMatHang : System.Web.UI.Page
    {
        private readonly Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

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

            SqlDataReader reader = _database.GetReader($"select * from Product where [Product].[id]={id}");
            reader.Read();
            Product product = new Product(
                reader.GetInt32(reader.GetOrdinal("id")),
                reader["tensp"].ToString(),
                reader["url_img"].ToString(),
                Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("gia"))),
                Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("giamgia")))
            );
            reader.Close();

            List<Product> list = new List<Product>();
            reader = _database.GetReader($"SELECT top 4 * from product where [Product].[id] <> {id}");
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
            // foreach( Product prod in list)
            // {
            //     if (prod.Id == id)
            //     {
            //         product = prod;
            //         break;
            //     }
            // }

            imgProduct.InnerHtml = "<img src=\"" + product.Url_img + "\"  width=\"100%\" height=\"auto\" alt=\"\">";
            titleProduct.InnerText = product.Tensp;
            if (product.Giamgia > 0)
            {
                priceProduct.InnerHtml = "<h2 style=\"color: red\">" + product.Gia * (100 - product.Giamgia) / 100 +
                                         " vnd" +
                                         "<h3><del>" + product.Gia + " vnd</del> (Tiết Kiệm " + product.Giamgia +
                                         "%)</h3>" +
                                         "</h2>";
            }
            else
            {
                priceProduct.InnerHtml = "<h2 style=\"color: red\">" + product.Gia + " vnd</h2>";
            }

            string html = "";
            int count = 0;
            foreach (Product prd in list)
            {
                if (count < 4)
                {
                    count++;
                }
                else
                {
                    break;
                }

                html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3 product\">";
                html += "<a href=ChiTietMatHang.aspx?id=" + prd.Id + ">";
                html += "<div class=\"anhproduct\">" +
                        "<img src=\"" + prd.Url_img + "\" width=\"100%\" alt=\"\">" +
                        "</div>";
                if (prd.Giamgia > 0)
                {
                    html += "<div class=\"infoproduct\">";
                    html += "<center><p>" + prd.Giamgia + " %</p></center>";
                    html += "</div>";
                    html += "<div class=\"infonew\">";
                    html += "<center><p>sale</p></center>";
                    html += "</div>";
                }

                html += "<div class=\"addclass\">";
                html += "<center>";
                html += "<div class=\"iconadd\">";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + prd.Id + "\" name=\"btnAddWish\">" +
                        "<i class=\"fa fa-heart - o\" aria-hidden=\"true\"></i>" +
                        "</button>";
                html += "<button type=\"submit\" class=\"btn\" value=\"" + prd.Id + "\" name=\"btnAddCart\">" +
                        "<i class=\"fa fa-shopping-cart\" aria-hidden=\"true\"></i>" +
                        "</button>";
                html += "</div>";
                html += "</center>";
                html += "<center>";
                html += "<h4>" + prd.Tensp + "</h4>";
                if (prd.Giamgia > 0)
                {
                    html += "<h5 class=\"colorprice\"><b>" + prd.Gia * (100 - prd.Giamgia) / 100 +
                            " vnd</b> &nbsp<del><i>" + prd.Gia + " vnd</i></del></h5>";
                }
                else
                {
                    html += "<h5 class=\"colorprice\"><b>" + prd.Gia + " vnd</b></h5>";
                }

                html += "</center>";
                html += "</div>";
                html += "</a>";
                html += "</div>";
            }

            listProductTT.InnerHtml = html;
            _database.closeConnection();
        }

        protected void AddToCartButton(object sender, EventArgs e)
        {
            if (!(bool)Session["login"])
            {
                Response.Redirect("DangNhap.aspx");
            }
            else
            {
                string email = Session["NickName"].ToString();
                SqlDataReader reader = _database.GetReader($"select * from [User] where NickName='{email}'");
                if (reader.Read())
                {
                    string userId = reader["id"].ToString();
                    reader.Close();

                    string productId = Request.QueryString.Get("id");
                    _database.ExecuteNonQuery($"INSERT INTO [dbo].[product_user_cart]([Product_id],[User_id]) VALUES ({productId},{userId})");
                }
                _database.closeConnection();
                string alert = "";
                alert += "<script>alert('Thêm sản phẩm vào giỏ hàng thành công');</script>";
                Response.Write(alert);
            }
        }
    }
}
