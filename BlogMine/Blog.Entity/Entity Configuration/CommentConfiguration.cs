using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entity_Configuration
{
   public class CommentConfiguration:EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            Property(c => c.CommentContent)
            .IsRequired()
            .HasMaxLength(600);

            

        }


    }
}
