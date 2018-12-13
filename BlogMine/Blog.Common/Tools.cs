using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Entity;

namespace Blog.Common
{
    public class Tools
    {
        public static BlogContext database = null;
        public static BlogContext GetConnection()

        {
            if (database == null)
            {
                database = new BlogContext();
            }


            return database;




        }




    }
}
