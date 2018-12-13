namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangeToPostsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostExcerpt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PostExcerpt");
        }
    }
}
