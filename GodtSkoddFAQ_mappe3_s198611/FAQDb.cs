using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using GodtSkoddFAQ_mappe3_s198611.Models;
using System.IO;

namespace GodtSkoddFAQ_mappe3_s198611
{
    public class FAQDb
    {
        FAQContext db = new FAQContext();
        String errorLogPath = AppDomain.CurrentDomain.BaseDirectory + "Logs";

        // ---------------------------- Log -------------------------------

        public void writeToLog(Exception e)
        {
            String errorMessage = e.Message.ToString() + " in " + e.TargetSite.ToString() + e.StackTrace.ToString();

            String day = DateTime.Now.Day.ToString();
            String month = DateTime.Now.Month.ToString();
            String year = DateTime.Now.Year.ToString();
            String today = "" + day + "." + month + "." + year;
            String nowHour = DateTime.Now.Hour.ToString();
            String nowMinute = DateTime.Now.Minute.ToString();
            String todayFile = @"\Log " + today + ".txt";

            if (File.Exists(errorLogPath + todayFile))
            {
                using (StreamWriter outputFile = new StreamWriter("" + errorLogPath + todayFile, true))
                {
                    outputFile.WriteLine("[" + nowHour + ":" + nowMinute + "] " + errorMessage);
                }
            }
            else
            {
                if (!Directory.Exists(errorLogPath))
                {
                    Directory.CreateDirectory(errorLogPath);
                }
                using (StreamWriter outputFile = new StreamWriter("" + errorLogPath + todayFile))
                {
                    outputFile.WriteLine("[" + nowHour + ":" + nowMinute + "] " + errorMessage);
                }
            }
        }

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
            var newCategory = new Categories
            {
                Name = category.name
            };
            
            try
            {
                // save category
                db.Categories.Add(newCategory);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateCategory(int id, Category category)
        {
            Categories foundCategory = db.Categories.FirstOrDefault(c => c.ID == id);

            if (foundCategory == null)
                return false;

            foundCategory.Name = category.name;
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
            var newFAQ = new FAQs
            {
                Question = faq.question,
                Answer = faq.answer,
                CategoryId = faq.categoryId
            };

            Categories foundCategory = db.Categories.Find(faq.categoryId);

            if (foundCategory != null)
                newFAQ.Category = foundCategory;
            else
                return false;

            try
            {
                // save FAQ
                db.FAQs.Add(newFAQ);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateFAQ(int id, FAQ faq)
        {
            FAQs foundFAQ = db.FAQs.FirstOrDefault(f => f.ID == id);

            if (foundFAQ == null)
                return false;

            foundFAQ.Question = faq.question;
            foundFAQ.Answer = faq.answer;
            foundFAQ.CategoryId = faq.categoryId;
            foundFAQ.Category = db.Categories.Find(faq.categoryId);
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
            var newRequest = new Requests
            {
                SenderFirstName = request.senderFirstName,
                SenderLastName = request.senderLastName,
                SenderEmail = request.senderEmail,
                Subject = request.subject,
                Question = request.question,
                Date = request.date,
                Answered = request.answered
            };

            try
            {
                // save request
                db.Requests.Add(newRequest);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateRequest(int id, Request request)
        {
            Requests foundRequest = db.Requests.FirstOrDefault(r => r.ID == id);

            if (foundRequest == null)
                return false;

            foundRequest.SenderFirstName = request.senderFirstName;
            foundRequest.SenderLastName = request.senderLastName;
            foundRequest.SenderEmail = request.senderEmail;
            foundRequest.Subject = request.subject;
            foundRequest.Question = request.question;
            foundRequest.Date = request.date;
            foundRequest.Answered = request.answered;
            
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
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
    }
}