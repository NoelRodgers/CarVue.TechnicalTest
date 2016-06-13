namespace CarVue.TechnicalTest.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompanyAndAddressTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhysicalAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(),
                        Line2 = c.String(),
                        County = c.String(),
                        PostCode = c.String(),
                        AddressType = c.Int(nullable: false),
                        IsPrimaryAddress = c.Boolean(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.VirtualAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressType = c.Int(nullable: false),
                        Value = c.String(),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VirtualAddresses", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.PhysicalAddresses", "Company_Id", "dbo.Companies");
            DropIndex("dbo.VirtualAddresses", new[] { "Company_Id" });
            DropIndex("dbo.PhysicalAddresses", new[] { "Company_Id" });
            DropTable("dbo.VirtualAddresses");
            DropTable("dbo.PhysicalAddresses");
            DropTable("dbo.Companies");
        }
    }
}
