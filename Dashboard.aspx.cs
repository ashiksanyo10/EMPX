using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace EmployeeProductivityManagement
{
    public partial class Dashboard : System.Web.UI.Page
    {
        DB obj = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            try
            {
                DataTable tab = new DataTable();
                Label lnl = new Label();
                tab = obj.getDashBoardData();
                if (tab.Rows.Count > 0)
                {
                    Repeater1.DataSource = tab;
                    Repeater1.DataBind();
                }
                else
                {
                    lblMessage.Text = "No Data in DB";
                    lblMessage.ForeColor = System.Drawing.Color.White;
                    lblMessage.Font.Bold = true;
                }
            }
            catch(Exception er)
            {
                lblMessage.Text = "SomeThing Unexpected happened" + er.ToString();
                lblMessage.ForeColor = System.Drawing.Color.White;
                lblMessage.Font.Bold = true;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Parse((sender as Button).CommandArgument.Split(',')[0]);
            string ip = (sender as Button).CommandArgument.Split(',')[1];
            try 
            {
                if (!new DB().resetDashboard( ip))
                    throw new Exception();
                Response.Write("<script>alert('Reset Performed Successfully')</script>");
            }
            catch 
            {
                Response.Write("<script>alert('Reset Failed')</script>");
            }
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Parse((sender as Button).CommandArgument);
            DataTable tab = new DB().getDashBoardData().AsEnumerable().Where(x => DateTime.Parse(x["recDate"].ToString()) == Date).CopyToDataTable();
            
            LocalReport lr = new LocalReport();
            lr.ReportPath = Server.MapPath("~/Report1.rdlc");
            ReportDataSource rd = new ReportDataSource("DataSet1",tab);
            lr.DataSources.Add(rd);
            lr.SetParameters(new ReportParameter("Date", Date.ToShortDateString()));

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>PDF</OutputFormat>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-length", renderedBytes.Length.ToString());
            Response.BinaryWrite(renderedBytes);  
        }
    }
}