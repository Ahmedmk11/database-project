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
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net.NetworkInformation;


namespace Milestone3
{
    public partial class clubRepActions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logOut(object sender, EventArgs e)
        {
            Response.Redirect("loginPage.aspx");
        }
        protected void clubInfo(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String sci = "SELECT name, location FROM club WHERE name = 'x'".Replace("x", Session["cr"].ToString());

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            hostSpan.InnerText = "Club";
            guestSpan.InnerText = "Location";

            titlesRow.Controls.Add(hostSpan);
            titlesRow.Controls.Add(guestSpan);

            rowsContainer.Controls.Add(titlesRow);

            SqlCommand ci = new SqlCommand(sci, conn);
            ci.CommandType = CommandType.Text;
            SqlDataReader rdr = ci.ExecuteReader();
            while (rdr.Read())
            {
                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String host = rdr.GetString(rdr.GetOrdinal("name"));
                String guest = rdr.GetString(rdr.GetOrdinal("location"));

                HtmlGenericControl n = new HtmlGenericControl("div");
                HtmlGenericControl l = new HtmlGenericControl("div");

                n.InnerText = host;
                l.InnerText = guest;

                tmp.Controls.Add(n);
                tmp.Controls.Add(l);

                rowsContainer.Controls.Add(tmp);
            }
            clubInfoContainer.Controls.Add(rowsContainer);

            rdr.Close();
            ci.ExecuteNonQuery();
            conn.Close();
        }

        protected void upcomMatchClub(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();


            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl hostSpan = new HtmlGenericControl("span");
            HtmlGenericControl guestSpan = new HtmlGenericControl("span");
            HtmlGenericControl startTimeSpan = new HtmlGenericControl("span");
            HtmlGenericControl endTimeSpan = new HtmlGenericControl("span");
            HtmlGenericControl stadNameSpan = new HtmlGenericControl("span");

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

            String str = Session["cr"].ToString();
            String sci = "SELECT c1.name host, c2.name guest, m.start_time, m.end_time, s.name FROM Match m INNER JOIN Club C1 ON m.host_club_id = c1.club_id INNER JOIN Club C2 ON m.guest_club_id = c2.club_id LEFT OUTER JOIN Stadium s on s.sid = m.stadium_id WHERE m.start_time > CURRENT_TIMESTAMP AND c1.name = 'x' UNION SELECT c1.name, c2.name, m.start_time, m.end_time, s.name FROM Match m INNER JOIN Club C1 ON m.host_club_id = c1.club_id INNER JOIN Club C2 ON m.guest_club_id = c2.club_id LEFT OUTER JOIN Stadium s on s.sid = m.stadium_id WHERE m.start_time > CURRENT_TIMESTAMP AND c2.name = 'x'\r\n".Replace("x", str);

            SqlCommand ci = new SqlCommand(sci, conn);
            ci.CommandType = CommandType.Text;
            SqlDataReader rdr = ci.ExecuteReader();
            //SqlDataReader rdr1 = sti.ExecuteReader();
            while (rdr.Read())
            {
                HtmlGenericControl tmp = new HtmlGenericControl("div");

                String host = rdr.GetString(rdr.GetOrdinal("host"));
                String guest = rdr.GetString(rdr.GetOrdinal("guest"));
                String stadName;
                try
                {
                    stadName = rdr.GetString(rdr.GetOrdinal("name"));
                }
                catch (System.Data.SqlTypes.SqlNullValueException s)
                {
                    stadName = "none";
                }
                
                DateTime dt = rdr.GetDateTime(2);
                String start = dt.ToString("yyyy-MM-dd HH:mm:ss");
                DateTime dt2 = rdr.GetDateTime(3);
                String end = dt2.ToString("yyyy-MM-dd HH:mm:ss");

                HtmlGenericControl h = new HtmlGenericControl("div");
                HtmlGenericControl g = new HtmlGenericControl("div");
                HtmlGenericControl st = new HtmlGenericControl("div");
                HtmlGenericControl et = new HtmlGenericControl("div");
                HtmlGenericControl sn = new HtmlGenericControl("div");

                h.InnerText = host;
                g.InnerText = guest;
                st.InnerText = start;
                et.InnerText = end;
                sn.InnerText = stadName;

                tmp.Controls.Add(h);
                tmp.Controls.Add(g);
                tmp.Controls.Add(st);
                tmp.Controls.Add(et);
                tmp.Controls.Add(sn);

                rowsContainer.Controls.Add(tmp);
            }
            rdr.Close();
            


            clubUpcomingContainer.Controls.Add(rowsContainer);
            
            ci.ExecuteNonQuery();
            conn.Close();
        }




