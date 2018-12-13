using Blog.Entity.Model;
using Blog.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Repository;
using Blog.Common;
using Blog.Entity;

namespace Blog.Web.Controllers
{
    public class PublicCommentController : Controller
    {
        CommentRepository commentRepository = new CommentRepository();
         

        // GET: PublicComment
        [HttpPost]
        public ActionResult Create(PostCommentViewModel model)
        {

            Comment comment = new Comment();

            comment.CommentContent = model.Comment.CommentContent;
            comment.CommentDate = DateTime.Now;
            comment.UserId = Convert.ToInt32(Session["userID"]);
            comment.PostId = model.Post.PostID;

            commentRepository.Insert(comment);


            return RedirectToAction("SinglePost", "PublicPost", new { id = comment.PostId });
            
            
        }

        public ActionResult Delete(int id)

        {
            int userID = Convert.ToInt32(Session["userID"].ToString());

            Comment comment = commentRepository.List().ProcessResult.Where(x => x.CommentID == id).SingleOrDefault();

            if (comment.UserId == userID)
            {
                commentRepository.Delete(id);

                return RedirectToAction("SinglePost", "PublicPost", new { id = comment.PostId });

            }

            else
            {
                return HttpNotFound();
            }

        }


    }
}