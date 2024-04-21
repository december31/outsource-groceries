using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace btlltw
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["listMember"] = dsMember();
        }

        protected List<Member> dsMember()
        {
            string path = "listMember.xml";
            List<Member> list = new List<Member>();
            if (File.Exists(path))
            {
                // Đọc file
                System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(List<Member>));
                StreamReader file = new StreamReader(Server.MapPath(path));

                list = (List<Member>)reader.Deserialize(file);
                list = list.OrderBy(Member => Member.Id).ToList();
                file.Close();
            }
            return list;
        }
        
        protected void Session_Start(object sender, EventArgs e)
        {
            Session["login"] = false;
            Session["id"] = "";
            Session["NickName"] = "";
            Session["Pass"] = "";

            Session["Cart"] = new List<Cart>();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}