using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class SystemAdminActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Response.Redirect("start.aspx");
        }

        protected void addClub(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = nameClub.Text;
            String loc = locClub.Text;


            SqlCommand addC = new SqlCommand("addClub", conn);
            addC.CommandType = CommandType.StoredProcedure;
            addC.Parameters.Add(new SqlParameter("@name", na));
            addC.Parameters.Add(new SqlParameter("@location", loc));



            addC.ExecuteNonQuery();
            conn.Close();
        }

        protected void deleteClub(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = nameClubDelete.Text;

            SqlCommand delC = new SqlCommand("deleteClub", conn);
            delC.CommandType = CommandType.StoredProcedure;
            delC.Parameters.Add(new SqlParameter("@name", na));



            delC.ExecuteNonQuery();
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

            SqlCommand addS = new SqlCommand("addStadium", conn);
            addS.CommandType = CommandType.StoredProcedure;
            addS.Parameters.Add(new SqlParameter("@name", na));
            addS.Parameters.Add(new SqlParameter("@location", loc));
            addS.Parameters.Add(new SqlParameter("@capacity", cap));



            addS.ExecuteNonQuery();
            conn.Close();
        }

        protected void deleteStadium(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String na = stadiumNameDelete.Text;


            SqlCommand delS = new SqlCommand("deleteStadium", conn);
            delS.CommandType = CommandType.StoredProcedure;
            delS.Parameters.Add(new SqlParameter("@name", na));



            delS.ExecuteNonQuery();
            conn.Close();
        }

        protected void blockFan(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String nat = blockFanNat.Text;


            SqlCommand bf = new SqlCommand("blockFan", conn);
            bf.CommandType = CommandType.StoredProcedure;
            bf.Parameters.Add(new SqlParameter("@nat_id", nat));



            bf.ExecuteNonQuery();
            conn.Close();
        }
    }
}