namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketUpdateClosedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ClosedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tickets", "OpenStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "OpenStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Tickets", "ClosedDate");
        }
    }
}
