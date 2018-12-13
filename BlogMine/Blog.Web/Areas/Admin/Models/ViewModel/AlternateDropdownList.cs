using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web.Areas.Admin.Models.ViewModel
{
    public class AlternateDropdownList
    {
        public int UserRoleID { get; set; } //when an item is selected from drowdown list, when page is posted it is filled

        public SelectList UserRoleData { get; set; }

    }
}