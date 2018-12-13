using Blog.Areas.Admin.Models.ResultModel;
using Blog.Entity.Model;
using Blog.Repository;
using Blog.Web.Areas.Admin.Models;
using Blog.Web.Areas.Admin.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        InstanceResults<Post> result = new InstanceResults<Post>();

        PostRepository postRep = new PostRepository();
        CategoryRepository catRep = new CategoryRepository();
        UserRepository userRep = new UserRepository();

        public ActionResult List()
        {
            result.resultList = postRep.List();


            return View(result.resultList.ProcessResult);
        }


        [HttpGet]

        public ActionResult AddPost()
        {
            PostViewModel pwm = new PostViewModel();

            List<SelectListItem> categoryList = new List<SelectListItem>();
            List<SelectListItem> userList = new List<SelectListItem>();

            foreach (Category item in catRep.List().ProcessResult)
            {
                categoryList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });

            }

            foreach (User item in userRep.List().ProcessResult)
            {
                userList.Add(new SelectListItem { Value = item.UserID.ToString(), Text = item.Username });

            }

            pwm.UsersList = userList;
            pwm.CategoryList = categoryList;
            pwm.Post = null;




            return View(pwm);
        }

        [HttpPost]
        public ActionResult AddPost(PostViewModel model, HttpPostedFileBase photo)
        {
            //a  variable to pass to upload folder.
            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-","") + ".jpg";

                string path = Server.MapPath("~/Upload/" + photoName);

                photo.SaveAs(path);



            }
            ExcerptConstructor cons = new ExcerptConstructor();


            model.Post.PostExcerpt = cons.ReturnExcerpt(model.Post.PostContent);
            model.Post.Photo = photoName;
            model.Post.PostDate = DateTime.Now;
            model.Post.IsRead = 0;

            result.resultInt = postRep.Insert(model.Post);

            if (result.resultInt.IsSucceeded)
            {

                return RedirectToAction("List");
            }
            else
                return View(model);



        }

        public ActionResult Edit(int id)
        {
            PostViewModel pwm = new PostViewModel();

            List<SelectListItem> CatList = new List<SelectListItem>();
            List<SelectListItem> UserList = new List<SelectListItem>();

            foreach (Category item in catRep.List().ProcessResult)
            {
                CatList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }

            foreach (User item in userRep.List().ProcessResult)
            {
                UserList.Add(new SelectListItem { Value = item.UserID.ToString(), Text = item.Username });
            }

            pwm.CategoryList = CatList;
            pwm.UsersList = UserList;
            pwm.Post = postRep.GetObjectByID(id).ProcessResult;

            return View(pwm);
        }


        [HttpPost]
        public ActionResult Edit(PostViewModel model, HttpPostedFileBase photo)
        {
            string photoName = model.Post.Photo;

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


            List<SelectListItem> CatList = new List<SelectListItem>();
            List<SelectListItem> UserList = new List<SelectListItem>();

            foreach (Category item in catRep.List().ProcessResult)
            {
                CatList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }

            foreach (User item in userRep.List().ProcessResult)
            {
                UserList.Add(new SelectListItem { Value = item.UserID.ToString(), Text = item.Username });
            }

            ExcerptConstructor cons = new ExcerptConstructor();

            model.UsersList = UserList;
            model.CategoryList = CatList;
            model.Post.Photo = photoName;
            model.Post.PostExcerpt = cons.ReturnExcerpt(model.Post.PostContent);
            model.Post.PostDate = DateTime.Now;
            model.Post.IsRead = 0;


            result.resultInt = postRep.Update(model.Post);

            if (result.resultInt.ProcessResult > 0)
            {
                if (result.resultInt.IsSucceeded)
                {
                    ViewBag.status = "info";
                    ViewBag.result = "Update succesful..";
                }

                else
                {
                    ViewBag.status = "danger";
                    ViewBag.result = "Updaet of the post is not succesful";
                }
                return View(model);
            }

            else

                return View(model);
        }

        public ActionResult Delete(int id)
        {
            result.resultInt = postRep.Delete(id);


            return RedirectToAction("List", new { @mesaj = result.resultInt.UserMessage,result = ViewBag.result });
        }
    }
}