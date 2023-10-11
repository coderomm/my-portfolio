using Portfolio.Controllers;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbCoderOmEntities db = new DbCoderOmEntities();

        // Home ( Index )
        public ActionResult Dashboard()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            ViewBag.ProjectCount = db.ProjectsTbls.Count();
            return View();
        }

        // About
        public ActionResult AboutDetails()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");

            }
            return View(db.AboutDetailsTbls.SingleOrDefault());
        }

        [HttpPost]
        public ActionResult AboutDetails(AboutDetailsTbl model, HttpPostedFileBase Logo, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Resume)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }

            var existingData = db.AboutDetailsTbls.Find(model.Id);
            model.Logo = existingData.Logo;
            model.Image1 = existingData.Image1;
            model.Image2 = existingData.Image2;
            model.Resume = existingData.Resume;

            if (existingData == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                if (Logo != null && Logo.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingData.Logo))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/About/"), existingData.Logo);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    model.Logo = SaveAndProcessImage(Logo, "logo");
                }

                if (Image1 != null && Image1.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingData.Image1))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/About/"), existingData.Image1);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    model.Image1 = SaveAndProcessImage(Image1, "Image1");
                }

                if (Image2 != null && Image2.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingData.Image2))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/About/"), existingData.Image2);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    model.Image2 = SaveAndProcessImage(Image2, "Image2");
                }

                if (Resume != null && Resume.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingData.Resume))
                    {
                        string oldResumePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/About/"), existingData.Resume);
                        if (System.IO.File.Exists(oldResumePath))
                        {
                            System.IO.File.Delete(oldResumePath);
                        }
                    }
                    string newResumeFileName = "Om Sharma Resume" + Path.GetExtension(Resume.FileName);
                    string newResumePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Documents/"), newResumeFileName);

                    Resume.SaveAs(newResumePath);
                    model.Resume = newResumeFileName;
                }
                db.Entry(existingData).CurrentValues.SetValues(model);
                db.SaveChanges();
            }
            return RedirectToAction("AboutDetails");
        }

        private string SaveAndProcessImage(HttpPostedFileBase file, string fileNamePrefix)
        {
            string fileName = fileNamePrefix + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/About/"), fileName);
            file.SaveAs(filePath);
            return fileName;
        }

        // Projects
        public ActionResult AddProject()
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }

            return View(db.ProjectsTbls.ToList());
        }

        [HttpPost]
        public ActionResult AddProject(ProjectsTbl model, HttpPostedFileBase Image1, HttpPostedFileBase Image2)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                if (Image1 != null && Image1.ContentLength > 0)
                {
                    int a = db.ProjectsTbls.Any() ? db.ProjectsTbls.Max(x => x.Id) + 1 : 1;
                    string fileName = a + Path.GetExtension(Image1.FileName);
                    model.Image1 = SaveAndProcessProjectImage(Image1, fileName);
                }
                if (Image2 != null && Image2.ContentLength > 0)
                {
                    int a = db.ProjectsTbls.Any() ? db.ProjectsTbls.Max(x => x.Id) + 1 : 1;
                    string fileName = "b_" + a + Path.GetExtension(Image2.FileName);
                    model.Image2 = SaveAndProcessProjectImage(Image2, fileName);
                }
                
                model.rts = DateTime.Now;
                model.status = true;
                db.ProjectsTbls.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("AddProject");
        }

        public ActionResult EditProject(int id)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            var model = db.ProjectsTbls.Find(id);

            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProject(ProjectsTbl model, HttpPostedFileBase Image1, HttpPostedFileBase Image2)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }

            var existingProduct = db.ProjectsTbls.Find(model.Id);
            model.Image1 = existingProduct.Image1;
            model.Image2 = existingProduct.Image2;
            if (existingProduct == null)
            {
                return HttpNotFound();
            }
            
            if (ModelState.IsValid)
            {
                if (Image1 != null && Image1.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingProduct.Image1))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/Projects/"), existingProduct.Image1);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string fileName = model.Id.ToString();
                    model.Image1 = SaveAndProcessProjectImage(Image1, fileName);
                }
                if (Image2 != null && Image2.ContentLength > 0)
                {
                    if (!string.IsNullOrEmpty(existingProduct.Image2))
                    {
                        string oldImagePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/Projects/"), existingProduct.Image2);
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    string fileName = "b_" + model.Id;
                    model.Image2 = SaveAndProcessProjectImage(Image2, fileName);
                }

                model.rts = DateTime.Now;
                model.status = true;
                db.Entry(existingProduct).CurrentValues.SetValues(model);
                db.SaveChanges();
            }
            
            return RedirectToAction("AddProject");
        }

        public ActionResult ChangeToActive(int id)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            ProjectsTbl Project = db.ProjectsTbls.Find(id);
            Project.status = true;
            db.SaveChanges();
            return RedirectToAction("AddProject");
        }

        public ActionResult ChangeToDeactive(int id)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            ProjectsTbl Project = db.ProjectsTbls.Find(id);
            Project.status = false;
            db.SaveChanges();
            return RedirectToAction("AddProject");
        }

        public ActionResult DeleteProject(int id)
        {
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login");
            }
            db.ProjectsTbls.Remove(db.ProjectsTbls.Find(id));
            db.SaveChanges();
            return RedirectToAction("AddProject");
        }

        private string SaveAndProcessProjectImage(HttpPostedFileBase file, string fileNamePrefix)
        {
            string fileName = fileNamePrefix + Path.GetExtension(file.FileName);
            string filePath = Path.Combine(Server.MapPath("~/Content/projectAssets/Images/Projects/"), fileName);
            file.SaveAs(filePath);
            return fileName;
        }

        [Route("encrypted/hacked/login", Name = "Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("encrypted/hacked/login", Name = "LoginPost")]
        public ActionResult LoginPost(AdminTbl login)
        {
            if (ModelState.IsValid)
            {
                var model = db.AdminTbls.Any(m => m.uName == login.uName && m.uPassword == login.uPassword);
                if (model)
                {
                    var loginInfo = db.AdminTbls.FirstOrDefault(x => x.uName == login.uName && x.uPassword == login.uPassword);

                    Session["username"] = loginInfo.uName;
                    Session["userid"] = loginInfo.Id;

                    return Json(new { success = true }); // Return JSON response indicating successful login
                }
                else
                {
                    return Json(new { success = false }); // Return JSON response indicating failed login
                }
            }

            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}