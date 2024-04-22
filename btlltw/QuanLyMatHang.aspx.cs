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
    public partial class QuanLy : System.Web.UI.Page
    {
        private Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            // if ((string)Session["NickName"] != "admin@gmail.com" || (bool)Session["login"] == false)
            // {
            //     Response.Redirect("TrangChu.aspx");
            // }
            // string path = "listProduct.xml";
            //
            // List<Product> list = new List<Product>();
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

            if (Request.Form["btnXoa"] != null)
            {
                string productId = Request.Form["btnXoa"];
                _database.ExecuteNonQuery(
                    $"DELETE FROM product_user_cart WHERE User_id = 1 AND Product_id = {productId}");
                _database.ExecuteNonQuery($"DELETE FROM [size] WHERE Product_id = {productId}");
                _database.ExecuteNonQuery($"DELETE FROM Product WHERE id = {productId}");
                _database.closeConnection();
            }

            string html = "";
            SqlDataReader reader = _database.GetReader("select * from product");
            while (reader.Read())
            {
                Product product = new Product(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader["tensp"].ToString(),
                    reader["url_img"].ToString(),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("gia"))),
                    Decimal.ToDouble(reader.GetDecimal(reader.GetOrdinal("giamgia")))
                );
                html += "<div class=\"row\">" +
                        "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3\">";
                html += "<label class=\"checkbox-inline\"><img src=\"" + product.Url_img +
                        "\" width=\"50%\" height=\"\" alt=\"\"></label>";
                html += "</div>";
                html += "<div class=\"col-xs-12 col-sm-6 col-md-4 col-lg-4\">";
                html += "<h4>Tên sp: " + product.Tensp + "</h4>" +
                        "<br/>" +
                        "<h4>ID: " + product.Id + "</h4>";
                html += "</div>";
                html += "<div class=\"col-xs-12 col-sm-6 col-md-2 col-lg-2\">";
                if (product.Giamgia > 0)
                {
                    html += "<h4 style = \"color: orange\" >Giá gốc: <del>" + product.Gia + "</del></h4>";
                    html += "<h4 style = \"color: orange\" >Giá giảm: " + product.Gia * (100 - product.Giamgia) / 100 +
                            "</h4>";
                    html += "<h4 style = \"color: orange\" >Giảm giá: " + product.Giamgia + " %</h4>";
                }
                else
                {
                    html += "<h4 style = \"color: orange\" >Giá gốc: " + product.Gia + "</h4>";
                }

                html += "</div>";
                html += "<div class=\"col-xs-12 col-sm-6 col-md-3 col-lg-3\">";
                html += "<button class=\"btn btn-basic\" value=\"" + product.Id +
                        "\" type=\"submit\" name=\"btnXoa\"><i class=\"fa fa-trash\" aria-hidden=\"true\"></i> Xóa</button>";
                html += "</div>";
                html += "</div>";
                html += "<hr/>";
            }

            listProduct.InnerHtml = html;
        }

        public void btnUpload_Click(object o, EventArgs e)
        {
            if (Page.IsValid && inputAnh1.HasFile)
            {
                if (CheckFileType(inputAnh1.FileName))
                {
                    string fileName = "images/" + inputAnh1.FileName;
                    string filePath = MapPath(fileName);
                    inputAnh1.SaveAs(filePath);
                    Image1.ImageUrl = fileName;
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Chỉ nhận file ảnh!!!');</script>";
                    Response.Write(alert);
                }
            }
        }

        public void btnThem_Click(object o, EventArgs e)
        {
            // string path = "listProduct.xml";
            //
            // List<Product> list = new List<Product>();
            //
            // if (File.Exists(Server.MapPath(path)))
            // {
            //     // Đọc file
            //     System.Xml.Serialization.XmlSerializer reader =
            //         new System.Xml.Serialization.XmlSerializer(typeof(List<Product>));
            //     StreamReader file = new StreamReader(Server.MapPath(path));
            //
            //     list = (List<Product>)reader.Deserialize(file);
            //     list = list.OrderByDescending(Product => Product.Id).ToList();
            //     file.Close();
            // }

            Product prod = new Product();

            try
            {
                prod.Id = getNextProductId();
                prod.Tensp = Request.Form["txtTen"];
                prod.Gia = float.Parse(Request.Form["txtGia"]);
                prod.Giamgia = float.Parse(Request.Form["txtGiamgia"]);
                prod.Url_img = Image1.ImageUrl;
            }
            catch (Exception)
            {
                string alert = "";
                alert += "<script>alert('Hãy nhập các giá trị hợp lệ vào các trường!');</script>";
                Response.Write(alert);
                return;
            }

            SqlDataReader reader = _database.GetReader($"SELECT * FROM Product WHERE tensp = N'{prod.Tensp}'");
            if (reader.Read())
            {
                string alert = "";
                alert += "<script>alert('Mặt hàng đã tồn tại!');</script>";
                Response.Write(alert);
                reader.Close();
            }
            else
            {
                _database.ExecuteNonQuery(
                    $"INSERT INTO [dbo].[Product]([id],[tensp],[url_img],[gia],[giamgia], [category_id]) VALUES ({prod.Id}, N'{prod.Tensp}', N'{prod.Url_img}', {prod.Gia}, {prod.Giamgia}, 1)");
                reader.Close();
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }

            _database.closeConnection();
            // bool checktrung = false;
            // foreach (Product product in list)
            // {
            //     if (product.Tensp == prod.Tensp)
            //     {
            //         checktrung = true;
            //         product.Id = prod.Id;
            //         break;
            //     }
            // }
            //
            // if (!checktrung)
            // {
            //     foreach (Product product in list)
            //     {
            //         if (product.Id == prod.Id)
            //         {
            //             prod.Id++;
            //         }
            //     }
            //
            //     list.Add(prod);
            //     //Ghi file
            //     System.Xml.Serialization.XmlSerializer writer =
            //         new System.Xml.Serialization.XmlSerializer(typeof(List<Product>));
            //
            //     System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));
            //
            //     writer.Serialize(_file, list);
            //     _file.Close();
            //     _database.closeConnection();
            //
            //     Page.Response.Redirect(Page.Request.Url.ToString(), true);
            // }
            // else
            // {
            //     string alert = "";
            //     alert += "<script>alert('Mặt hàng đã tồn tại!');</script>";
            //     Response.Write(alert);
            // }
        }

        private int getNextProductId()
        {
            SqlDataReader reader = _database.GetReader("select max(id) as max_id from [Product]");
            int result = 1;
            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("max_id")))
            {
                result = reader.GetInt32(reader.GetOrdinal("max_id")) + 1;
            }

            reader.Close();
            return result;
        }

        bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
    }
}
