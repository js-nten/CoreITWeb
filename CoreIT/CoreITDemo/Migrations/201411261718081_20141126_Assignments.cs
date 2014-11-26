namespace CoreITDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20141126_Assignments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        EmpId = c.Int(nullable: false),
                        VendorId = c.Int(nullable: false),
                        Workplace = c.String(),
                        HourlyRate = c.Decimal(precision: 18, scale: 2),
                        EmpShare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.EmpId)
                .Index(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Assignments", new[] { "VendorId" });
            DropIndex("dbo.Assignments", new[] { "EmpId" });
            DropForeignKey("dbo.Assignments", "VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Assignments", "EmpId", "dbo.Employees");
            DropTable("dbo.Assignments");
        }
    }
}
