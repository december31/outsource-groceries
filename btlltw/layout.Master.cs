using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace btlltw
{
    public partial class layout : System.Web.UI.MasterPage
    {
        private Database _database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            html += "<a data-toggle = \"dropdown\" class=\"dropdown-toggle\">" +
                        "<i class=\"fa fa-user\" ></i> Tài Khoản<b class=\"caret\"></b>" +
                    "</a>";

            if ((bool) Session["login"] == true && (string) Session["NickName"] == "admin@gmail.com")
            {
                html += "<ul class=\"dropdown-menu\">";
                html += "<li><b>ID : " + Session["id"] + "</b></li>";
                html += "<li><b>Email : " + Session["NickName"] + "</b></li>";
                html += "<li><a href = \"QuanLyMatHang.aspx\" ><i class=\"fa fa-archive\" aria-hidden=\"true\"></i> Quản Lý Mặt Hàng</a></li>";
                html += "<li><a href = \"QUanLyTaiKhoan.aspx\" ><i class=\"fa fa-users\" aria-hidden=\"true\"></i> Quản Lý Tài Khoản</a></li>";
                html += "<li>" +
                            "<form><button type=\"submit\" class=\"btn btn-danger\" value=\"true\" name=\"btnLogout\" id=\"btnLogout\" runat=\"server\">" +
                                "<i class=\"fa fa-power-off\" aria-hidden=\"true\"></i> Thoát" +
                            "</button></form>" +
                        "</li>";
                html += "</ul>";
                account.InnerHtml = html;
            }
            else if ((bool) Session["login"] == true)
            {
                html += "<ul class=\"dropdown-menu\">";
                html += "<li<b>ID : " + Session["id"] + "</b></li>";
                html += "<li><b>Email : " + Session["NickName"] + "</b></li>";
                html += "<li>" +
                            "<form><button type=\"submit\" class=\"btn btn-danger\" value=\"true\" name=\"btnLogout\" id=\"btnLogout\" runat=\"server\">" +
                                "<i class=\"fa fa-power-off\" aria-hidden=\"true\"></i> Thoát" +
                            "</button></form>" +
                        "</li>";
                html += "</ul>";

                account.InnerHtml = html;
            }
            else
            {
                html += "<ul class=\"dropdown-menu\">";
                html += "<li><a href = \"DangNhap.aspx\" ><i class=\"fa fa-sign-in\" aria-hidden=\"true\"></i> Đăng Nhập</a></li>";
                html += "<li><a href = \"DangKy.aspx\" ><i class=\"fa fa-user-plus\" aria-hidden=\"true\"></i> Đăng Ký</a></li>";
                html += "</ul>";

                account.InnerHtml = html;
            }

            if (Request.QueryString["btnLogout"] == "true")
            {
                Session.Abandon();

                Response.Redirect("DangNhap.aspx");
            }

            html = "";
            SqlDataReader reader = _database.GetReader("select * from category");
            while (reader.Read())
            {
                html += $"<li><a href=\"DanhMucSanPham.aspx?id={reader["id"]}\">{reader["name"]}</a></li>";
            }

            category.InnerHtml = html;
            _database.closeConnection();
        }
    }
}
