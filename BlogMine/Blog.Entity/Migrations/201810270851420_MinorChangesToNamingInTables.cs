namespace Blog.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangesToNamingInTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.TagPosts", newName: "PostTags");
            DropForeignKey("dbo.Users", "UserRole_UserRoleID", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRole_UserRoleID" });
            RenameColumn(table: "dbo.Users", name: "UserRole_UserRoleID", newName: "UserRoleId");
            RenameColumn(table: "dbo.PostTags", name: "Tag_TagID", newName: "TagId");
            RenameColumn(table: "dbo.PostTags", name: "Post_PostID", newName: "PostId");
            RenameIndex(table: "dbo.PostTags", name: "IX_Post_PostID", newName: "IX_PostId");
            RenameIndex(table: "dbo.PostTags", name: "IX_Tag_TagID", newName: "IX_TagId");
            DropPrimaryKey("dbo.PostTags");
            AlterColumn("dbo.Users", "UserRoleId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PostTags", new[] { "PostId", "TagId" });
            CreateIndex("dbo.Users", "UserRoleId");
            AddForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles", "UserRoleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropPrimaryKey("dbo.PostTags");
            AlterColumn("dbo.Users", "UserRoleId", c => c.Int());
            AddPrimaryKey("dbo.PostTags", new[] { "Tag_TagID", "Post_PostID" });
            RenameIndex(table: "dbo.PostTags", name: "IX_TagId", newName: "IX_Tag_TagID");
            RenameIndex(table: "dbo.PostTags", name: "IX_PostId", newName: "IX_Post_PostID");
            RenameColumn(table: "dbo.PostTags", name: "PostId", newName: "Post_PostID");
            RenameColumn(table: "dbo.PostTags", name: "TagId", newName: "Tag_TagID");
            RenameColumn(table: "dbo.Users", name: "UserRoleId", newName: "UserRole_UserRoleID");
            CreateIndex("dbo.Users", "UserRole_UserRoleID");
            AddForeignKey("dbo.Users", "UserRole_UserRoleID", "dbo.UserRoles", "UserRoleID");
            RenameTable(name: "dbo.PostTags", newName: "TagPosts");
        }
    }
}
