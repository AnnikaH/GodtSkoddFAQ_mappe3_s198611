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
    public class FAQController : ApiController
    {
        FAQDb faqDb = new FAQDb();
        
        // GET api/FAQ
        public HttpResponseMessage Get()
        {
            List<FAQ> allFAQs = faqDb.GetAllFAQs();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(allFAQs);

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

        // GET api/FAQ/5
        public HttpResponseMessage Get(int id)
        {
            FAQ oneFAQ = faqDb.GetFAQ(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(oneFAQ);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/FAQ
        public HttpResponseMessage Post(FAQ faq)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.CreateFAQ(faq);

                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke sette inn dette spørsmålet i databasen")
            };
        }

        // PUT api/FAQ/5
        public HttpResponseMessage Put(int id, [FromBody]FAQ faq)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.UpdateFAQ(id, faq);

                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };
                }
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke endre spørsmålet i databasen")
            };
        }

        // DELETE api/FAQ/5
        public HttpResponseMessage Delete(int id)
        {
            bool OK = faqDb.DeleteFAQ(id);

            if (!OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke slette spørsmålet fra databasen")
                };
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}