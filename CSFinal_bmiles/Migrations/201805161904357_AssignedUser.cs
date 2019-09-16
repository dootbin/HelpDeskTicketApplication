namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignedUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignedUsers",
                c => new
                    {
                        AssignedUserKey = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        TicketId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignedUserKey)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Tickets", t => t.TicketId)
                .Index(t => t.UserId)
                .Index(t => t.TicketId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignedUsers", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.AssignedUsers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AssignedUsers", new[] { "TicketId" });
            DropIndex("dbo.AssignedUsers", new[] { "UserId" });
            DropTable("dbo.AssignedUsers");
        }
    }
}
