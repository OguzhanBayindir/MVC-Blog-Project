using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Web.Areas.Admin.Models
{
    public  class ExcerptConstructor
    {
        static char[] breakCharacters = new char[] { '!', ',', '?', '.', ' ' };

        public string ReturnExcerpt(string input)

        {
            int wordsLimit = 30;

            string excerpt = "";

            while (excerpt.Length < 30)
            {
                foreach (var item in input.Split(breakCharacters))
                {
                    excerpt = excerpt + item + " ";

                    if (excerpt.Length >= 30)
                    {
                        break;
                    }
                }
            }

            return excerpt + "...";
        }

    }
}