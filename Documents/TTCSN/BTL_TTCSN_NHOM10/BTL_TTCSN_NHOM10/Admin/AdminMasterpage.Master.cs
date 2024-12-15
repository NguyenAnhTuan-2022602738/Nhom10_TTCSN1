using BTL_TTCSN_NHOM10.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_TTCSN_NHOM10.Admin
{
    public partial class AdminMasterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Login_LogoutPage/Login.aspx");
            }

            Users currentUser = (Users)Session["User"];

            if(currentUser.Role_id != 1)
            {
                Response.Redirect("~/Client/Default.aspx");
            }
        }
    }
}