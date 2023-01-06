using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Milestone3
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }

        protected void login(object sender, EventArgs e)
        {
            String conStr = WebConfigurationManager.ConnectionStrings["Sports"].ToString();

            SqlConnection conn = new SqlConnection(conStr);

            conn.Open();

            String username = loginUsername.Text;
            String password = loginPassword.Text;

            HtmlGenericControl lbl1 = new HtmlGenericControl("div");
            lbl1.InnerText = "Please enter valid data.";
      
            if (username == "" || password == "")
            {
                lpID.Controls.Add(lbl1);
            }
            else
            {
                String usernameInput = "SELECT username FROM SystemUser WHERE username='x' ".Replace("x", username);
                String passwordInput = "SELECT password FROM SystemUser WHERE username='x' ".Replace("x", username);
                SqlCommand us = new SqlCommand(usernameInput, conn);
                SqlCommand pass = new SqlCommand(passwordInput, conn);

                us.CommandType = CommandType.Text;
                pass.CommandType = CommandType.Text;

                String usSuc = "";
                String passSuc = "";
                if (us.ExecuteScalar() != null)
                {
                    usSuc = us.ExecuteScalar().ToString();
                }
                if (pass.ExecuteScalar() != null)
                {
                    passSuc = pass.ExecuteScalar().ToString();
                }

                //String usSuc = us.ExecuteScalar().ToString();
                //String passSuc = pass.ExecuteScalar().ToString();


                String typeCheckSA = "SELECT username FROM SystemAdmin WHERE username='x' ".Replace("x", username);
                SqlCommand tCSA = new SqlCommand(typeCheckSA, conn);
                tCSA.CommandType = CommandType.Text;
                String tCSucSA = "";
                if (tCSA.ExecuteScalar() != null)
                {
                    tCSucSA = tCSA.ExecuteScalar().ToString();
                }

                String typeCheckSM = "SELECT username FROM stadiumManager WHERE username='x' ".Replace("x", username);
                SqlCommand tCSM = new SqlCommand(typeCheckSM, conn);
                tCSM.CommandType = CommandType.Text;
                String tCSucSM = "";
                if (tCSM.ExecuteScalar() != null)
                {
                    tCSucSM = tCSM.ExecuteScalar().ToString();
                }

                String typeCheckF = "SELECT username FROM fan WHERE username='x' ".Replace("x", username);
                SqlCommand tCF = new SqlCommand(typeCheckF, conn);
                tCF.CommandType = CommandType.Text;
                String tCSucF = "";
                if (tCF.ExecuteScalar() != null)
                {
                    tCSucF = tCF.ExecuteScalar().ToString();
                }

                String typeCheckCR = "SELECT username FROM ClubRepresentative WHERE username='x' ".Replace("x", username);
                SqlCommand tCCR = new SqlCommand(typeCheckCR, conn);
                tCCR.CommandType = CommandType.Text;
                String tCSucCR = "";
                if (tCCR.ExecuteScalar() != null)
                {
                    tCSucCR = tCCR.ExecuteScalar().ToString();
                }

                String typeCheckSAM = "SELECT username FROM SportsAssociationManager WHERE username='x' ".Replace("x", username);
                SqlCommand tCSAM = new SqlCommand(typeCheckSAM, conn);
                tCSAM.CommandType = CommandType.Text;
                String tCSucSAM = "";
                if (tCSAM.ExecuteScalar() != null)
                {
                    tCSucSAM = tCSAM.ExecuteScalar().ToString();
                }

                if (usSuc == username && passSuc == password && username == tCSucSA)
                {
                    Response.Redirect("SystemAdminActions.aspx");
                }
                else if (usSuc == username && passSuc == password && username == tCSucSM)
                {
                    String clubTemp = "SELECT s.name FROM StadiumManager sm INNER JOIN Stadium s ON s.sid = sm.stadium_id WHERE sm.username = 'x'".Replace("x", username);
                    SqlCommand clubTempT = new SqlCommand(clubTemp, conn);
                    clubTempT.CommandType = CommandType.Text;
                    String club = clubTempT.ExecuteScalar().ToString();
                    Session["sm_us"] = username;
                    Session["sm"] = club;
                    Response.Redirect("stadiumManagerActions.aspx");
                }
                else if (usSuc == username && passSuc == password && username == tCSucF)
                {
                    String clubTemp = "SELECT national_id FROM Fan WHERE username = 'x'".Replace("x", username);
                    SqlCommand clubTempT = new SqlCommand(clubTemp, conn);
                    clubTempT.CommandType = CommandType.Text;
                    String club = clubTempT.ExecuteScalar().ToString();
                    Session["fan"] = club;
                    Response.Redirect("FanActions.aspx");
                }
                else if (usSuc == username && passSuc == password && username == tCSucCR)
                {
                    String clubTemp = "SELECT c.name FROM ClubRepresentative cr INNER JOIN club c ON cr.club_id = c.club_id WHERE cr.username = 'x'".Replace("x", username);
                    SqlCommand clubTempT = new SqlCommand(clubTemp, conn);
                    clubTempT.CommandType = CommandType.Text;
                    String club = clubTempT.ExecuteScalar().ToString();
                    Session["cr"] = club;
                    Response.Redirect("clubRepActions.aspx");
                }
                else if (usSuc == username && passSuc == password && username == tCSucSAM)
                {
                    Response.Redirect("AssocActions.aspx");
                }


                HtmlGenericControl cnt = (HtmlGenericControl)Page.FindControl("loginFailed");
                HtmlGenericControl lbl = new HtmlGenericControl("div");
                lbl.InnerText = "";
                if ((tCSucSAM == "" && tCSucSM == "" && tCSucCR == "" && tCSucSA == "" && tCSucF == "") || passSuc != password)
                {
                    //< div id = "loginFalied" runat = "server" ></ div >
                    lbl.InnerText = "Incorrect username/password";
                }

                cnt.Controls.Add(lbl);
            }

            conn.Close();
        }
    }
}
