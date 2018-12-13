namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedMaxValueOfPostContentInPostTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "PostContent", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
