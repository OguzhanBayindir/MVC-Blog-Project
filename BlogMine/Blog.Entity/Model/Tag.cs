using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Model
{
    public partial class Tag
    {
        public Tag()
        {
            Posts = new HashSet<Post>();
        }

        //Own Properties

        public int TagID { get; set; }
        public string TagName { get; set; }

        //Relational Properties

        public virtual ICollection<Post> Posts { get; set; }

    }
}
