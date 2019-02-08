using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Modules
{
    public class Database
    {
        private MySqlConnection conn;

        private MySqlConnection GetConnection()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = string.Format("server={0};user={1};password={2};database={3};port={4}", "gdc3.gudi.kr", "root", "1234", "gdc", "22002");
            try
            {
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
            
        }
        public void connclose()
        {
            conn.Close();
        }
        public MySqlDataReader GetReader(string sql)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                GetConnection();
                comm.CommandText = sql;
                comm.Connection = conn;
                MySqlDataReader mdr = comm.ExecuteReader();
                return mdr;
            }
            catch
            {
                return null;
            }
        }
    }
  
}
