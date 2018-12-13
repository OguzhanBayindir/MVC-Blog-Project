using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Blog.Entity.Model
{
    public partial class Post
    {

        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        //Own Properties
        public int PostID { get; set; }

        public string Title { get; set; }

        [MaxLength]
        public string PostContent { get; set; }
        [MaxLength]
        public string PostExcerpt { get; set; }
        public string Photo { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public int IsRead { get; set; }
        
        //Relational Properties

        public virtual User User { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

    }
}
