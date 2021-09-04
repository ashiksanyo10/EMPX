using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeProductivityManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (new DB().login(Request.Form["username"], Request.Form["password"]))
            {
                Session["User"] = Request.Form["username"];
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                Response.Write("<script>alert('Login Failed')</script>");
            }
        }

    }
}