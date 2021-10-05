using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using View_Model;

namespace Services.NPFop
{
    public class npfoperation
    {
        demoEntities demoEntitiesobj;
        public npfoperation()
        {
            demoEntitiesobj = new demoEntities();
        }
        public int npf_enquiry(vmenquiry vmenquiryobj)
        {
            int result;
            NPF_Enquiry NPF_Enquiryobj = new NPF_Enquiry();
            NPF_Enquiryobj.EnqNo = vmenquiryobj.Enqno;
            NPF_Enquiryobj.Name = vmenquiryobj.name;
            NPF_Enquiryobj.MobileNo = vmenquiryobj.mobileno;
            NPF_Enquiryobj.EmailId = vmenquiryobj.emailid;
            NPF_Enquiryobj.CourseName = vmenquiryobj.coursename;
            NPF_Enquiryobj.CreatedDate = vmenquiryobj.createdon;
            NPF_Enquiryobj.IsActive = vmenquiryobj.status;
            NPF_Enquiry tmpNPF_Enquiryobj = demoEntitiesobj.NPF_Enquiry.Add(NPF_Enquiryobj);
            result=demoEntitiesobj.SaveChanges();
            return result; 
        }
    }
}
