using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Blog.Common;

namespace Blog.Web.Models.ResultsModel

{
    public class InstanceResult<T>
    {
        public Result<int> resultInt { get; set; }
        public Result<T> resultType { get; set; }
        public Result<List<T>> resultList { get; set; }

    }
}