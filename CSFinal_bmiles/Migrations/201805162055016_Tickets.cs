namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tickets : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketNotes", "Ticket_TicketId", "dbo.Tickets");
            DropIndex("dbo.TicketNotes", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.TicketNotes", new[] { "Ticket_TicketId" });
            DropTable("dbo.TicketNotes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TicketNotes",
                c => new
                    {
                        NoteID = c.Int(nullable: false, identity: true),
                        NoteMessage = c.String(),
                        NoteTime = c.DateTime(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Ticket_TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.NoteID);
            
            CreateIndex("dbo.TicketNotes", "Ticket_TicketId");
            CreateIndex("dbo.TicketNotes", "ApplicationUser_Id");
            AddForeignKey("dbo.TicketNotes", "Ticket_TicketId", "dbo.Tickets", "TicketId");
            AddForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
