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

namespace Milestone3
{
    public partial class SystemAdminActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");
        }

        protected void addClub(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = nameClub.Text;
            String loc = locClub.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (na == "" || loc == "")
            {
                g1.Controls.Add(lbl1);
            }
            else
            {
                SqlCommand addC = new SqlCommand("addClub", conn);
                addC.CommandType = CommandType.StoredProcedure;
                addC.Parameters.Add(new SqlParameter("@name", na));
                addC.Parameters.Add(new SqlParameter("@location", loc));
                addC.ExecuteNonQuery();

                loginPage.EmptyTextBoxes(g1);

            }

            conn.Close();
        }

        protected void deleteClub(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = nameClubDelete.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (na == "")
            {
                g2.Controls.Add(lbl1);
            }
            else
            {

                SqlCommand delC = new SqlCommand("deleteClub", conn);
                delC.CommandType = CommandType.StoredProcedure;
                delC.Parameters.Add(new SqlParameter("@name", na));


                loginPage.EmptyTextBoxes(g2);

                delC.ExecuteNonQuery();
            }
            conn.Close();
        }


        protected void addStadium(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = stadiumNameAdd.Text;
            String loc = stadiumLocAdd.Text;
            String cap = stadiumCapAdd.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (na == "" || loc == "" || cap == "")
            {
                g3.Controls.Add(lbl1);
            }
            else
            {

                SqlCommand addS = new SqlCommand("addStadium", conn);
                addS.CommandType = CommandType.StoredProcedure;
                addS.Parameters.Add(new SqlParameter("@name", na));
                addS.Parameters.Add(new SqlParameter("@location", loc));
                addS.Parameters.Add(new SqlParameter("@capacity", cap));

                loginPage.EmptyTextBoxes(g3);

                addS.ExecuteNonQuery();
            }
            conn.Close();
        }

        protected void deleteStadium(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = stadiumNameDelete.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (na == "")
            {
                g4.Controls.Add(lbl1);
            }
            else
            {

                SqlCommand delS = new SqlCommand("deleteStadium", conn);
                delS.CommandType = CommandType.StoredProcedure;
                delS.Parameters.Add(new SqlParameter("@name", na));


                loginPage.EmptyTextBoxes(g4);
                delS.ExecuteNonQuery();
            }
            conn.Close();
        }

        protected void blockFan(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String nat = blockFanNat.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (nat == "")
            {
                g5.Controls.Add(lbl1);
            }
            else
            {


                SqlCommand bf = new SqlCommand("blockFan", conn);
                bf.CommandType = CommandType.StoredProcedure;
                bf.Parameters.Add(new SqlParameter("@nat_id", nat));

                loginPage.EmptyTextBoxes(g5);

                bf.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}