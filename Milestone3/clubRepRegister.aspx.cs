using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Windows.Forms.DataVisualization.Charting;

namespace Milestone3
{
    public partial class clubRepRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerCR(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = repName.Text;
            String us = usernameRep.Text;
            String pass = passwordRep.Text;
            String c = clubNameRep.Text;


            HtmlGenericControl lbl = new HtmlGenericControl("div");
            lbl.InnerText = "Please enter valid data.";
            if (na == "" || us == "" || pass == "" || c == "")
            {
                crID.Controls.Add(lbl);
            }
            else
            {
                SqlCommand addRep = new SqlCommand("addRepresentative", conn);
                addRep.CommandType = CommandType.StoredProcedure;
                addRep.Parameters.Add(new SqlParameter("@name", na));
                addRep.Parameters.Add(new SqlParameter("@username", us));
                addRep.Parameters.Add(new SqlParameter("@pass", pass));
                addRep.Parameters.Add(new SqlParameter("@club_name", c));

                Session["cr"] = c;

                addRep.ExecuteNonQuery();
                Response.Redirect("loginPage.aspx");


            }

            conn.Close();
        }

        
    }
}