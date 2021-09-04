using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeProductivityManagement
{
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                DB obj = new DB();
                if (obj.login(Session["User"].ToString(), txtPasswordO.Text))
                {
                    if (obj.UpdatePassword(Session["User"].ToString(), txtPasswordN.Text))
                        Response.Write("<script>alert('Password Updated Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invalid Old Password')</script>");
                }
            }
            catch
            {
                Response.Write("<script>alert('Password Updation Failed')</script>");
            }

        }
    }
}