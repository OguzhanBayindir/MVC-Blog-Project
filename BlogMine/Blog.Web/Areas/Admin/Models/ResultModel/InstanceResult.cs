﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Common;

namespace Blog.Areas.Admin.Models.ResultModel
{
    public class InstanceResults<T>
    {
        public Result<int> resultInt { get; set; }
        public Result<T> resultType { get; set; }
        public Result<List<T>> resultList { get; set; }

    }
}