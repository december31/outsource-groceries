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
    public partial class DangKy : System.Web.UI.Page
    {
        private Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["login"])
            {
                Response.Redirect("TrangChu.aspx");
            }

            string path = "listMember.xml";

            if (Request.Form["btnSignUp"] == "true")
            {
                // if (File.Exists(Server.MapPath(path)))
                // {
                //     // Đọc file
                //     System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                //     StreamReader file = new StreamReader(Server.MapPath(path));
                //
                //     members = (List<Member>)reader.Deserialize(file);
                //     members = members.OrderBy(Member => Member.Id).ToList();
                //     file.Close();
                // }


                Member mb = new Member();
                mb.NickName1 = Request.Form["txtEmail"];
                mb.Pass = Request.Form["txtPass"];
                mb.Gen = Request.Form["radioGen"].Equals("male");

                SqlDataReader reader = _database.GetReader($"select * from [User] where NickName = '{mb.NickName1}'");

                if (reader.Read()) // ton tai mot ban ghi trong database voi ninkname(email) duoc cung cap
                {
                    string alert = "";
                    alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                    Response.Write(alert);
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    mb.Id = GetNextUserId();

                    _database.ExecuteNonQuery(
                        $"INSERT INTO [dbo].[User]([id],[NickName],[pass],[gen]) VALUES ({mb.Id}, '{mb.NickName1}', '{Encoder.Encode(mb.Pass)}', {(mb.Gen ? 1 : 0)})");

                    Session["login"] = true;
                    Session["id"] = mb.Id;
                    Session["NickName"] = mb.NickName1;
                    Session["Pass"] = mb.Pass;

                    if ((bool)Session["login"] == true)
                    {
                        Response.Redirect("TrangChu.aspx");
                    }
                }

                _database.closeConnection();

                // bool checktrung = false;
                // foreach (Member mem in members)
                // {
                //     if (mem.NickName1.Equals(mb.NickName1))
                //     {
                //         checktrung = true;
                //         break;
                //     }
                // }
                //
                // if (!checktrung)
                // {
                //     foreach (Member mem in members)
                //     {
                //         if (mem.Id == mb.Id)
                //         {
                //             mb.Id++;
                //         }
                //     }
                //
                //     members.Add(mb);
                //     //Ghi file
                //     System.Xml.Serialization.XmlSerializer writer =
                //         new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                //
                //     System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));
                //
                //     writer.Serialize(_file, members);
                //     _file.Close();
                //
                //     // Tạo session
                //     Session["login"] = true;
                //     Session["id"] = mb.Id;
                //     Session["NickName"] = mb.NickName1;
                //     Session["Pass"] = mb.Pass;
                //
                //     if ((bool)Session["login"] == true)
                //     {
                //         Response.Redirect("TrangChu.aspx");
                //     }
                // }
                // else
                // {
                //     string alert = "";
                //     alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                //     Response.Write(alert);
                // }
            }
        }

        private int GetNextUserId()
        {
            SqlDataReader reader = _database.GetReader("select max(id) as max_id from [User]");
            int result = 1;
            if (reader.Read() && !reader.IsDBNull(reader.GetOrdinal("max_id")))
            {
                result = reader.GetInt32(reader.GetOrdinal("max_id")) + 1;
            }

            reader.Close();
            return result;
        }
    }
}
