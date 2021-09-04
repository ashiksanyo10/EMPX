using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace EmployeeProductivityManagement
{
    public class DB
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;

        public DB()
        {
            con = new MySqlConnection("server=148.72.232.170;database=Dbdrowsiness;user id=usrDbdrowsiness;password=E03egd8$");
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
        }

        #region Employees
        public bool addEmployee(string name, string email, string phonenumber, string DOJ, string Dept, float salary, string jd,string photo)
        {
            cmd.CommandText = string.Format(
                "Insert into tblemployee(name,email,phonenumber,doj,dept,salary,jd,photo)" +
                "values('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}')",
                name,email,phonenumber,DOJ,Dept,salary,jd,photo);
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool deleteEmployee(int empid)
        {
            cmd.CommandText = string.Format(
                "delete from tblemployee  where empid={0}", empid);
            return cmd.ExecuteNonQuery() > 0;
        }

        public DataTable getEmployees()
        {
            cmd.CommandText = "select * from tblemployee";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            return tab;
        }
        #endregion

        public DataTable getDashBoardData()
        {
            cmd.CommandText = "SELECT COUNT(*)*10 AS idleTime , DATE(stamp)AS recDate , ip FROM tbldrowsiness WHERE ip IN ( SELECT DISTINCT ip FROM tbldrowsiness ) AND stamp IN (SELECT stamp FROM tblidleentries) GROUP BY DATE(stamp)";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            tab = fillUsersAndRestrictedProcess(tab);
            return tab;
        }

        public DataTable getDashBoardData(DateTime date)
        {
            cmd.CommandText = string.Format(
                "SELECT COUNT(*)*10 AS idleTime , DATE(stamp)AS recDate , ip FROM tbldrowsiness WHERE ip IN ( SELECT DISTINCT ip FROM tbldrowsiness ) AND stamp IN (SELECT stamp FROM tblidleentries) and where DATE(stamp) = '{0}'",date);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            tab = fillUsersAndRestrictedProcess(tab);
            return tab;
        }

        private DataTable fillUsersAndRestrictedProcess(DataTable tab)
        {
            DataTable newTab = tab;
            DataColumn dcUser = new DataColumn("user");
            newTab.Columns.Add(dcUser);
            DataColumn dcRetrictedProcess = new DataColumn("restrictedProcess",typeof(int));
            newTab.Columns.Add(dcRetrictedProcess);
            foreach (DataRow dr in newTab.Rows)
            {
                string user = getUserByIp(dr["ip"].ToString());
                dr["user"] = user;
                string retrictedProcess = getRestrictedProcessByIp(dr["ip"].ToString());
                dr["restrictedProcess"] = int.Parse(retrictedProcess);
            }
            return newTab;
        }
        //Process Wise SELECT COUNT(*)*10 AS usageTime , DATE(stamp)AS recDate ,PROCESS, ip FROM tblrpentries WHERE ip IN ( SELECT DISTINCT ip FROM tblrpentries ) GROUP BY DATE(stamp),PROCESS 
        //Over all
        private string getRestrictedProcessByIp(string ip)
        {
            cmd.CommandText = "SELECT COUNT(*)*10 AS usageTime , DATE(stamp)AS recDate , ip FROM tblrpentries WHERE ip IN ( SELECT DISTINCT ip FROM tblrpentries ) GROUP BY DATE(stamp)";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            //if (tab.Rows.Count > 0)
            //tab = tab.AsEnumerable().Where(x => x["ip"].ToString() == ip).CopyToDataTable();
            return tab.Rows.Count > 0 ? tab.Rows[0]["usageTime"].ToString() : "0";
        }

        private string getUserByIp(string ip)
        {
            cmd.CommandText = "select * from tblemployee where Ip='"+ip+"'";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            return tab.Rows.Count > 0 ? tab.Rows[0]["name"].ToString():"Not Mapped" ;
        }

        internal DataTable getEmployeesById(string p)
        {
            cmd.CommandText = "select * from tblemployee where empid="+p;
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            return tab;
        }

        internal bool AssignIP(string email, string ip)
        {
            cmd.CommandText = string.Format(
              "update tblemployee set Ip='{0}' where email='{1}'", ip, email);
            return cmd.ExecuteNonQuery() > 0;
        }

        internal bool login(string username, string password)
        {
            cmd.CommandText = string.Format(
             "select count(*) from tbladmincreds where username='{0}' and password='{1}'", username, password);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        internal bool UpdatePassword(string username, string password)
        {
            cmd.CommandText = string.Format(
              "update tbladmincreds set password='{0}' where username='{1}'", password, username);
            return cmd.ExecuteNonQuery() > 0;
        }

        internal DataTable getRestrictedProcess()
        {
            cmd.CommandText = "select * from tblRestrictedProcess";
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);
            return tab;
        }

        internal bool deleteProcess(int pid)
        {
            cmd.CommandText = string.Format(
                 "delete from tblRestrictedProcess  where pid={0}", pid);
            return cmd.ExecuteNonQuery() > 0;
        }

        internal bool addRestrictedProcess(string appName)
        {
            cmd.CommandText = string.Format(
                "Insert into tblRestrictedProcess(resprocess)" +
                "values('{0}')",
                appName);
            return cmd.ExecuteNonQuery() > 0;
        }

        internal bool resetDashboard( string ip)
        {
            List<bool> results = new List<bool>();
            cmd.CommandText = string.Format(
                  "delete from tbldrowsiness  where ip='{0}'", ip);
            results.Add(cmd.ExecuteNonQuery() > 0);
            cmd.CommandText = string.Format(
                  "delete from tblidleentries  where ip='{0}'", ip);
            results.Add(cmd.ExecuteNonQuery() > 0);

            return !results.Contains(false);
        }
    }
}