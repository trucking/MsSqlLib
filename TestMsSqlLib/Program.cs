using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MsSqlLib;
using System.Data;
using System.Data.SqlClient;

namespace TestMsSqlLib
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = "hds-039.hichina.com";
            string database = "hds0390432_db";
            string username = "hds0390432";
            string password = "wqd7698888";
            Console.WriteLine(123);
            List<string> itemList = new List<string>{ "id","item1","item2"};
            List<string> valueList1 = new List<string> { "4","tracy","test1"};
            List<string> valueList2 = new List<string> { "5", "judy", "test2" };
            List<string> valueList3 = new List<string> { "6", "jorden", "test3" };
            List<List<string>> valueListArr = new List<List<string>>();
            valueListArr.Add(valueList1);
            valueListArr.Add(valueList2);
            valueListArr.Add(valueList3);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\mssqlsystemresource.mdf;Integrated Security=True;Connect Timeout=3";
            //conn.Open();
            SqlLib sl = new SqlLib(server,database,username,password);
            Console.WriteLine("this is MSSqlLib test fun!");
            //Console.WriteLine(conn.ServerVersion);
            Console.WriteLine(sl.Version);
            sl.Insert("test",itemList, valueListArr);
            Console.WriteLine(sl.EchoSql());
            sl.CloseConn();
        }
    }
}
