using Blog.Areas.Admin.Models.ResultModel;
using Blog.Common;
using Blog.Entity;
using Blog.Entity.Model;
using Blog.Repository;
using Blog.Web.Areas.Admin.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        BlogContext database = Tools.GetConnection();

        UserRepository userRep = new UserRepository();
        UserRoleRepository URRep = new UserRoleRepository();

        InstanceResults<User> result = new InstanceResults<User>();

        // GET: Admin/Member
        public ActionResult List(string m, int? id)
        {
            result.resultList = userRep.List();

            if (m != null)
            {
                ViewBag.Message = String.Format("{0}th items deletion was {1}", id, m);
            }

            else
            {
                ViewBag.Message = "";
            }

            return View(result.resultList.ProcessResult);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserUserRoleViewModel uur = new UserUserRoleViewModel();

            List<SelectListItem> userRoleList = new List<SelectListItem>();

            foreach (UserRole item in URRep.List().ProcessResult)
            {
                userRoleList.Add(new SelectListItem { Value = item.UserRoleID.ToString(), Text = item.Rolename });

            }

            //ViewBag.PaymentTypes = new SelectList(, "PaymentId", "PaymentName");


            uur.User = null;
            uur.UserRolesList = userRoleList;


            return View(uur);

        }

        [HttpPost]

        public ActionResult AddUser(UserUserRoleViewModel model, HttpPostedFileBase photo)
        {
            //model.RoleId = 1;
            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-","") + ".jpg";

                string path = Server.MapPath("~/Upload/" + photoName);

                photo.SaveAs(path);



            }

            model.User.Photo = photoName;

            result.resultInt = userRep.Insert(model.User);

            if (result.resultInt.IsSucceeded)
            {
                return RedirectToAction("List");
            }
            else
                return View(model);


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserUserRoleViewModel uur = new UserUserRoleViewModel();

            List<SelectListItem> userRoleList = new List<SelectListItem>();

            foreach (UserRole item in URRep.List().ProcessResult)
            {
                userRoleList.Add(new SelectListItem { Value = item.UserRoleID.ToString(), Text = item.Rolename });

            }
            //SelectList userRoles = new SelectList(database.UserRoles.ToList(), "UserRoleID", "Rolename");

            //ViewBag.userRoles = userRoles;


            uur.User = userRep.GetObjectByID(id).ProcessResult;
            uur.UserRolesList = userRoleList;


            return View(uur);
        }

        [HttpPost]

        public ActionResult Edit(UserUserRoleViewModel model, HttpPostedFileBase photo)
        {

            List<SelectListItem> userRoleList = new List<SelectListItem>();

            foreach (UserRole item in URRep.List().ProcessResult)
            {
                userRoleList.Add(new SelectListItem { Value = item.UserRoleID.ToString(), Text = item.Rolename });

            }

            
            string photoName = "";

            if (photo.ContentLength > 0 && photo!= null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";

                string path = Server.MapPath("~/Upload/") + photoName;

                photo.SaveAs(path);

            }




            model.User.Photo = photoName;
            model.UserRolesList = userRoleList;

            result.resultInt = userRep.Update(model.User);




            if (result.resultInt.IsSucceeded)
            {
                
                    ViewBag.status = "info";
                    ViewBag.result = "Update succesful..";
                

                return View(model);
            }
            else
            { 
            ViewBag.status = "danger";
            ViewBag.result = "Update of the user not succesful";
                return View(model);

            }
        }

        public ActionResult Delete(int id)
        {
            result.resultInt = userRep.Delete(id);

            return RedirectToAction("List", new { @m = result.resultInt.UserMessage, @id = id });
        }



    }

}