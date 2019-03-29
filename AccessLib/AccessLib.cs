using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace AccessLib
{
    public class AccessLib
    {
        public AccessLib(string path, string username = "", string password = "")
        {
            try
            {
                this.path = path;
                this.Username = username;
                this.Password = password;
                
                this.ConnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + this.path;
                this.Conn = new OleDbConnection(this.ConnString);
                this.Conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("连接失败本地access文件失败:{0}", ex.ToString());
            }
        }

        public string ConnString { get; }
       
        public string path { get; }
        public string Username { get; }
        public string Password { get; }
        private string sql = "";


        public OleDbConnection Conn { get; }
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
        /*
         *    Insert操作，参数分别为表名（string），字段（List<string>），值（List<string>)
         */
        public int Insert(string table, List<string> itemList, List<string> valueList)
        {
            this.sql = "insert into " + table + " (";
            foreach (string key in itemList)
            {
                this.sql += key + ",";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += ") values (";
            foreach (string value in valueList)
            {
                this.sql += "'" + value + "',";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += ")";
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            return command.ExecuteNonQuery();
            //return 1;
        }
        /*
         *  用于一次插入多条数据，Insert的重载
         */
        public int Insert(string table, List<string> itemList, List<List<string>> valueListArray)
        {
            this.sql = "insert into " + table + " (";
            foreach (string key in itemList)
            {
                this.sql += key + ",";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += ") values ";
            int i = 1;
            foreach (List<string> value in valueListArray)
            {
                if (i == 1)
                {
                    this.sql += "(";
                }
                else
                {
                    this.sql += ",(";
                }
                foreach (string v in value)
                {
                    this.sql += "'" + v + "',";
                }
                this.sql = this.sql.TrimEnd(',');
                this.sql += ")";
                i++;
            }
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            return command.ExecuteNonQuery();
            //return 1;
        }
        /*
         * delete sql statement is delete from table where ...
         * where condition is maybe one or more conditions
         * condition's structure while future 
         */
        public int Delete(string table, string condition)
        {
            this.sql = "delete from " + table + " where " + condition;
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            return command.ExecuteNonQuery();
        }
        /*
         * Update sql statment is update table set params1 = value1,params2 = value2 ...where condition
         */
        public int Update(string table, Dictionary<string, string> keyValues, string condition)
        {
            this.sql = "update " + table + " set ";
            foreach (var d in keyValues)
            {
                this.sql += d.Key + " = '" + d.Value + "',";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += " where " + condition;
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            return command.ExecuteNonQuery();
            //return 1;
        }

        public DataSet Select(List<string> items, string table, string condition)
        {
            DataSet ds = new DataSet();
            this.sql = "select ";
            foreach (var item in items)
            {
                this.sql += item + ",";
            }
            this.sql = this.sql.TrimEnd(',');
            this.sql += " from " + table + " where " + condition;
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            OleDbDataAdapter da = new OleDbDataAdapter(this.sql, this.Conn);
            da.Fill(ds, table);
            return ds;
        }

        public DataSet Select(string table, string condition = null)
        {
            DataSet ds = new DataSet();
            this.sql = "select * from " + table;
            if (condition != null)
            {
                this.sql += " where " + condition;
            }
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            OleDbDataAdapter da = new OleDbDataAdapter(this.sql, this.Conn);
            da.Fill(ds, table);
            return ds;
        }

        public void ExecuteSql(string sql)
        {
            this.sql = sql;
            OleDbCommand command = new OleDbCommand(this.sql, this.Conn);
            command.ExecuteNonQuery();
        }
    }
}

