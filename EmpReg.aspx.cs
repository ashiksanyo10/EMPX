using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EmployeeProductivityManagement
{
    public partial class EmpReg : System.Web.UI.Page
    {
        DB obj = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadEmployees();
        }

        private void loadEmployees()
        {
            DataTable tab = new DataTable();
            try
            {
                tab = obj.getEmployees();
                if (tab.Rows.Count > 0)
                {
                    lblMessage.Text = "";
                    gvEmployees.DataSource = tab;
                    gvEmployees.DataBind();
                }
                else
                {
                    gvEmployees.Controls.Clear();
                    lblMessage.Text = "No Employees in DB";
                }
            }
            catch
            {
                gvEmployees.Controls.Clear();
                lblMessage.Text = "Something Unexpected Happened! Check your Internet and Try again";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!obj.deleteEmployee(int.Parse((sender as LinkButton).CommandArgument)))
                    throw new Exception();
                loadEmployees();
                lblMessage.Text="Employee Deleted Successfully";
            }
            catch
            {
                lblMessage.Text="Employee Deleting Failed";
            }
        }
    }
}