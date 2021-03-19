namespace Lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        brief = c.String(),
                        Desc = c.String(),
                        Pdf = c.String(),
                        author_id = c.Int(),
                        catalog_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Authors", t => t.author_id)
                .ForeignKey("dbo.catalogs", t => t.catalog_id)
                .Index(t => t.author_id)
                .Index(t => t.catalog_id);
            
            CreateTable(
                "dbo.catalogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        age = c.Int(),
                        email = c.String(),
                        password = c.String(),
                        photo = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "catalog_id", "dbo.catalogs");
            DropForeignKey("dbo.books", "author_id", "dbo.Authors");
            DropIndex("dbo.books", new[] { "catalog_id" });
            DropIndex("dbo.books", new[] { "author_id" });
            DropTable("dbo.users");
            DropTable("dbo.catalogs");
            DropTable("dbo.books");
            DropTable("dbo.Authors");
        }
    }
}
