using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entity_Configuration
{
    public class PostConfiguration:EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(100);

            Property(p => p.PostContent)
            .IsRequired()
            .HasMaxLength(5000);

            Property(p => p.Photo)
            .IsOptional()
            .HasMaxLength(255);

            Property(p => p.PostExcerpt)
            .IsRequired()
            .HasMaxLength(50);



        }

    }
}
