namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketNotes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignedUsers", "TicketId", "dbo.Tickets");
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
                .PrimaryKey(t => t.NoteID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Ticket_TicketId);
            
            AddForeignKey("dbo.AssignedUsers", "TicketId", "dbo.Tickets", "TicketId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedUsers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotes", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TicketNotes", new[] { "Ticket_TicketId" });
            DropIndex("dbo.TicketNotes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.TicketNotes");
            AddForeignKey("dbo.AssignedUsers", "TicketId", "dbo.Tickets", "TicketId");
        }
    }
}
