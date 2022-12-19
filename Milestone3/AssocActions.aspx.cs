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

namespace Milestone3
{
    public partial class AssocActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void deleteMatch(object sender, EventArgs e)
        {

        }
        protected void viewClubsNeverMatched(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();



            SqlCommand nev = new SqlCommand("SELECT * FROM clubsNeverMatched", conn);
            nev.CommandType = CommandType.Text;
            SqlDataReader rdr = nev.ExecuteReader();
            HtmlGenericControl divHost = new HtmlGenericControl("div");
            HtmlGenericControl divGuest = new HtmlGenericControl("div");
            HtmlGenericControl hostguestContainer = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");

            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";

            divHost.Controls.Add(hostSpan);
            divGuest.Controls.Add(guestSpan);

            hostguestContainer.Controls.Add(divHost);
            hostguestContainer.Controls.Add(divGuest);
            clubsNeverMatchedContainer.Controls.Add(hostguestContainer);

            while (rdr.Read())
            {
                String host = rdr.GetString(rdr.GetOrdinal("Host"));
                Label h = new Label();
                h.Text = host;
                String guest = rdr.GetString(rdr.GetOrdinal("Guest"));
                Label g = new Label();
                g.Text = guest;
                divHost.Controls.Add(h);
                divGuest.Controls.Add(g);
            }

            rdr.Close();
            nev.ExecuteNonQuery();
            conn.Close();
        }
        protected void viewUpMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();


            HtmlGenericControl divHost = new HtmlGenericControl("div");
            HtmlGenericControl divGuest = new HtmlGenericControl("div");
            HtmlGenericControl hostguestContainer = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");

            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";

            divHost.Controls.Add(hostSpan);
            divGuest.Controls.Add(guestSpan);

            hostguestContainer.Controls.Add(divHost);
            hostguestContainer.Controls.Add(divGuest);
            upcomingMatchesContainer.Controls.Add(hostguestContainer);

            SqlCommand upcom = new SqlCommand("SELECT * FROM allMatches WHERE start_time < CURRENT_TIMESTAMP", conn);

            upcom.CommandType = CommandType.Text;
            SqlDataReader rdr = upcom.ExecuteReader();
            while (rdr.Read())
            {
                String host = rdr.GetString(rdr.GetOrdinal("Host Club"));
                String guest = rdr.GetString(rdr.GetOrdinal("Guest Club"));
                Label h = new Label();
                h.Text = host;
                Label g = new Label();
                g.Text = guest;

                divHost.Controls.Add(h);
                divGuest.Controls.Add(g);

            }

            rdr.Close();
            upcom.ExecuteNonQuery();
            conn.Close();
        }

        protected void viewPlayedMatch(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();


            HtmlGenericControl divHost = new HtmlGenericControl("div");
            HtmlGenericControl divGuest = new HtmlGenericControl("div");
            HtmlGenericControl hostguestContainer = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");

            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";

            divHost.Controls.Add(hostSpan);
            divGuest.Controls.Add(guestSpan);

            hostguestContainer.Controls.Add(divHost);
            hostguestContainer.Controls.Add(divGuest);
            playedMatchesContainer.Controls.Add(hostguestContainer);

            SqlCommand upcom = new SqlCommand("SELECT * FROM allMatches WHERE start_time > CURRENT_TIMESTAMP", conn);

            upcom.CommandType = CommandType.Text;
            SqlDataReader rdr = upcom.ExecuteReader();
            while (rdr.Read())
            {
                String host = rdr.GetString(rdr.GetOrdinal("Host Club"));
                String guest = rdr.GetString(rdr.GetOrdinal("Guest Club"));
                Label h = new Label();
                h.Text = host;
                Label g = new Label();
                g.Text = guest;


                divHost.Controls.Add(h);
                divGuest.Controls.Add(g);
            }

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