﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using GodtSkoddFAQ_mappe3_s198611.Models;

namespace GodtSkoddFAQ_mappe3_s198611
{
    // TODO: Lagre og Endre (se helt nederst her + GodtSkoddProsjekt på GitHub)

    public class FAQDb
    {
        FAQContext db = new FAQContext();
        
        // -------------------------- Category ----------------------------

        public List<Category> GetAllCategories()
        {
            try
            {
                List<Category> allCategories = db.Categories.Select(c => new Category()
                {
                    id = c.ID,
                    name = c.Name
                }).ToList();

                return allCategories;
            }
            catch (Exception)
            {
                List<Category> allCategories = new List<Category>();
                return allCategories;
            }
        }

        public Category GetCategory(int id)
        {
            try
            {
                Categories oneDbCategory = db.Categories.Find(id);

                if (oneDbCategory == null)
                    return null;

                var oneCategory = new Category()
                {
                    id = oneDbCategory.ID,
                    name = oneDbCategory.Name
                };

                return oneCategory;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateCategory(Category category)
        {
            // TODO: Finish

            return false;
        }

        public bool UpdateCategory(int id, Category category)
        {
            // TODO: Finish

            return false;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                Categories foundCategory = db.Categories.Find(id);

                if (foundCategory == null)
                    return false;

                db.Categories.Remove(foundCategory);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // ----------------------------- FAQ ------------------------------

        public List<FAQ> GetAllFAQs()
        {
            try
            {
                List<FAQ> allFAQs = db.FAQs.Select(f => new FAQ()
                {
                    id = f.ID,
                    question = f.Question,
                    answer = f.Answer,
                    categoryId = f.CategoryId
                }).ToList();

                return allFAQs;
            }
            catch (Exception)
            {
                List<FAQ> allFAQs = new List<FAQ>();
                return allFAQs;
            }
        }

        public FAQ GetFAQ(int id)
        {
            try
            {
                FAQs oneDbFAQ = db.FAQs.Find(id);

                if (oneDbFAQ == null)
                    return null;

                var oneFAQ = new FAQ()
                {
                    id = oneDbFAQ.ID,
                    question = oneDbFAQ.Question,
                    answer = oneDbFAQ.Answer,
                    categoryId = oneDbFAQ.CategoryId
                };

                return oneFAQ;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<FAQ> GetFAQsFromCategory(int categoryId)
        {
            try
            {
                var dbFAQs = db.FAQs.ToList();
                List<FAQ> FAQs = new List<FAQ>();

                foreach (var faq in dbFAQs)
                {
                    if (faq.CategoryId == categoryId)
                    {
                        var oneFAQ = new FAQ();
                        oneFAQ.id = faq.ID;
                        oneFAQ.question = faq.Question;
                        oneFAQ.answer = faq.Answer;
                        oneFAQ.categoryId = faq.CategoryId;

                        FAQs.Add(oneFAQ);
                    }
                }

                return FAQs;
            }
            catch (Exception)
            {
                List<FAQ> FAQs = new List<FAQ>();
                return FAQs;
            }
        }

        public bool CreateFAQ(FAQ faq)
        {
            // TODO: Finish

            return false;
        }

        public bool UpdateFAQ(int id, FAQ faq)
        {
            // TODO: Finish

            return false;
        }

        public bool DeleteFAQ(int id)
        {
            try
            {
                FAQs foundFAQ = db.FAQs.Find(id);

                if (foundFAQ == null)
                    return false;

                db.FAQs.Remove(foundFAQ);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        // ---------------------------- Request --------------------------

        public List<Request> GetAllRequests()
        {
            try
            {
                List<Request> allRequests = db.Requests.Select(r => new Request()
                {
                    id = r.ID,
                    senderFirstName = r.SenderFirstName,
                    senderLastName = r.SenderLastName,
                    senderEmail = r.SenderEmail,
                    subject = r.Subject,
                    question = r.Question,
                    date = r.Date,
                    answered = r.Answered
                }).ToList();

                return allRequests;
            }
            catch (Exception)
            {
                List<Request> allRequests = new List<Request>();
                return allRequests;
            }
        }

        public Request GetRequest(int id)
        {
            try
            {
                Requests oneDbRequest = db.Requests.Find(id);

                if (oneDbRequest == null)
                    return null;

                var oneRequest = new Request()
                {
                    id = oneDbRequest.ID,
                    senderFirstName = oneDbRequest.SenderFirstName,
                    senderLastName = oneDbRequest.SenderLastName,
                    senderEmail = oneDbRequest.SenderEmail,
                    subject = oneDbRequest.Subject,
                    question = oneDbRequest.Question,
                    date = oneDbRequest.Date,
                    answered = oneDbRequest.Answered
                };

                return oneRequest;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateRequest(Request request)
        {
            // TODO: Finish

            return false;
        }

        public bool UpdateRequest(int id, Request request)
        {
            // TODO: Finish

            return false;
        }

        public bool DeleteRequest(int id)
        {
            try
            {
                Requests foundRequest = db.Requests.Find(id);
                
                if (foundRequest == null)
                    return false;

                db.Requests.Remove(foundRequest);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /*
        public bool lagreEnKunde(kunde innKunde)
        {
            var nyKunde = new Kunde
            {
                fornavn = innKunde.fornavn,
                etternavn = innKunde.etternavn,
                adresse = innKunde.adresse,
                postnr = innKunde.postnr
            };

            Poststed funnetPoststed = db.Poststeder.Find(innKunde.postnr);
            if (funnetPoststed == null)
            {
                // lag poststedet
                var nyttPoststed = new Poststed
                {
                    postnr = innKunde.postnr,
                    poststed = innKunde.poststed
                };
                // legg det inn i den nye kunden
                nyKunde.poststed = nyttPoststed;

            }
            try
            {
                // lagre kunden
                db.Kunder.Add(nyKunde);
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
        
        public bool endreEnKunde(int id, kunde innKunde)
        {
            // finn kunden
            Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.id == id);
            if (funnetKunde == null)
            {
                return false;
            }
            // legg inn ny verdier i denne fra innKunde
            funnetKunde.fornavn = innKunde.fornavn;
            funnetKunde.etternavn = innKunde.etternavn;
            funnetKunde.adresse = innKunde.adresse;
            funnetKunde.postnr = innKunde.postnr;

            // finn ut om postnummer finnes fra før
            Poststed funnetPoststed = db.Poststeder.Find(innKunde.postnr);
            if (funnetPoststed == null)
            {
                // lag poststedet
                var nyttPoststed = new Poststed
                {
                    postnr = innKunde.postnr,
                    poststed = innKunde.poststed
                };
                // legg det inn i kunden
                funnetKunde.poststed = nyttPoststed;
            }
            try
            {
                // lagre kunden
                db.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }*/
    }
}