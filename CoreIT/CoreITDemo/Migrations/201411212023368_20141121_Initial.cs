namespace CoreITDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20141121_Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmpId = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        ImmigrationStatus = c.Int(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EmpId);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        EmpId = c.Int(nullable: false),
                        EffectiveFrom = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        PerW2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PerHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EmpHourlyShare = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Comments = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmpId, t.EffectiveFrom, t.ExpirationDate })
                .ForeignKey("dbo.Employees", t => t.EmpId, cascadeDelete: true)
                .Index(t => t.EmpId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        EntityId = c.Int(nullable: false),
                        EntityType = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        StateOrProvince = c.String(),
                        PostalCode = c.String(),
                        Contact = c.String(),
                        EmailId = c.String(),
                        IsCurrent = c.Boolean(nullable: false),
                        Employee_EmpId = c.Int(),
                        Vendor_VendorId = c.Int(),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmpId)
                .ForeignKey("dbo.Vendors", t => t.Vendor_VendorId)
                .Index(t => t.Employee_EmpId)
                .Index(t => t.Vendor_VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        IsActive = c.Boolean(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Addresses", new[] { "Vendor_VendorId" });
            DropIndex("dbo.Addresses", new[] { "Employee_EmpId" });
            DropIndex("dbo.Salaries", new[] { "EmpId" });
            DropForeignKey("dbo.Addresses", "Vendor_VendorId", "dbo.Vendors");
            DropForeignKey("dbo.Addresses", "Employee_EmpId", "dbo.Employees");
            DropForeignKey("dbo.Salaries", "EmpId", "dbo.Employees");
            DropTable("dbo.Vendors");
            DropTable("dbo.Addresses");
            DropTable("dbo.Salaries");
            DropTable("dbo.Employees");
        }
    }
}
