namespace Lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.books", "user_id", c => c.Int());
            CreateIndex("dbo.books", "user_id");
            AddForeignKey("dbo.books", "user_id", "dbo.users", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.books", "user_id", "dbo.users");
            DropIndex("dbo.books", new[] { "user_id" });
            DropColumn("dbo.books", "user_id");
        }
    }
}
