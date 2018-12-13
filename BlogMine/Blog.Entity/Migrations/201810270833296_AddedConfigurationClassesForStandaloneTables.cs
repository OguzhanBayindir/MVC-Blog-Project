namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConfigurationClassesForStandaloneTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Comments", "CommentContent", c => c.String(nullable: false, maxLength: 600));
            AlterColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Fullname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "Photo", c => c.String(maxLength: 255));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Posts", "PostExcerpt", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Posts", "Photo", c => c.String(maxLength: 255));
            AlterColumn("dbo.Tags", "TagName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tags", "TagName", c => c.String());
            AlterColumn("dbo.Posts", "Photo", c => c.String());
            AlterColumn("dbo.Posts", "PostExcerpt", c => c.String());
            AlterColumn("dbo.Posts", "PostContent", c => c.String());
            AlterColumn("dbo.Posts", "Title", c => c.String());
            AlterColumn("dbo.Users", "Photo", c => c.String());
            AlterColumn("dbo.Users", "Fullname", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Comments", "CommentContent", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
        }
    }
}
