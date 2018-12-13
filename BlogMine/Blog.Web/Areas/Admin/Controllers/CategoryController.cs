using Blog.Areas.Admin.Models.ResultModel;
using Blog.Entity.Model;
using Blog.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        CategoryRepository catRep = new CategoryRepository();

        InstanceResults<Category> result = new InstanceResults<Category>();

        // GET: Admin/Category
        public ActionResult List(string message)

        {

            result.resultList = catRep.List();
            ViewBag.Message = message;


            return View(result.resultList.ProcessResult);
        }

        [HttpGet]

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCategory(Category model, HttpPostedFileBase photo)
        {
            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";

                string path = Server.MapPath("~/Upload/" + photoName);

                photo.SaveAs(path);
            }

            model.CategoryPhoto = photoName;

            result.resultInt = catRep.Insert(model);

            if (result.resultInt.IsSucceeded)
            {
                ViewBag.status = "success";
                ViewBag.result = "Addition succesful..";
            }

            else
            {
                ViewBag.status = "danger";
                ViewBag.result = "Addition of the category not succesful";
            }

            return View();
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            result.resultType = catRep.GetObjectByID(id);

            return View(result.resultType.ProcessResult);
        }

        [HttpPost]

        public ActionResult Edit(Category model, HttpPostedFileBase photo)
        {
            string photoName = model.CategoryPhoto;

            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    string ext = Path.GetExtension(photo.FileName);
                    photoName = Guid.NewGuid().ToString().Replace("-", "");

                    if (ext == ".jpg" || ext == ".png" || ext == ".bmp")
                    {
                        photoName += ext;
                    }


                    else
                    {
                        ViewBag.Message = "Please upload a photo in .jpg, .png , or .bmp formats";
                    }

                    string path = Server.MapPath("~/Upload/" + photoName);
                    photo.SaveAs(path);

                }

            }

            model.CategoryPhoto = photoName;

            result.resultInt = catRep.Update(model);

            if (result.resultInt.IsSucceeded)
            {
                ViewBag.status = "success";
                ViewBag.result = "Update succesful..";
            }

            else
            {
                ViewBag.status = "danger";
                ViewBag.result = "Update of the category not succesful";
            }


            return View();
        }


        public ActionResult Delete(int id)
        {
            result.resultInt = catRep.Delete(id);

            return RedirectToAction("List", new { @mesaj = result.resultInt.UserMessage });
        }
    }
}