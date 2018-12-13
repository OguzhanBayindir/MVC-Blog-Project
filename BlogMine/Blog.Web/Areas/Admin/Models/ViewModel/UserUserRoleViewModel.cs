using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Models.ViewModel
{
    public class UserUserRoleViewModel
    {
        public User User { get; set; }
        public IEnumerable<SelectListItem> UserRolesList { get; set; }

    }
}