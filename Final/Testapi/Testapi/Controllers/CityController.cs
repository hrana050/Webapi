using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Services;
using View_Model;
using Newtonsoft.Json.Linq;
namespace Testapi.Controllers
{
    public class CityController : ApiController
    {
        stationserice stationsericeobj;
        public CityController()
        {
            stationsericeobj = new stationserice();
        }
        // GET: City
        [HttpGet]
        [Route("api/City/Getcourse")]
        public async Task<IHttpActionResult> Getcourse()
        {
            Dictionary<string, object> Result = new Dictionary<string, object>();
            var httprequest = HttpContext.Current.Request;
            var task = Task.Run(() => stationsericeobj.FetchProductDetails());
            var result = await task;
            List<course> listProduct = result.ToList();
            if (listProduct.Count > 0)
            {
                Result.Add("data", listProduct);
                Result.Add("Result", "Success");
                Result.Add("ResponsePort", 1);
            }
            else
            {
                Result.Add("Result", "Failed");
                Result.Add("ResponsePort", 0);
            }
            return this.Json(new { JObjects = Result });
        }
        [HttpPost]
        [Route("api/City/insertEnquiry")]
        public IHttpActionResult insertEnquiry([FromBody] vmstudentenquiry objenqmodel)
        {
            Dictionary<string, object> Result = new Dictionary<string, object>();
            try
            {
                //JObject Tables = JObject.Parse(HttpContext.Current.Request.Params.Get("Tables"));
                //var httpRequest = HttpContext.Current.Request;
                //objTableBookingModel.Tables = GlobalService.ConvertJsonToDatatable(Tables);
                string BookingCode = stationsericeobj.InsertEnquiry(objenqmodel);
                if (BookingCode != null)
                {
                    // Result.Add("BookingCode", BookingCode);
                    Result.Add("Result", "Success");
                    Result.Add("ResponsePort", 1);
                }
                else
                {
                    Result.Add("data", "No Record found...!!!");
                    Result.Add("Result", "Success");
                    Result.Add("ResponsePort", 0);
                }
            }
            catch (Exception ex)
            {
                Result.Add("data", Convert.ToString(ex.Message));
                Result.Add("Result", "Failed");
                Result.Add("ResponsePort", 0);
            }
            return this.Json(new { JObjects = Result });
        }
    }
}