using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Model
{
    public partial class UserRole
    {
        //Own Properties

        public int UserRoleID { get; set; }
        public string Rolename { get; set; }

        //Relational Properties

        public virtual ICollection<User> Users{get;set;}

    }
}
