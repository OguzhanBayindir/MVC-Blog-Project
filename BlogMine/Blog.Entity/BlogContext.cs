namespace Blog.Entity
{
    using Blog.Entity.Entity_Configuration;
    using Blog.Entity.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogContext : DbContext
    {
        // Your context has been configured to use a 'BlogContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Blog.Entity.BlogContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BlogContext' 
        // connection string in the application configuration file.
        public BlogContext()
            : base("name=BlogContext")
        {
            
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());




            //Disabling cascade delete in case a post gets deleted
            modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithRequired(p => p.User)
            .WillCascadeOnDelete(false);

            //Editing the naming of TagPosts table and its members.

            modelBuilder.Entity<Post>()

                .HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(m => m.ToTable("TagPosts"));
       


                
            //{
            //m.ToTable("PostTags");
            //    m.MapLeftKey("PostId");
            //    m.MapRightKey("TagId");
            //});

            //Editing the UserRoleID-UserRoleID property in Users Table.

            modelBuilder.Entity<User>()

                .HasRequired(u => u.UserRole)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.UserRoleId);






            base.OnModelCreating(modelBuilder);
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}