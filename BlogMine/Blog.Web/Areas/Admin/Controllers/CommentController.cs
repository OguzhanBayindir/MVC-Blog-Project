using Blog.Areas.Admin.Models.ResultModel;
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
    public class CommentController : Controller
    {
       InstanceResults<Comment> result = new InstanceResults<Comment>();

        CommentRepository commentRep = new CommentRepository();
        UserRepository userRep = new UserRepository();
        PostRepository postRep = new PostRepository();

        public ActionResult List()
        {
            result.resultList = commentRep.List();


            return View(result.resultList.ProcessResult);
        }


        [HttpGet]
        public ActionResult AddComment()
        {
            CommentViewModel cwm = new CommentViewModel();

            List<SelectListItem> usersList = new List<SelectListItem>();
            List<SelectListItem> postsList = new List<SelectListItem>();

            foreach (Post item in postRep.List().ProcessResult)
            {
                postsList.Add(new SelectListItem { Value = item.PostID.ToString(), Text = item.Title });

            }

            foreach (User item in userRep.List().ProcessResult)
            {
                usersList.Add(new SelectListItem { Value = item.UserID.ToString(), Text = item.Username });

            }

            cwm.UsersList = usersList;
            cwm.PostsList = postsList;
            cwm.Comment = null;


            return View(cwm);
        }

        [HttpPost]

        public ActionResult AddComment(CommentViewModel model)
        {
            model.Comment.CommentDate = DateTime.Now;


            result.resultInt = commentRep.Insert(model.Comment);

            if (result.resultInt.IsSucceeded)
            {
                return RedirectToAction("List");
            }
            else
                return View(model);



        }

        public ActionResult Edit(int id)
        {
            CommentViewModel cwm = new CommentViewModel();

            List<SelectListItem> postsList = new List<SelectListItem>();
            List<SelectListItem> userList = new List<SelectListItem>();

            foreach (Post item in postRep.List().ProcessResult)
            {
                postsList.Add(new SelectListItem { Value = item.PostID.ToString(), Text = item.Title });
            }

            foreach (User item in userRep.List().ProcessResult)
            {
                userList.Add(new SelectListItem { Value = item.UserID.ToString(), Text = item.Username });
            }

            cwm.PostsList = postsList;
            cwm.UsersList = userList;
            cwm.Comment = commentRep.GetObjectByID(id).ProcessResult;
                
            //cwm.Comment = commentRep.GetObjectByPostIDAndUserID(starter.UserId, starter.PostId, starter.CommentID).ProcessResult;
            //cwm.Comment = commentRep.GetObjectByPostIDAndUserID(userId,postId,commentID).ProcessResult;

            return View(cwm);
        }


        [HttpPost]
        public ActionResult Edit(CommentViewModel model, HttpPostedFileBase photo)
        {

            model.Comment.CommentDate = DateTime.Now;


            result.resultInt = commentRep.Update(model.Comment);

            if (result.resultInt.ProcessResult > 0)
            {
                return RedirectToAction("List");
            }

            else

                return View(model);
        }

        public ActionResult Delete(int id)
        {
            result.resultInt = commentRep.Delete(id);


            return RedirectToAction("List", new { @mesaj = result.resultInt.UserMessage });
        }
    }
}