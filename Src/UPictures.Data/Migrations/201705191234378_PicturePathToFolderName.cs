namespace UPictures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicturePathToFolderName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Picture", "FolderName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Picture", "Path");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "Path", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Picture", "FolderName");
        }
    }
}
