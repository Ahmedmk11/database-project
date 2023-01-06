using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;

namespace Milestone3
{
    public partial class stadiumManagerReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerSM(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = manName.Text;
            String us = usernameMan.Text;
            String pass = passwordMan.Text;
            String s = stadiumNameMan.Text;

            HtmlGenericControl lbl = new HtmlGenericControl("div");
            lbl.InnerText = "Please enter valid data.";
            if (na == "" || us == "" || pass == "" || s == "")
            {
                smID.Controls.Add(lbl);
            }
            else
            {
                SqlCommand addMan = new SqlCommand("addStadiumManager", conn);
                addMan.CommandType = CommandType.StoredProcedure;
                addMan.Parameters.Add(new SqlParameter("@name", na));
                addMan.Parameters.Add(new SqlParameter("@stadium_name", s));
                addMan.Parameters.Add(new SqlParameter("@username", us));
                addMan.Parameters.Add(new SqlParameter("@password", pass));


                Session["sm"] = s;
                Session["sm_us"] = us;

                addMan.ExecuteNonQuery();
                Response.Redirect("loginPage.aspx");
            }

            conn.Close();
        }

    }
}