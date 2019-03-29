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
            //string server = "hds-039.hichina.com";
            string path = "./test.mdb";
            //string database = "hds0390432_db";
            //string username = "hds0390432";
            //string password = "wqd7698888";
            Console.WriteLine(123);
            List<string> itemList = new List<string>{ "id","item1","item2"};
            List<string> valueList1 = new List<string> { "4","tracy","test1"};
            List<string> valueList2 = new List<string> { "5", "judy", "test2" };
            List<string> valueList3 = new List<string> { "6", "jorden", "test3" };
            List<List<string>> valueListArr = new List<List<string>>();
            //valueListArr.Add(valueList1);
            //valueListArr.Add(valueList2);
            //valueListArr.Add(valueList3);
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\mssqlsystemresource.mdf;Integrated Security=True;Connect Timeout=3";
            //conn.Open();
            //SqlLib sl = new SqlLib(server,database,username,password);
            AccessLib.AccessLib accessLib = new AccessLib.AccessLib(path);
            Console.WriteLine("this is MSSqlLib test fun!");
            //Console.WriteLine(conn.ServerVersion);
            //Console.WriteLine(sl.Version);
            //sl.Insert("test",itemList, valueListArr);
            //accessLib.Insert("test", itemList, valueList2);
            string sql = "delete from test where id = 4";
            //string sql = "insert into test values ('4','item1','item2')";
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            keyValues.Add("item1", "hello");
            keyValues.Add("item2", "world");
            //List<string> items = new List<string>{ "id", "item1", "item2" };
            //accessLib.Delete("test", "id = 4");
            //accessLib.Update("test", keyValues, "id = 5");
            //accessLib.Select("test");
            DataSet ds = new DataSet();
            ds = accessLib.Select(itemList, "test", "id = 5");
            //Console.WriteLine(sl.EchoSql());
            Console.WriteLine(accessLib.EchoSql());
            Console.WriteLine("{0},{1},{2}",ds.Tables[0].Rows[0][0].ToString(), ds.Tables[0].Rows[0][1].ToString(), ds.Tables[0].Rows[0][2].ToString());
            //sl.Select("test","id = 5");
            //Console.WriteLine(sl.EchoSql());
            //sl.CloseConn();
            accessLib.CloseConn();
            
        }
    }
}
