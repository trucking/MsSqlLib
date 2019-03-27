using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace MsSqlLib
{
    public class SqlLib
    {
        public SqlLib(string server,string database,string username,string password)
        {
            this.Server = server;
            this.Database = database;
            this.Username = username;
            this.Password = password;
            this.ConnString = @"Data Source = (LocalDB)\test; Integrated Security = True; Connect Timeout = 3";
            this.Conn = new SqlConnection(this.ConnString);
            this.Conn.Open();
            this.Version = this.Conn.ServerVersion;
        }
        public string ConnString { get; }
        public string Server { get; }
        public string Database { get; }
        public string Username { get; }
        public string Password { get; }
        private string sql = "";
        public SqlConnection Conn { get; }
        public string Version { get; }
        public void CloseConn()
        {
            this.Conn.Close();
        }
        public string GetVersion()
        {
            string version = "";
            return version;
        }
        public string EchoSql()
        {
            return this.sql;
        }
        //this is insert condition
        //insert into table (item1,item2,item3,item4...) values (val1,val2,val3,val4...)
        //or 
        //insert into talbe (item1,item2,item3,item4...) valuse((val1,val2,val3,val4...),(val5...)...)
        public int InsertOne(string table,List<string> itemList,List<string> valueList)
        {
            this.sql = "insert into " + table + " (";
            foreach(string key in itemList)
            {
                this.sql += key + ",";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += ") values(";
            foreach(string value in valueList)
            {
                this.sql += "'" + value + "',";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += ")";
            //SqlCommand command = new SqlCommand(this.sql,this.Conn);
            //return command.ExecuteNonQuery();  
            return 1;
        }
        public int Delete()
        {
            return 1;
        }
        public int Update()
        {
            return 1;
        }
        public DataSet Select()
        {
            DataSet ds = new DataSet();
            return ds;
        }
        
    }
}
