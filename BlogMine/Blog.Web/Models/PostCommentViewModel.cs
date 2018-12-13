using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Models
{
    public class PostCommentViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
    }
}