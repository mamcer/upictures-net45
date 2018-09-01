namespace UPictures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DownloadPictures : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Picture", "Download_Id", "dbo.Download");
            DropIndex("dbo.Picture", new[] { "Download_Id" });
            CreateTable(
                "dbo.DownloadPictures",
                c => new
                    {
                        Download_Id = c.Int(nullable: false),
                        Picture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Download_Id, t.Picture_Id })
                .ForeignKey("dbo.Download", t => t.Download_Id, cascadeDelete: true)
                .ForeignKey("dbo.Picture", t => t.Picture_Id, cascadeDelete: true)
                .Index(t => t.Download_Id)
                .Index(t => t.Picture_Id);
            
            DropColumn("dbo.Picture", "Download_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "Download_Id", c => c.Int());
            DropForeignKey("dbo.DownloadPictures", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.DownloadPictures", "Download_Id", "dbo.Download");
            DropIndex("dbo.DownloadPictures", new[] { "Picture_Id" });
            DropIndex("dbo.DownloadPictures", new[] { "Download_Id" });
            DropTable("dbo.DownloadPictures");
            CreateIndex("dbo.Picture", "Download_Id");
            AddForeignKey("dbo.Picture", "Download_Id", "dbo.Download", "Id");
        }
    }
}
