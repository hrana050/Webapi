using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Services.NPFop;
using View_Model;
namespace Testapi.Controllers
{

    public class NPF_EnquiryController : Controller
    {
        npfoperation npfoperationobj;

        public NPF_EnquiryController()
        {
            npfoperationobj = new npfoperation();
        }
        public ActionResult create()
        {
            return View();
        }
        // GET: NPF_Enquiry
        [HttpPost]
        public ActionResult create(vmenquiry vmenquiryobj)
        {
            vmenquiryobj.createdon = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TempData["Status"] = npfoperationobj.npf_enquiry(vmenquiryobj);
            return RedirectToAction("NPF_Enquiry", "create");
        }
    }
}