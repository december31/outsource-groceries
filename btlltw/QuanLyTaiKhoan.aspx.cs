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
    public partial class QuanLyTaiKhoan : System.Web.UI.Page
    {
        private Database _database = new Database();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["NickName"] != "admin@gmail.com" || (bool)Session["login"] == false)
            {
                Response.Redirect("TrangChu.aspx");
            }


            Table_Load();

            // string path = "listMember.xml";
            // List<Member> list = new List<Member>();
            //
            // if (File.Exists(Server.MapPath(path)))
            // {
            //     // Đọc file
            //     System.Xml.Serialization.XmlSerializer reader =
            //         new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
            //     StreamReader file = new StreamReader(Server.MapPath(path));
            //
            //     list = (List<Member>)reader.Deserialize(file);
            //     list = list.OrderBy(Member => Member.Id).ToList();
            //     file.Close();
            // }

            if (Request.Form["btnThem"] == "true")
            {
                Member mb = new Member();
                mb.NickName1 = Request.Form["txtEmail"];
                mb.Pass = Request.Form["txtPass"];

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

                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }

                _database.closeConnection();
                //
                // Member member = new Member();
                //
                // member.Id = list.Count;
                // member.NickName1 = Request.Form["txtEmail"];
                // member.Pass = Request.Form["txtPass"];
                //
                // bool checktrung = false;
                // foreach (Member mem in list)
                // {
                //     if (mem.NickName1.Equals(member.NickName1))
                //     {
                //         checktrung = true;
                //         member.Id = mem.Id;
                //         break;
                //     }
                // }
                //
                // if (!checktrung)
                // {
                //     foreach (Member mem in list)
                //     {
                //         if (mem.Id == member.Id)
                //         {
                //             member.Id++;
                //         }
                //     }
                //
                //     list.Add(member);
                //     //Ghi file
                //     System.Xml.Serialization.XmlSerializer writer =
                //         new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                //
                //     System.IO.FileStream _file = System.IO.File.Create(Server.MapPath(path));
                //
                //     writer.Serialize(_file, list);
                //     _file.Close();
                //
                //     Page.Response.Redirect(Page.Request.Url.ToString(), true);
                // }
                // else
                // {
                //     string alert = "";
                //     alert += "<script>alert('Tài khoản đã tồn tại!');</script>";
                //     Response.Write(alert);
                // }
            }

            if (Request.Form["btnXoa"] != null)
            {
                string userId = Request.Form["btnXoa"];
                _database.ExecuteNonQuery($"DELETE FROM [product_user_cart] WHERE User_id = {userId}");
                _database.ExecuteNonQuery($"DELETE FROM [User] WHERE id = {userId}");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }

        private void Table_Load()
        {
            // string path = "listMember.xml";
            //
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

            SqlDataReader reader = _database.GetReader("select * from [User]");
            while (reader.Read())
            {
                Member mb = new Member(
                    reader.GetInt32(reader.GetOrdinal("id")),
                    reader["NickName"].ToString(),
                    reader["pass"].ToString(),
                    reader.GetBoolean(reader.GetOrdinal("gen"))
                );
                TableRow row = new TableRow();

                TableCell cId = new TableCell();
                cId.Text = Convert.ToString(mb.Id);
                row.Cells.Add(cId);

                TableCell cNickname = new TableCell();
                cNickname.Text = Convert.ToString(mb.NickName1);
                row.Cells.Add(cNickname);

                TableCell cPass = new TableCell();
                cPass.Text = Convert.ToString(mb.Pass);
                row.Cells.Add(cPass);

                string html = "<button type=\"submit\" value=\"" + mb.Id +
                              "\" class=\"btn btn-basic\" name=\"btnXoa\">" +
                              "<i class=\"fa fa-trash\" aria-hidden=\"true\"></i> Xóa</button>";
                TableCell cButton = new TableCell();
                cButton.Text = html;
                row.Cells.Add(cButton);

                table.Rows.Add(row);
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
