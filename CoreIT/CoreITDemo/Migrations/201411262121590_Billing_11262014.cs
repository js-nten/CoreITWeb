namespace CoreITDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Billing_11262014 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingDetails",
                c => new
                    {
                        BillingId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        BillingDate = c.DateTime(nullable: false),
                        TotalHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.BillingId)
                .ForeignKey("dbo.Assignments", t => t.AssignmentId, cascadeDelete: true)
                .Index(t => t.AssignmentId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BillingDetails", new[] { "AssignmentId" });
            DropForeignKey("dbo.BillingDetails", "AssignmentId", "dbo.Assignments");
            DropTable("dbo.BillingDetails");
        }
    }
}
