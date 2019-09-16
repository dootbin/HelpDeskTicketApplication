namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketNotes1 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.NoteID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Tickets", t => t.Ticket_TicketId)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Ticket_TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketNotes", "Ticket_TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketNotes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TicketNotes", new[] { "Ticket_TicketId" });
            DropIndex("dbo.TicketNotes", new[] { "ApplicationUser_Id" });
            DropTable("dbo.TicketNotes");
        }
    }
}
