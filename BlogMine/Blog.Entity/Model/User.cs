using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Model
{
    public partial class User
    {
      

        //Own properties

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Photo { get; set; }
        public int UserRoleId { get; set; }


        //Relational Properties

        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Post> Posts { get; set; }


    }
}
