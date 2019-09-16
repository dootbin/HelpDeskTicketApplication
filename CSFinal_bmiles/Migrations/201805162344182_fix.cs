namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignedUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AssignedUsers", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            AlterColumn("dbo.AssignedUsers", "UserId", c => c.String());
            AlterColumn("dbo.Tickets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.AssignedUsers", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tickets", "UserId");
            CreateIndex("dbo.AssignedUsers", "UserId");
            AddForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AssignedUsers", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
