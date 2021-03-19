namespace Lab4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mod3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.users", "age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.users", "age", c => c.Int());
        }
    }
}
