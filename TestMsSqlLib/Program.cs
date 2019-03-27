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
            string server = "127.0.0.1";
            string database = "test";
            string username = "sa";
            string password = "123456";
            Console.WriteLine(123);
            List<string> itemList = new List<string>{ "stu_name","stu_email","stu_phoneno","stu_course"};
            List<string> valueList = new List<string> { "tracy", "tracy@163.com", "13884888888", "jialidong" };
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\mssqlsystemresource.mdf;Integrated Security=True;Connect Timeout=3";
            //conn.Open();
            SqlLib sl = new SqlLib(server,database,username,password);
            Console.WriteLine("this is MSSqlLib test fun!");
            //Console.WriteLine(conn.ServerVersion);
            Console.WriteLine(sl.Version);
            sl.InsertOne("students",itemList, valueList);
            Console.WriteLine(sl.EchoSql());
            sl.CloseConn();
        }
    }
}
