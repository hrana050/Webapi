using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using View_Model;

namespace Dbconnection
{
    public class Sqlcommand
    {
        connection connectionobj = new connection();
        SqlTransaction SqlTransactionobj = null;

        public IList<course> fetchstatewisecity()
        {
            DataSet result = null;
            List<course> listcity = new List<course>();
            try
            {
                connectionobj.openconnection();
                SqlTransactionobj = connectionobj.con.BeginTransaction();
                SqlParameter[] sqlparam = new SqlParameter[2];
                result = SqlHelper.ExecuteDataSet(SqlTransactionobj, CommandType.StoredProcedure, "usp_FetchCourse", sqlparam);
                SqlTransactionobj.Commit();
            }
            catch(Exception ex)
            {
                SqlTransactionobj.Rollback();
                throw ex;
            }
         finally
            {
                connectionobj.closdconnection();
            }
            if(result.Tables[0].Rows.Count>0)
            {
                for (int i = 0; i < result.Tables[0].Rows.Count; i++)
                {
                    course courceobj = new course();
                    courceobj.coursecode = Convert.ToString(result.Tables[0].Rows[i]["Course_Code"]);
                    courceobj.coursename = Convert.ToString(result.Tables[0].Rows[i]["Course_Name"]);
                    listcity.Add(courceobj);
                }
            }
            return listcity;
        }
        public string insertenquiry(vmstudentenquiry vmstudentenquiryobj)
        {
            string Bookingcode = null;
            try
            {
                connectionobj.openconnection();
                SqlTransactionobj = connectionobj.con.BeginTransaction();
                SqlParameter[] Param = new SqlParameter[13];
                Param[0] = new SqlParameter("@EnqNo", vmstudentenquiryobj.EnqNo);
                Param[1] = new SqlParameter("@Name", vmstudentenquiryobj.Name);
                Param[2] = new SqlParameter("@MobileNo", vmstudentenquiryobj.MobileNo);
                Param[3] = new SqlParameter("@EmailId", vmstudentenquiryobj.EmailId);
                Param[4] = new SqlParameter("@CourseName", vmstudentenquiryobj.CourseName);
                Param[5] = new SqlParameter("@Status", SqlDbType.Int);
                Param[5].Direction = ParameterDirection.Output;
                DataSet result = SqlHelper.ExecuteDataSet(SqlTransactionobj, CommandType.StoredProcedure, "NPF_InsertEnquiry", Param);
                //int  a= Convert.ToInt32(Param[5].Value);
                if (Convert.ToInt32(Param[5].Value) > 0)
                {
                    Bookingcode = Convert.ToString(Param[5].Value);

                    SqlTransactionobj.Commit();
                }
            }
            catch (Exception ex)
            {
                SqlTransactionobj.Rollback();
                throw ex;
            }
            finally
            {
                connectionobj.closdconnection();
            }
            return Bookingcode;
        }
    }
}
