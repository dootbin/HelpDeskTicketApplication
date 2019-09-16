namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketUpdateClosedDateOptionalFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "ClosedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "ClosedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime());
        }
    }
}
