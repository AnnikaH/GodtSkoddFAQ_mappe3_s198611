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
    public class CategoryController : ApiController
    {
        FAQDb faqDb = new FAQDb();

        // GET api/Category
        public HttpResponseMessage Get()
        {
            List<Category> allCategories = faqDb.GetAllCategories();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(allCategories);

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

        // GET api/Category/5
        public HttpResponseMessage Get(int id)
        {
            Category oneCategory = faqDb.GetCategory(id);

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(oneCategory);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        // POST api/Category
        public HttpResponseMessage Post(Category category)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.CreateCategory(category);

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
                Content = new StringContent("Kunne ikke sette inn denne kategorien i databasen")
            };
        }

        // PUT api/Category/5
        public HttpResponseMessage Put(int id, [FromBody]Category category)
        {
            if (ModelState.IsValid)
            {
                bool OK = faqDb.UpdateCategory(id, category);

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
                Content = new StringContent("Kunne ikke endre kategorien i databasen")
            };
        }

        // DELETE api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            bool OK = faqDb.DeleteCategory(id);

            if (!OK)
            {
                return new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("Kunne ikke slette kategorien fra databasen")
                };
            }

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}