namespace DatabaseAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assets", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AssetVersions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Folders", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Folders", "Name", c => c.String());
            AlterColumn("dbo.AssetVersions", "Name", c => c.String());
            AlterColumn("dbo.Assets", "Name", c => c.String());
        }
    }
}
