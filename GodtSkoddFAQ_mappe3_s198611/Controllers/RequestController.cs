using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Data.Common;
using GodtSkoddFAQ_mappe3_s198611.Models;
using System.Text;

namespace GodtSkoddFAQ_mappe3_s198611.Controllers
{
    public class RequestController : ApiController
    {
        FAQDb faqDb = new FAQDb();

        // GET api/Request
        public HttpResponseMessage Get()
        {
            List<Request> allRequests = faqDb.GetAllRequests();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(allRequests);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };

            // alternativ til return-koden over - for å forklare dette bedre :

            //var respons = new HttpResponseMessage();
            //respons.Content = new StringContent(JsonString, Encoding.UTF8, "application/json");
            //respons.StatusCode = HttpStatusCode.OK;
            //return respons;
        }


    }
}
