using Blog.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entity_Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(100);

            Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

            Property(u => u.Password)
            .IsRequired()
            .HasMaxLength(100);

            Property(u => u.Fullname)
           .IsRequired()
           .HasMaxLength(100);

            Property(u => u.Photo)
            .IsOptional()
            .HasMaxLength(255);



        }

    }
}