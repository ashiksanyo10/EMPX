using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace EmployeeProductivityManagement
{
    public partial class RestrictedApplications : System.Web.UI.Page
    {
        DB obj = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void loaddata()
        {
            try
            {
                DataTable tab = obj.getRestrictedProcess();
                if (tab.Rows.Count > 0)
                {
                    gvProcess.DataSource = tab;
                    gvProcess.DataBind();
                }
                else
                {
                    gvTest.Controls.Clear();
                    lblMessage.Text = "No Process addedd";
                }
            }
            catch
            {
                gvTest.Controls.Clear();
                lblMessage.Text = "Data Loading Failed";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int pid = int.Parse((sender as LinkButton).CommandArgument);
            try
            {
                if (obj.deleteProcess(pid))
                    loaddata();
                else
                    throw new Exception();
            }
            catch
            {
                Response.Write("<script>alert('Deletion Failed')</script>");
            }
        }

        protected void btnAdd_click(object sender, EventArgs e)
        {
            try
            {
                if (obj.addRestrictedProcess(txtAppName.Text))
                    loaddata();
                else
                    throw new Exception();
            }
            catch
            {
                Response.Write("<script>alert('Application Adding Failed')</script>");
            }
        }
    }
}