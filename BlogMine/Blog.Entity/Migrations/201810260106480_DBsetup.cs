namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBsetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentContent = c.String(),
                        UserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Fullname = c.String(),
                        Photo = c.String(),
                        UserRole_UserRoleID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.UserRoles", t => t.UserRole_UserRoleID)
                .Index(t => t.UserRole_UserRoleID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        PostContent = c.String(),
                        Photo = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsRead = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserRoleID = c.Int(nullable: false, identity: true),
                        Rolename = c.String(),
                    })
                .PrimaryKey(t => t.UserRoleID);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagID = c.Int(nullable: false),
                        Post_PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagID, t.Post_PostID })
                .ForeignKey("dbo.Tags", t => t.Tag_TagID, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostID, cascadeDelete: true)
                .Index(t => t.Tag_TagID)
                .Index(t => t.Post_PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRole_UserRoleID", "dbo.UserRoles");
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropForeignKey("dbo.TagPosts", "Post_PostID", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagID", "dbo.Tags");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.TagPosts", new[] { "Post_PostID" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagID" });
            DropIndex("dbo.Posts", new[] { "UserId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Users", new[] { "UserRole_UserRoleID" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
        }
    }
}
