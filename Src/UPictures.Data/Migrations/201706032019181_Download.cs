namespace UPictures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Download : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Download",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        CreationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Picture", "Download_Id", c => c.Int());
            CreateIndex("dbo.Picture", "Download_Id");
            AddForeignKey("dbo.Picture", "Download_Id", "dbo.Download", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picture", "Download_Id", "dbo.Download");
            DropIndex("dbo.Picture", new[] { "Download_Id" });
            DropColumn("dbo.Picture", "Download_Id");
            DropTable("dbo.Download");
        }
    }
}
