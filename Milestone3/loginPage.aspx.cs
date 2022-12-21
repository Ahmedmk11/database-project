using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void login(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Sports;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM SystemUser WHERE username= ", con);
            
        }
    }
}