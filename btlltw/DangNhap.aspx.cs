using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using G19EShop;

namespace btlltw
{
    public partial class DangNhap : System.Web.UI.Page
    {
        private Database _database = new Database();
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((bool)Session["login"] == true)
            {
                Response.Redirect("TrangChu.aspx");
            }
            // string path = "listMember.xml";

            if (Request.Form["btnLogin"] == "true")
            {
                // List<Member> list = new List<Member>();
                //
                // if (File.Exists(Server.MapPath(path)))
                // {
                //     // Đọc file
                //     System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                //     StreamReader file = new StreamReader(Server.MapPath(path));
                //
                //     list = (List<Member>)reader.Deserialize(file);
                //     list = list.OrderBy(Member => Member.Id).ToList();
                //     file.Close();
                // }

                Member mb = new Member();
                mb.NickName1 = Request.Form["txtEmail"];
                mb.Pass = Request.Form["txtPass"];

                SqlDataReader reader = _database.GetReader($"select * from [User] where NickName='{mb.NickName1}'");

                if (reader.Read())      // tai khoan ton tai <=> co 1 ban ghi trong db co email la email duoc cung cap
                {
                    string savedPassword = reader["pass"].ToString();
                    if (Encoder.Encode(mb.Pass) == savedPassword)
                    {
                        Session["login"] = true;
                        Session["id"] = reader["id"];
                        Session["NickName"] = reader["NickName"];
                        Session["Pass"] = reader["pass"];

                        if((bool) Session["login"] == true)
                        {
                            Response.Redirect("TrangChu.aspx");
                        }
                    }
                    else
                    {
                        string alert = "";
                        alert += "<script>alert('Tài khoản hoặc mật khẩu không đúng!');</script>";
                        Response.Write(alert);
                    }
                }
                else
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản hoặc mật khẩu không đúng!');</script>";
                    Response.Write(alert);
                }

                _database.closeConnection();
                // bool checktrung = false;
                // foreach (Member mem in list)
                // {
                //     if (mem.NickName1.Equals(mb.NickName1) && mem.Pass.Equals(mb.Pass))
                //     {
                //         checktrung = true;
                //         mb.Id = mem.Id;
                //         break;
                //     }
                // }
                //
                // if (checktrung == false)
                // {
                //     string alert = "";
                //     alert += "<script>alert('Tài khoản hoặc mật khẩu không đúng!');</script>";
                //     Response.Write(alert);
                // }
                // else
                // {
                //     // Tạo session
                //     Session["login"] = true;
                //     Session["id"] = mb.Id;
                //     Session["NickName"] = mb.NickName1;
                //     Session["Pass"] = mb.Pass;
                // }
                //
                // if((bool) Session["login"] == true)
                // {
                //     Response.Redirect("TrangChu.aspx");
                // }
            }
        }
    }
}
