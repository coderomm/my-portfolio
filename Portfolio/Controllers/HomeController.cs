using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : BaseController
    {
        private readonly DbCoderOmEntities db = new DbCoderOmEntities();

        public ActionResult Index()
        {
            ViewModel model = new ViewModel
            {
                AboutDetailsTbl = db.AboutDetailsTbls.SingleOrDefault(),
                ProjectsTbl = db.ProjectsTbls.ToList()
            };
            return View(model);
        }

        [Route("about", Name = "About")]
        public ActionResult About()
        {
            ViewModel model = new ViewModel
            {
                AboutDetailsTbl = db.AboutDetailsTbls.SingleOrDefault(),
                ProjectsTbl = db.ProjectsTbls.ToList()
            };
            return View(model);
        }

        [Route("all-work", Name = "Projects")]
        public ActionResult Projects()
        {
            return View(db.ProjectsTbls.ToList());
        }

        [Route("all-work/{projectname}", Name = "ProjectDetails")]
        public ActionResult ProjectDetails(string projectname)
        {
            string actualprojectname = projectname.Replace("-", " ");
            if (actualprojectname == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = db.ProjectsTbls.Where(x => x.Title == actualprojectname).SingleOrDefault();
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [Route("contact", Name = "Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEnquiry(FormCollection enquiry)
        {
            // Read SMTP section from Web.Config.
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

            using (MailMessage mm = new MailMessage(smtpSection.From, "mail.coderom@gmail.com"))
            {
                mm.Subject = "Enquiry To Coder Om";
                mm.Body =
                    "Client Name : " + enquiry["name"] + "<br />" +
                    "Client Email : " + enquiry["email"] + "<br />" +
                    "Client Enquiry Message : " + enquiry["message"];
                mm.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = smtpSection.Network.Host;
                    smtp.EnableSsl = smtpSection.Network.EnableSsl;
                    NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCred;
                    smtp.Port = smtpSection.Network.Port;
                    smtp.Send(mm);
                }
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult DownloadResume()
        {
            // Fetch the resume file name from the database
            var resumeFileName = db.AboutDetailsTbls.FirstOrDefault()?.Resume;

            if (resumeFileName != null)
            {
                // Construct the file path
                string filePath = Server.MapPath("~/Content/projectAssets/Documents/" + resumeFileName);

                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Return the file for download
                    return File(filePath, "application/pdf", resumeFileName);
                }
            }

            // If the file doesn't exist or there's an issue, return a 404 Not Found
            return HttpNotFound();
        }

    }
}