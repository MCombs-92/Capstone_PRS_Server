namespace PRS_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPurchaseRequestmodelwithnewproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequests", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseRequests", "Active");
        }
    }
}
