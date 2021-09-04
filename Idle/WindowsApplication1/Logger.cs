using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Net;

namespace Win32_API
{
    class Logger
    {
        MySqlConnection con = null;
        MySqlCommand cmd = null;
        private string ipaddress;
        public Logger()
        {
            ipaddress = GetIP();
        }

        public void addLog(string ip ,string idleval )
        {
            con = new MySqlConnection("server=148.72.232.170;database=Dbdrowsiness;user id=usrDbdrowsiness;pwd=E03egd8$;port=3306");
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            string sql = string.Format("insert into tblidleentries ( ip , timeout ) values( '{0}' , '{1}' )", ip, idleval);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable getRestricted()
        {
            con = new MySqlConnection("server=148.72.232.170;database=Dbdrowsiness;user id=usrDbdrowsiness;pwd=E03egd8$;port=3306");
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            adap.SelectCommand.CommandText = "select * from tblRestrictedProcess";
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            con.Close();
            return buffer;
        }

        public void updateProcess(string processname)
        {
            con = new MySqlConnection("server=148.72.232.170;database=Dbdrowsiness;user id=usrDbdrowsiness;pwd=E03egd8$;port=3306");
            con.Open();
            cmd = new MySqlCommand();
            cmd.Connection = con;
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);  
            string sql = string.Format("insert into tblrpentries( process , ip , stamp ) values ( '{0}' , '{1}' , '{2}' )", processname, ipaddress, dt.ToString("yyyy-MM-d HH:mm:ss"));
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();
            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
            IPAddress[] addr = ipEntry.AddressList;
            return addr[addr.Length - 1].ToString();
        }
    }
}

/*
If entries exists with drowsiness + idle 

SELECT * FROM tbldrowsiness , tblidleentries WHERE tbldrowsiness.ip = tblidleentries.ip
AND ( tblidleentries.timeout >= tbldrowsiness.stamp AND tblidleentries.timeout <= tbldrowsiness.stamp)

*/