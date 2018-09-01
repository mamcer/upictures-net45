namespace UPictures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DownloadFileName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Download", "FileName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Download", "FileName");
        }
    }
}
