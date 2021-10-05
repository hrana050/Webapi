using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dbconnection;
using View_Model;

namespace Services
{
   public class stationserice
    {
        Sqlcommand Sqlcommandobj = new Sqlcommand();
        public IList<course> FetchProductDetails()
        {
            return Sqlcommandobj.fetchstatewisecity();
        }
        public string InsertEnquiry(vmstudentenquiry vmstudentenquiryobj)
        {
            return Sqlcommandobj.insertenquiry(vmstudentenquiryobj);
        }
    }
}
