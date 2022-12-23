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
    public partial class ClubRepresentativeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginclubrepresentative(object sender, EventArgs e)
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
                String clubTemp = "SELECT c.name FROM ClubRepresentative cr INNER JOIN club c ON cr.club_id = c.club_id WHERE cr.username = 'x'".Replace("x", username);
                SqlCommand clubTempT = new SqlCommand(clubTemp, conn);
                clubTempT.CommandType = CommandType.Text;
                String club = clubTempT.ExecuteScalar().ToString();
                Session["cr"] = club;
                Response.Redirect("clubRepActions.aspx");
            }
            conn.Close();
        }

        //protected void openRegister(object sender, EventArgs e)
       //{
       //     Response.Redirect("clubRepRegister.aspx");
       // }
    }
}