using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Model
{
    public partial class Comment
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime CommentDate { get; set; }


        public virtual Post Post { get; set; }
        public virtual User User { get; set; }


    }
}