        protected void availableStadium(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            HtmlGenericControl titlesRow = new HtmlGenericControl("div");

            HtmlGenericControl t1 = new HtmlGenericControl("span");
            HtmlGenericControl t2 = new HtmlGenericControl("span");
            HtmlGenericControl t3 = new HtmlGenericControl("span");

            HtmlGenericControl rowsContainer = new HtmlGenericControl("div");


            t1.InnerText = "Name";
            t2.InnerText = "Location";
            t3.InnerText = "Capacity";

            titlesRow.Controls.Add(t1);
            titlesRow.Controls.Add(t2);
            titlesRow.Controls.Add(t3);

            rowsContainer.Controls.Add(titlesRow);

            conn.Open();
            
            String na = dtCRA.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";

            if (na == "" )
            {
                cre.Controls.Add(lbl1);
            }
            else
            {
                SqlCommand availS = new SqlCommand("SELECT s.name, s.location, s.capacity FROM Stadium s EXCEPT(SELECT s.name, s.location, s.capacity    FROM Stadium s       inner JOIN match m ON (s.sid = m.stadium_id)   WHERE s.status = 1 AND (m.start_time = 'x'))\r\n".Replace("x", na), conn);
                availS.CommandType = CommandType.Text;
                SqlDataReader rdr = availS.ExecuteReader();
                while (rdr.Read())
                {
                    HtmlGenericControl tmp = new HtmlGenericControl("div");

                    String name = rdr.GetString(rdr.GetOrdinal("name"));
                    String location = rdr.GetString(rdr.GetOrdinal("location"));
                    String cap = rdr.GetInt32(rdr.GetOrdinal("capacity")).ToString();

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
                AvailableStadiumsContainer.Controls.Add(rowsContainer);
                rdr.Close();
                availS.ExecuteNonQuery();
            }
            
            conn.Close();
        }

        protected void addReq(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();
            // String viewava= "(@X DATETIME) Returns @temp TABLE ( name varchar(20), location varchar(20), capacity varchar(20) ) AS Begin INSERT INTO @temp SELECT s.name, s.location, s.capacity FROM Stadium s LEFT OUTER JOIN match m ON (s.sid = m.stadium_id) WHERE s.status = 1 AND (m.stadium_id IS NULL OR m.start_time <> @X)".Replace("@X", Session[us]);
            String ho = Session["cr"].ToString();
            String sn = snCRA.Text;
            String d = stCRA.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";
            if (sn == "" || d == "")
            {
                craCLR.Controls.Add(lbl1);
            }
            else
            {
                SqlCommand hostReq = new SqlCommand("addHostRequest", conn);


                hostReq.CommandType = CommandType.StoredProcedure;
                hostReq.Parameters.Add(new SqlParameter("@club_name", ho));
                hostReq.Parameters.Add(new SqlParameter("@stadium_name", sn));
                hostReq.Parameters.Add(new SqlParameter("@start_time", d));

                loginPage.EmptyTextBoxes(craCLR);


                hostReq.ExecuteNonQuery();
            }
            conn.Close();

            //Response.Redirect("AssocActions.aspx");

        }
    }
}