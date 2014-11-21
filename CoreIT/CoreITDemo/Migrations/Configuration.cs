namespace CoreITDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CoreITDemo.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CoreITDemo.Models.CoreITDemoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CoreITDemo.Models.CoreITDemoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Employees.AddOrUpdate(p => p.EmpId,
               new Employee() { Firstname = "Nagesh", Lastname = "Tenugu", ImmigrationStatus = ImmigrationStatus.PetetionApproved, HireDate=new DateTime(2013,10,18) },
               new Employee() { Firstname = "Harshini", Lastname = "Puram", ImmigrationStatus = ImmigrationStatus.RFEInProcess, HireDate = new DateTime(2013, 10, 18) },
               new Employee() { Firstname = "Siva", Lastname = "Sontineni", ImmigrationStatus = ImmigrationStatus.PetetionApproved, HireDate = new DateTime(2014, 01, 15) });

            Salary[] salParams = new[] { 
                new Salary(){ EmpId=1, EffectiveFrom=new DateTime(2013,10,01), ExpirationDate= new DateTime(2014,07,31), PerW2=72000.00M, PerHour=58, EmpHourlyShare=80, Comments="FirstContract", ModifiedDate= DateTime.Now},
                new Salary(){ EmpId=1, EffectiveFrom=new DateTime(2014,08,01), ExpirationDate= new DateTime(2014,12,31), PerW2=84000.00M, PerHour=65, EmpHourlyShare=80, Comments="ContractRenewal", ModifiedDate= DateTime.Now},
                new Salary(){ EmpId=3, EffectiveFrom=new DateTime(2014,01,01), ExpirationDate= new DateTime(2014,12,31), PerW2=74000.00M, PerHour=75, EmpHourlyShare=80, Comments="FirstContract", ModifiedDate= DateTime.Now}
            };
            context.Salaries.AddOrUpdate(salParams);

            context.Vendors.AddOrUpdate(v => v.VendorId,
                new Vendor() { VendorName = "Software Global Ltd", IsActive = true, ModifiedDate= DateTime.Now },
                new Vendor() { VendorName = "Experis Consulting Comp", IsActive = true, ModifiedDate = DateTime.Now }
                );

            Address[] AddressList = new[] {
                new Address(){ EntityType = AddressEntity.Employee, EntityId = 1, Address1="2500 OLDFARM RD", City="Houston", StateOrProvince="TX", PostalCode="77063", IsCurrent=true, Contact="479-787-8786", EmailId="nagesh_tenugu@gmail.com"},
                new Address(){ EntityType = AddressEntity.Employee, EntityId = 2, Address1="2500 OLDFARM RD", City="Houston", StateOrProvince="TX", PostalCode="77063", IsCurrent=true, Contact="409-330-7608", EmailId="puram.harshini@gmail.com"},
                new Address(){ EntityType = AddressEntity.Employee, EntityId = 3, Address1="7979 Westhiemer", City="Houston", StateOrProvince="TX", PostalCode="77063", IsCurrent=true, Contact="795-457-8786", EmailId="siva_km@gmail.com"},
                new Address(){ EntityType = AddressEntity.Vendor, EntityId = 1, Address1="PO BOX 80498", City="Austin", StateOrProvince="TX", PostalCode="78708", IsCurrent=true, Contact="795-457-8786", EmailId="info@softwareglobalusa.com"},
                new Address(){ EntityType = AddressEntity.Vendor, EntityId = 2, Address1="2500 Dallas street", City="San Jose", StateOrProvince="CA", PostalCode="58745", IsCurrent=true, Contact="795-457-8786", EmailId="info@experisusa.com"},
            };
            context.Address.AddOrUpdate(AddressList);

            Payment[] payments = new[]{
                new Payment(){ EmpId= 1, PaidAmount=2550.00M, PaidOn= new DateTime(2013,12,18), PaymentType = PaymentType.MonthlyPay, Comments="MonthlyPay", TransactionDate=new DateTime(2013,12,18)},
                new Payment(){ EmpId= 3, PaidAmount=4500.00M, PaidOn= new DateTime(2014,03,15), PaymentType = PaymentType.MonthlyPay, Comments="MonthlyPay", TransactionDate=new DateTime(2013,12,18)},
                new Payment(){ EmpId= 1, PaidAmount=2500.00M, PaidOn= new DateTime(2014,06,15), PaymentType = PaymentType.MiscExpenses, Comments="Insurnace money", TransactionDate=new DateTime(2014,06,15)}
            };
            context.Payments.AddOrUpdate(payments);
        }
    }
}
