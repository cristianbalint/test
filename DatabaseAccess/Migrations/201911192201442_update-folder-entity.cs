namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefolderentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Folders", "FolderId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "FolderId" });
            AddColumn("dbo.Folders", "ParentFolderId", c => c.Int(nullable: false));
            DropColumn("dbo.Folders", "FolderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Folders", "FolderId", c => c.Int(nullable: false));
            DropColumn("dbo.Folders", "ParentFolderId");
            CreateIndex("dbo.Folders", "FolderId");
            AddForeignKey("dbo.Folders", "FolderId", "dbo.Folders", "Id");
        }
    }
}
