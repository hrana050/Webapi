using System;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using System.Configuration;

namespace Dbconnection
{
   public class connection
    {
        public SqlConnection con;

        public void createconncetion()
        {
            if(con==null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["myConection"].ConnectionString);    
            }
        }
        public void openconnection()
        {
            if(con==null)
            {
                createconncetion();
            }
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void closdconnection()
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
