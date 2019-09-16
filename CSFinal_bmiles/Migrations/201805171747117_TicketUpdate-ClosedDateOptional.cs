namespace CSFinal_bmiles.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketUpdateClosedDateOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "Date", c => c.DateTime(nullable: false));
        }
    }
}
