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
using System.Web.UI.HtmlControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Milestone3
{
    public partial class AssocActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");
        }

        protected void deleteMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String h = host.Text;
            String g = guest.Text;
            String st = starttime.Text;
            String et = endtime.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (h == "" || g == "" || st == "" || et == "")
            {
                aae.Controls.Add(lbl1);
            }
            else
            {
                SqlCommand addNewMatch = new SqlCommand("deleteMatch", conn);
                addNewMatch.CommandType = CommandType.StoredProcedure;
                addNewMatch.Parameters.Add(new SqlParameter("@first_club", h));
                addNewMatch.Parameters.Add(new SqlParameter("@second_club", g));

                loginPage.EmptyTextBoxes(aae);

                addNewMatch.ExecuteNonQuery();
            }

                
            conn.Close();
        }
        protected void viewClubsNeverMatched(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";

            titlesRow.Controls.Add(hostSpan);
            titlesRow.Controls.Add(guestSpan);

            rowsContainer.Controls.Add(titlesRow);

            SqlCommand upcom = new SqlCommand("SELECT * FROM clubsNeverMatched", conn);

            upcom.CommandType = CommandType.Text;
            SqlDataReader rdr = upcom.ExecuteReader();
            while (rdr.Read())
            {
                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String host = rdr.GetString(rdr.GetOrdinal("Host"));
                String guest = rdr.GetString(rdr.GetOrdinal("Guest"));
             
                HtmlGenericControl h = new HtmlGenericControl("div");
                HtmlGenericControl g = new HtmlGenericControl("div");

                h.InnerText = host;
                g.InnerText = guest;

                tmp.Controls.Add(h);
                tmp.Controls.Add(g);

                rowsContainer.Controls.Add(tmp);
            }

            clubsNeverMatchedContainer.Controls.Add(rowsContainer);

            rdr.Close();
            upcom.ExecuteNonQuery();
            conn.Close();
        }
        protected void viewUpMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");
            HtmlGenericControl startTimeSpan = new HtmlGenericControl("span");
            HtmlGenericControl endTimeSpan = new HtmlGenericControl("span");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";
            startTimeSpan.InnerText = "Start Time";
            endTimeSpan.InnerText = "End Time";

            titlesRow.Controls.Add(hostSpan);
            titlesRow.Controls.Add(guestSpan);
            titlesRow.Controls.Add(startTimeSpan);
            titlesRow.Controls.Add(endTimeSpan);

            rowsContainer.Controls.Add(titlesRow);

            SqlCommand upcom = new SqlCommand("SELECT hc.name AS 'Host Club', gc.name AS 'Guest Club', m.start_time, m.end_time\r\nFROM Club hc INNER JOIN Match m\r\nON hc.club_id = m.host_club_id\r\nINNER JOIN Club gc\r\nON gc.club_id = m.guest_club_id\r\nWHERE m.start_time > CURRENT_TIMESTAMP", conn);

            upcom.CommandType = CommandType.Text;
            SqlDataReader rdr = upcom.ExecuteReader();
            while (rdr.Read())
            {

                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String host = rdr.GetString(rdr.GetOrdinal("Host Club"));
                String guest = rdr.GetString(rdr.GetOrdinal("Guest Club"));
                DateTime dt = rdr.GetDateTime(2);
                String start = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt2 = rdr.GetDateTime(3);
                String end = dt2.ToString("yyyy-MM-dd HH:mm:ss");

                HtmlGenericControl h = new HtmlGenericControl("div");
                HtmlGenericControl g = new HtmlGenericControl("div");
                HtmlGenericControl st = new HtmlGenericControl("div");
                HtmlGenericControl et = new HtmlGenericControl("div");

                h.InnerText = host;
                g.InnerText = guest;
                st.InnerText = start;
                et.InnerText = end;

                tmp.Controls.Add(h);
                tmp.Controls.Add(g);
                tmp.Controls.Add(st);
                tmp.Controls.Add(et);

                rowsContainer.Controls.Add(tmp);
            }

            upcomingMatchesContainer.Controls.Add(rowsContainer);

            rdr.Close();
            upcom.ExecuteNonQuery();
            conn.Close();
        }

        protected void viewPlayedMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");
            HtmlGenericControl startTimeSpan = new HtmlGenericControl("span");
            HtmlGenericControl endTimeSpan = new HtmlGenericControl("span");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";
            startTimeSpan.InnerText = "Start Time";
            endTimeSpan.InnerText = "End Time";

            titlesRow.Controls.Add(hostSpan);
            titlesRow.Controls.Add(guestSpan);
            titlesRow.Controls.Add(startTimeSpan);
            titlesRow.Controls.Add(endTimeSpan);

            rowsContainer.Controls.Add(titlesRow);

            SqlCommand upcom = new SqlCommand("SELECT hc.name AS 'Host Club', gc.name AS 'Guest Club', m.start_time, m.end_time\r\nFROM Club hc INNER JOIN Match m\r\nON hc.club_id = m.host_club_id\r\nINNER JOIN Club gc\r\nON gc.club_id = m.guest_club_id\r\nWHERE m.start_time < CURRENT_TIMESTAMP", conn);

            upcom.CommandType = CommandType.Text;
            SqlDataReader rdr = upcom.ExecuteReader();
            while (rdr.Read())
            {

                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String host = rdr.GetString(rdr.GetOrdinal("Host Club"));
                String guest = rdr.GetString(rdr.GetOrdinal("Guest Club"));
                DateTime dt = rdr.GetDateTime(2);
                String start = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt2 = rdr.GetDateTime(3);
                String end = dt2.ToString("yyyy-MM-dd HH:mm:ss");

                HtmlGenericControl h = new HtmlGenericControl("div");
                HtmlGenericControl g = new HtmlGenericControl("div");
                HtmlGenericControl st = new HtmlGenericControl("div");
                HtmlGenericControl et = new HtmlGenericControl("div");

                h.InnerText = host;
                g.InnerText = guest;
                st.InnerText = start;
                et.InnerText = end;

                tmp.Controls.Add(h);
                tmp.Controls.Add(g);
                tmp.Controls.Add(st);
                tmp.Controls.Add(et);

                rowsContainer.Controls.Add(tmp);
            }

            playedMatchesContainer.Controls.Add(rowsContainer);

            rdr.Close();
            upcom.ExecuteNonQuery();
            conn.Close();
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

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (h == "" || g == "" || st == "" || et == "")
            {
                aae.Controls.Add(lbl1);
            }
            else
            {

                SqlCommand addNewMatch = new SqlCommand("addNewMatch", conn);
                addNewMatch.CommandType = CommandType.StoredProcedure;
                addNewMatch.Parameters.Add(new SqlParameter("@first_club", h));
                addNewMatch.Parameters.Add(new SqlParameter("@second_club", g));
                addNewMatch.Parameters.Add(new SqlParameter("@start_time", st));
                addNewMatch.Parameters.Add(new SqlParameter("@end_time", et));

                loginPage.EmptyTextBoxes(aae);

                addNewMatch.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}