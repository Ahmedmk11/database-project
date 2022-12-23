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
    public partial class stadiumManagerActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Response.Redirect("start.aspx");
        }

        protected void stadiumInfo(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl t1 = new HtmlGenericControl("div");
            HtmlGenericControl t2 = new HtmlGenericControl("div");
            HtmlGenericControl t3 = new HtmlGenericControl("div");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            t1.InnerText = "Name";
            t2.InnerText = "Location";
            t3.InnerText = "Capacity";

            titlesRow.Controls.Add(t1);
            titlesRow.Controls.Add(t2);
            titlesRow.Controls.Add(t3);

            rowsContainer.Controls.Add(titlesRow);

            String sci = "SELECT name, location, capacity FROM stadium WHERE 'x'".Replace("x", Session["sm"].ToString());

            SqlCommand si = new SqlCommand(sci, conn);
            si.CommandType = CommandType.Text;
            SqlDataReader rdr = si.ExecuteReader();
            while (rdr.Read())
            {


                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String name = rdr.GetString(rdr.GetOrdinal("name"));
                String location = rdr.GetString(rdr.GetOrdinal("location"));
                String cap = rdr.GetString(rdr.GetOrdinal("capacity"));

                HtmlGenericControl n = new HtmlGenericControl("div");
                HtmlGenericControl l = new HtmlGenericControl("div");
                HtmlGenericControl c = new HtmlGenericControl("div");

                n.InnerText = name;
                l.InnerText = location;
                c.InnerText = cap;

                tmp.Controls.Add(n);
                tmp.Controls.Add(l);
                tmp.Controls.Add(c);

                rowsContainer.Controls.Add(tmp);
            }
            stadiumInfoContainer.Controls.Add(rowsContainer);

            rdr.Close();
            si.ExecuteNonQuery();
            conn.Close();
        }

        protected void reqReceived(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("div");
            HtmlGenericControl guestSpan = new HtmlGenericControl("div");
            HtmlGenericControl startTimeSpan = new HtmlGenericControl("div");
            HtmlGenericControl endTimeSpan = new HtmlGenericControl("div");
            HtmlGenericControl stadNameSpan = new HtmlGenericControl("div");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            hostSpan.InnerText = "Host";
            guestSpan.InnerText = "Guest";
            startTimeSpan.InnerText = "Start Time";
            endTimeSpan.InnerText = "End Time";
            stadNameSpan.InnerText = "Stadium Name";

            titlesRow.Controls.Add(hostSpan);
            titlesRow.Controls.Add(guestSpan);
            titlesRow.Controls.Add(startTimeSpan);
            titlesRow.Controls.Add(endTimeSpan);
            titlesRow.Controls.Add(stadNameSpan);

            rowsContainer.Controls.Add(titlesRow);

            String srr = "SELECT cr.name clubRep, hc.name hostClub, gc.name guestClub, m.start_time, m.end_time, h.status FROM HostRequest h inner JOIN StadiumManager sm ON h.manager_id = sm.smid INNER JOIN ClubRepresentative cr ON h.representative_id = cr.crid INNER JOIN Match m ON h.match_id = m.match_id INNER JOIN Club hc ON hc.club_id = m.host_club_id INNER JOIN Club gc ON m.guest_club_id = gc.club_id INNER JOIN Stadium s ON sm.stadium_id = s.sid WHERE s.name = 'x' ".Replace("x", Session["sm"].ToString());

            SqlCommand rr = new SqlCommand(srr, conn);
            rr.CommandType = CommandType.Text;
            SqlDataReader rdr = rr.ExecuteReader();
            while (rdr.Read())
            {
                //DateTime starttime = rdr.GetString(rdr.GetOrdinal(3));
                //DateTime starttime = rdr.GetDateTime(3);


                //DateTime endtime = rdr.GetString(rdr.GetOrdinal(4));
                //DateTime endtime = rdr.GetDateTime(4);

                

                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String rep = rdr.GetString(rdr.GetOrdinal("clubRep"));
                String host = rdr.GetString(rdr.GetOrdinal("hostClub"));
                String guest = rdr.GetString(rdr.GetOrdinal("guestClub"));
                DateTime dt = rdr.GetDateTime(3);
                String start = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt2 = rdr.GetDateTime(4);
                String end = dt2.ToString("yyyy-MM-dd HH:mm:ss");
                String ss = rdr.GetString(rdr.GetOrdinal("status"));

                HtmlGenericControl t1 = new HtmlGenericControl("div");
                HtmlGenericControl t2 = new HtmlGenericControl("div");
                HtmlGenericControl t3 = new HtmlGenericControl("div");
                HtmlGenericControl t4 = new HtmlGenericControl("div");
                HtmlGenericControl t5 = new HtmlGenericControl("div");
                HtmlGenericControl t6 = new HtmlGenericControl("div");

                t1.InnerText = rep;
                t2.InnerText = host;
                t3.InnerText = guest;
                t4.InnerText = start;
                t5.InnerText = end;
                t6.InnerText = ss;

                tmp.Controls.Add(t1);
                tmp.Controls.Add(t2);
                tmp.Controls.Add(t3);
                tmp.Controls.Add(t4);
                tmp.Controls.Add(t5);
                tmp.Controls.Add(t6);

                rowsContainer.Controls.Add(tmp);
            }
            requestsReceivedContainer.Controls.Add(rowsContainer);

            rdr.Close();
            rr.ExecuteNonQuery();
            conn.Close();
        }


        protected void acceptReq(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();


            String sm_us = Session["sm_us"].ToString();
            String host_name = host.Text;
            String guest_name = guest.Text;
            String start = starttime.Text;


            SqlCommand accR = new SqlCommand("acceptRequest", conn);
            accR.CommandType = CommandType.StoredProcedure;
            accR.Parameters.Add(new SqlParameter("@stadium_manager_username", sm_us));
            accR.Parameters.Add(new SqlParameter("@hosting_club_name", host_name));
            accR.Parameters.Add(new SqlParameter("@competing_club_name", guest_name));
            accR.Parameters.Add(new SqlParameter("@start_time", start));



            accR.ExecuteNonQuery();
            conn.Close();
        }

        protected void rejectReq(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();


            String sm_us = Session["sm_us"].ToString();
            String host_name = host.Text;
            String guest_name = guest.Text;
            String start = starttime.Text;


            SqlCommand rejR = new SqlCommand("rejectRequest", conn);
            rejR.CommandType = CommandType.StoredProcedure;
            rejR.Parameters.Add(new SqlParameter("@stadium_manager_username", sm_us));
            rejR.Parameters.Add(new SqlParameter("@hosting_club_name", host_name));
            rejR.Parameters.Add(new SqlParameter("@competing_club_name", guest_name));
            rejR.Parameters.Add(new SqlParameter("@start_time", start));



            rejR.ExecuteNonQuery();
            conn.Close();
        }
    }
}