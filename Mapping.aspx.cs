using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EmployeeProductivityManagement
{
    public partial class Mapping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tab = new DB().getEmployees();
                ddlUsers.DataSource = tab;
                ddlUsers.DataTextField = "name";
                ddlUsers.DataValueField = "empid";
                ddlUsers.DataBind();
                ddlUsers.Items.Insert(0, "Select User");
            }
        }

        protected void ddlUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable tab = new DB().getEmployeesById(ddlUsers.SelectedValue);
            txtName.Text = tab.Rows[0]["name"].ToString();
            txtEmail.Text = tab.Rows[0]["email"].ToString();
            txtPhone.Text = tab.Rows[0]["phonenumber"].ToString();
            userImage.Src = tab.Rows[0]["photo"].ToString();
            txtIP.Text=tab.Rows[0]["Ip"].ToString();
        }

        protected void btnAssignIP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!new DB().AssignIP(txtEmail.Text, txtIP.Text))
                    throw new Exception();
                Response.Write("<script>alert('IP Address Assigned Successfully')</script>");
            }
            catch
            {
                Response.Write("<script>alert('IP Address Assiging Failed')</script>");
            }
        }
    }
}