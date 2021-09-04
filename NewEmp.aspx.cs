using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace EmployeeProductivityManagement
{
    public partial class NewEmp : System.Web.UI.Page
    {
        DB obj = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddEmployee_Click(object sender, EventArgs e)
        {
            string path = "~/img/" + fileInput.FileName;
            if (Path.GetExtension(path).ToLower().EndsWith("jpg"))
            {
                fileInput.SaveAs(Server.MapPath(path));
            }
            else
            {
                path = "~/img/usericon.jpg";
            }
            try
            {
                if (!obj.addEmployee(txtName.Text, txtEmail.Text, txtPhoneNumber.Text, txtDOJ.Text, ddlDept.SelectedValue, float.Parse(txtSalary.Text), txtJD.Text, path))
                    throw new Exception();
                Response.Write("<script>alert('Employee Added Successfully')</script>");
            }
            catch
            {
                Response.Write("<script>alert('Employee Adding Failed')</script>");
            }
        }
    }
}