namespace UPictures.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(nullable: false, maxLength: 255),
                        Path = c.String(nullable: false, maxLength: 255),
                        FileSize = c.Double(nullable: false),
                        DateTaken = c.DateTime(nullable: false),
                        Width = c.Int(nullable: false),
                        Height = c.Int(nullable: false),
                        CameraMaker = c.String(maxLength: 255),
                        CameraModel = c.String(maxLength: 255),
                        Album_Id = c.Int(nullable: false),
                        Album_Id1 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.Album_Id)
                .ForeignKey("dbo.Album", t => t.Album_Id1, cascadeDelete: true)
                .Index(t => t.Album_Id)
                .Index(t => t.Album_Id1);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Picture_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Picture", t => t.Picture_Id)
                .Index(t => t.Picture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Picture", "Album_Id1", "dbo.Album");
            DropForeignKey("dbo.Tag", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.Picture", "Album_Id", "dbo.Album");
            DropIndex("dbo.Tag", new[] { "Picture_Id" });
            DropIndex("dbo.Picture", new[] { "Album_Id1" });
            DropIndex("dbo.Picture", new[] { "Album_Id" });
            DropTable("dbo.Tag");
            DropTable("dbo.Picture");
            DropTable("dbo.Album");
        }
    }
}
