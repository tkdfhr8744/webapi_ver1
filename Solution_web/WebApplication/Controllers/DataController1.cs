using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Modules;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    public class DataController1 : Controller
    {
        ArrayList list;
        // GET: api/<controller>
        [Route("api/select")]
        [HttpGet]
        public ArrayList select()
        {
            list = new ArrayList();

            Database db = new Database();
            MySqlDataReader mdr = db.GetReader("select * from Notice");

            while (mdr.Read())
            {
                Hashtable ht = new Hashtable();
                for(int i = 0; i < mdr.FieldCount; i++)
                {
                    ht.Add(mdr.GetName(i), mdr.GetValue(i));
                }
                list.Add(ht);
            }
            mdr.Close();
            db.connclose();
            return list;
        }
        
    }
}
