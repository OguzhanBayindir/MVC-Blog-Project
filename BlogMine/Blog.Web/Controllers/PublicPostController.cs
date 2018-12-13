using Blog.Entity.Model;
using Blog.Repository;
using Blog.Web.Models;
using Blog.Web.Models.ResultsModel;
using Blog.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Controllers
{
    public class PublicPostController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();
        UserRepository userRepository = new UserRepository();
        PostRepository postRepository = new PostRepository();
        InstanceResult<Post> result = new InstanceResult<Post>();

        // GET: PublicPost
        public ActionResult SinglePost(int id)
        {
            CommentRepository commentRepository = new CommentRepository();
            PostCommentViewModel model = new PostCommentViewModel();


            Post postToView = postRepository.GetObjectByID(id).ProcessResult;
            List<Comment> relatedComments = commentRepository.GetObjectByPostID(id).ProcessResult.ToList();

            model.Comments = relatedComments;
            postToView.IsRead += 1;
            postRepository.Update(postToView);

            model.Post = postToView;
            model.Comment = null;

           

            return View(model);
            
        }

        [ValidateInput(false)]
        [HttpGet]

        public ActionResult AddPost()
        {
            PostViewModel pwm = new PostViewModel();

            List<SelectListItem> categoryList = new List<SelectListItem>();
            User currentUser = new User();

            foreach (Category item in categoryRepository.List().ProcessResult)
            {
                categoryList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });

            }

            int userID = Convert.ToInt32(Session["userID"].ToString());

            currentUser = userRepository.GetObjectByID(userID).ProcessResult;
                
                

            pwm.User = currentUser;
            pwm.CategoryList = categoryList;
            pwm.Post = null;

            return View(pwm);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult AddPost(PostViewModel model, HttpPostedFileBase photo)
        {
            //a  variable to pass to upload folder.
            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";

                string path = Server.MapPath("~/Upload/" + photoName);

                photo.SaveAs(path);



            }
            ExcerptConstructor cons = new ExcerptConstructor();


            model.Post.PostExcerpt = cons.ReturnExcerpt(model.Post.PostContent);
            model.Post.Photo = photoName;
            model.Post.PostDate = DateTime.Now;
            model.Post.IsRead = 0;
            model.Post.UserId = Convert.ToInt32(Session["userID"].ToString());

            result.resultInt = postRepository.Insert(model.Post);

            if (result.resultInt.IsSucceeded)
            {

                return RedirectToAction("Index","Home");
            }
            else
                return View(model);



        }


        [ValidateInput(false)]
        [HttpGet]

        public ActionResult EditPost(int id)
        {
            PostViewModel pwm = new PostViewModel();

            List<SelectListItem> categoryList = new List<SelectListItem>();

            User currentUser = new User();

            foreach (Category item in categoryRepository.List().ProcessResult)
            {
                categoryList.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });

            }

            int userID = Convert.ToInt32(Session["userID"].ToString());

            currentUser = userRepository.GetObjectByID(userID).ProcessResult;



            pwm.User = currentUser;
            pwm.CategoryList = categoryList;
            pwm.Post = postRepository.GetObjectByID(id).ProcessResult;
            //pwm.Post.PostID = id;

            return View(pwm);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult EditPost(PostViewModel model, HttpPostedFileBase photo)
        {
            //a  variable to pass to upload folder.
            string photoName = "";

            if (photo.ContentLength > 0 && photo != null)
            {
                photoName = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";

                string path = Server.MapPath("~/Upload/" + photoName);

                photo.SaveAs(path);



            }
            ExcerptConstructor cons = new ExcerptConstructor();


            model.Post.PostExcerpt = cons.ReturnExcerpt(model.Post.PostContent);
            model.Post.Photo = photoName;
            model.Post.PostDate = DateTime.Now;
            model.Post.IsRead = 0;
            model.Post.UserId = Convert.ToInt32(Session["userID"].ToString());

            result.resultInt = postRepository.Update(model.Post);

            if (result.resultInt.IsSucceeded)
            {

                return RedirectToAction("Index", "Home");
            }
            else
                return View(model);



        }

        public ActionResult Delete(int id)
        {
            result.resultInt = postRepository.Delete(id);


            if (result.resultInt.ProcessResult > 0)
            {
                if (result.resultInt.IsSucceeded)
                {
                    ViewBag.status = "info";
                    ViewBag.result = "Deletion succesful..";
                }

                else
                {
                    ViewBag.status = "danger";
                    ViewBag.result = "Deletion of the post is not succesful";
                }
                return RedirectToAction("Index", "Home", new { @mesaj = result.resultInt.UserMessage, result = ViewBag.result, status = ViewBag.status });
            }

            else

                return View("Index","Home");













        }



        public ActionResult Archive()
        {
           

            var posts = postRepository.List().ProcessResult.OrderByDescending(x => x.PostDate).ToList();

            

            return View(posts);


        }





















        //public ActionResult IncrementReadCount(int postID)
        //{
        //    PostRepository postRepository = new PostRepository();

        //    Post postToIncrement = postRepository.GetObjectByID(postID).ProcessResult;
        //    postToIncrement.IsRead += 1;



        //    //    db.Makales.Where(m => m.MakaleId == Makaleid).SingleOrDefault();
        //    //makale.Okunma += 1;
        //    //db.SaveChanges();
        //    return RedirectToAction("SinglePost", new { id = postID });
        //}
    }
}