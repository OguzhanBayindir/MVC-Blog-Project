using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Models.ViewModel
{
    public class PostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<SelectListItem> UsersList { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }



    }
}