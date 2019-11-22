namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Metadata = c.String(),
                        FolderId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssetVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        Metadata = c.String(),
                        AssetId = c.Int(nullable: false),
                        FolderId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Folders", t => t.FolderId, cascadeDelete: true)
                .Index(t => t.AssetId)
                .Index(t => t.FolderId);
            
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FolderId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Folders", t => t.FolderId)
                .Index(t => t.FolderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetVersions", "FolderId", "dbo.Folders");
            DropForeignKey("dbo.Folders", "FolderId", "dbo.Folders");
            DropForeignKey("dbo.AssetVersions", "AssetId", "dbo.Assets");
            DropIndex("dbo.Folders", new[] { "FolderId" });
            DropIndex("dbo.AssetVersions", new[] { "FolderId" });
            DropIndex("dbo.AssetVersions", new[] { "AssetId" });
            DropTable("dbo.Folders");
            DropTable("dbo.AssetVersions");
            DropTable("dbo.Assets");
        }
    }
}
