using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Models.ViewModel
{
    public class CommentViewModel

    {
        public Comment Comment { get; set; }

        public IEnumerable<SelectListItem> UsersList { get; set; }
        public IEnumerable<SelectListItem> PostsList { get; set; }


    }
}