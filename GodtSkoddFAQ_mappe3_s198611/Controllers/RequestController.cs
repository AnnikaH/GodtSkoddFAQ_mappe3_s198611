﻿using System;
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

        // GET api/Request/5
        public HttpResponseMessage Get(int id)
        {
            Request oneRequest = faqDb.GetRequest(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(oneRequest);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/Request
        public HttpResponseMessage Post(Request request)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.CreateRequest(request);

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
                Content = new StringContent("Kunne ikke sette inn denne forespørselen i databasen")
            };
        }

        // PUT api/Request/5
        public HttpResponseMessage Put(int id, [FromBody]Request request)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.UpdateRequest(id, request);

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
                Content = new StringContent("Kunne ikke endre forespørselen i databasen")
            };
        }

        // DELETE api/Request/5
        public HttpResponseMessage Delete(int id)
        {
            bool OK = faqDb.DeleteRequest(id);

            if (!OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke slette forespørselen fra databasen")
                };
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}