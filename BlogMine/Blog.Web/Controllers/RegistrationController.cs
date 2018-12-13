using Blog.Common;
using Blog.Entity;
using Blog.Entity.Model;
using Blog.Repository;
using Blog.Web.Models.ResultsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.Web.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        private static BlogContext database = Tools.GetConnection();

        UserRepository userRepository = new UserRepository();
        PostRepository postRepository = new PostRepository();
        TagRepository tagRepository = new TagRepository();
        CommentRepository commentRepository = new CommentRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        InstanceResult<User> result = new InstanceResult<User>();


        //MembershipUser currentUser = Membership.GetUser()

        // GET: Registration
        public ActionResult Login()
        {
            if (Session["username"]!=null)
            {
                return RedirectToAction("Index", "Home");

            }

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {

            using (BlogContext database = new BlogContext())
            {

                var user = database.Users.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (user != null)
                {
                    Session["userID"] = user.UserID;
                    Session["username"] = user.Username;
                    Session["password"] = user.Password;

                    return RedirectToAction("Index", "Home", new { username = Session["username"] });

                }
                ViewBag.Message = "Email and/or password are invalid.";
            }

            ViewBag.Message = "Email and/or password are invalid.";
            return View();
        }

        public ActionResult LogOut()
        {
            Session["username"] = null;
            Session.Abandon();

            return RedirectToAction("Login");
        }



        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(User user)
        {

            user.UserRoleId = 3;
            user.Photo = null;

            result.resultInt = userRepository.Insert(user);

            if (result.resultInt.IsSucceeded)
            {
                return RedirectToAction("Login");
            }

            else

                return View(user);

        }


        public ActionResult MyProfile()
        {
            //Member member

            foreach (User item in userRepository.List().ProcessResult)
            {
                if (Session["username"].ToString() == item.Username)
                {



                    return View(item);

                }

            }

            return View();


        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(userRepository.GetObjectByID(id).ProcessResult);            //cannot display the values in database without it.

        }

        [HttpPost]

        public ActionResult Edit(User model, HttpPostedFileBase photo)
        {

            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";

                string path = Server.MapPath("~/Upload/") + photoName;

                photo.SaveAs(path);

            }

            model.Photo = photoName;


            result.resultInt = userRepository.Update(model);


            if (result.resultInt.IsSucceeded)
            {
                //if (model.Password != Session["password"].ToString() || model.Username != Session["username"].ToString())
                //{
                //    RedirectToAction("LogOut");

                //}


                return RedirectToAction("MyProfile", "Registration");
            }
            //return RedirectToAction("MyProfile," "Registration", model)
            // model parameter is unncessary here and displayed in the addressbar. Without it in functions properly.

            else
                return View();
        }

        //public ActionResult ReturnUserName(string username)
        //{
        //    Member currentMember = regMemRepo.GetMemberByUserNAme(username).ProcessResult;

        //    return View(currentMember);
        //}


        public ActionResult UserInfo(int id)

        {
            User userToView = userRepository.GetObjectByID(id).ProcessResult;



            return View(userToView);

        }


    }


}