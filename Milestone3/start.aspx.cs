using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void chooseSa(object sender, EventArgs e)
        //{
            
          //  Response.Redirect("SystemAdminLogin.aspx");
            
        //}
        protected void chooseSam(object sender, EventArgs e)
        {
            Response.Redirect("AssocRegister.aspx");
        }
        protected void chooseSm(object sender, EventArgs e)
        {
            Response.Redirect("StadiumManagerReg.aspx");
        }
        protected void chooseCr(object sender, EventArgs e)
        {
            Response.Redirect("clubRepRegister.aspx");
        }
        protected void chooseFan(object sender, EventArgs e)
        {
            Response.Redirect("FanRegister.aspx");
        }

         
    }
}