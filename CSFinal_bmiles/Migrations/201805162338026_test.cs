namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TicketNotes", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.TicketNotes", "UserId", c => c.String());
            DropColumn("dbo.TicketNotes", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketNotes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.TicketNotes", "UserId");
            CreateIndex("dbo.TicketNotes", "ApplicationUser_Id");
            AddForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
