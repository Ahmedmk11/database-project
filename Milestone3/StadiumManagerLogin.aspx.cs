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
    public partial class StadiumManagerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginstadiumManager(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String username = loginUsername.Text;
            String password = loginPassword.Text;


            String usernameInput = "SELECT username FROM SystemUser WHERE username='x' ".Replace("x", username);
            String passwordInput = "SELECT password FROM SystemUser WHERE password='x' ".Replace("x", password);
            SqlCommand us = new SqlCommand(usernameInput, conn);
            SqlCommand pass = new SqlCommand(passwordInput, conn);

            us.CommandType = CommandType.Text;
            pass.CommandType = CommandType.Text;

            String usSuc = us.ExecuteScalar().ToString();
            String passSuc = pass.ExecuteScalar().ToString();


            if (usSuc == username && passSuc == password)
            {
                String clubTemp = "SELECT s.name FROM StadiumManager sm INNER JOIN Stadium s ON s.sid = sm.stadium_id WHERE sm.username = 'x'".Replace("x", username);
                SqlCommand clubTempT = new SqlCommand(clubTemp, conn);
                clubTempT.CommandType = CommandType.Text;
                String club = clubTempT.ExecuteScalar().ToString();
                Session["sm_us"] = username;
                Session["sm"] = club;
                Response.Redirect("stadiumManagerActions.aspx");
            }
            conn.Close();
        }
    }
}