namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangeToCommentsTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "PostID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
        }
    }
}
