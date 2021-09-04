using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace EmployeeProductivityManagement
{
    public partial class AnaLysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime Date = DateTime.Parse(Request.QueryString["Date"]);
            DataTable tab = new DB().getDashBoardData().AsEnumerable().Where(x => DateTime.Parse(x["recDate"].ToString()) == Date).CopyToDataTable();
            lblDate.Text = DateTime.Parse(tab.Rows[0]["recDate"].ToString()).ToShortDateString();
            lblIP.Text = tab.Rows[0]["ip"].ToString();
            lblIdle.Text = tab.Rows[0]["idleTime"].ToString();
            lblRestrictedApps.Text = tab.Rows[0]["restrictedProcess"].ToString(); 
        }

        protected void btnNotify_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bitmap = new Bitmap(1920, 1080);

                Graphics graphics = Graphics.FromImage(bitmap as System.Drawing.Image);
                graphics.CopyFromScreen(25, 25, 25, 25, bitmap.Size);

                bitmap.Save(Server.MapPath("~/img/report.jpg"), ImageFormat.Jpeg);
                RapidMailSender.Send("sumukhgupta2412@gmail.com", "Check out The Attachment", "Productivity Report", Server.MapPath("~/img/report.jpg"));
                Response.Write("<script>alert('User Notified')</script>");
            }
            catch
            {
                Response.Write("<script>alert('NotiFication Failed')</script>");
            }
          
        }
    }
}