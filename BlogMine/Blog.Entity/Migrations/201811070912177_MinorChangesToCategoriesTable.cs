namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangesToCategoriesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryDescription", c => c.String());
            AddColumn("dbo.Categories", "CategoryPhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "CategoryPhoto");
            DropColumn("dbo.Categories", "CategoryDescription");
        }
    }
}
