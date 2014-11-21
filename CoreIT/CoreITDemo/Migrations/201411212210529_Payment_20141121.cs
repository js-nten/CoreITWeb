namespace CoreITDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment_20141121 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        PaidOn = c.DateTime(nullable: false),
                        PaidAmount = c.Decimal(precision: 18, scale: 2),
                        Comments = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpId, t.PaymentType })
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Payments", new[] { "EmpId" });
            DropForeignKey("dbo.Payments", "EmpId", "dbo.Employees");
            DropTable("dbo.Payments");
        }
    }
}
