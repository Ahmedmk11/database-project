using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Milestone3
{
    public partial class AssocActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String h = host.Text;
            String g = guest.Text;
            String st = starttime.Text;
            String et = endtime.Text;

            SqlCommand addNewMatch = new SqlCommand("addNewMatch", conn);
            addNewMatch.CommandType = CommandType.StoredProcedure;
            addNewMatch.Parameters.Add(new SqlParameter("@first_club", h));
            addNewMatch.Parameters.Add(new SqlParameter("@second_club", g));
            addNewMatch.Parameters.Add(new SqlParameter("@start_time", st));
            addNewMatch.Parameters.Add(new SqlParameter("@end_time", et));


            addNewMatch.ExecuteNonQuery();
            conn.Close();
        }
    }
}