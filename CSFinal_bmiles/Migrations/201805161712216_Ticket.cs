namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ticket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        Date = c.DateTime(nullable: false),
                        OpenStatus = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropTable("dbo.Tickets");
        }
    }
}
