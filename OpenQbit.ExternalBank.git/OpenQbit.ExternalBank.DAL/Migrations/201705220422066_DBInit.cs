namespace OpenQbit.ExternalBank.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankAccNo = c.Int(nullable: false),
                        CurrentBalance = c.Int(nullable: false),
                        AccountTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountTypes", t => t.AccountTypesId, cascadeDelete: true)
                .Index(t => t.AccountTypesId);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        SubType = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Tel = c.String(),
                        City = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDate = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        AccountId = c.Int(nullable: false),
                        TransactionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransactionType", t => t.TransactionTypeId, cascadeDelete: true)
                .Index(t => t.TransactionTypeId);
            
            CreateTable(
                "dbo.TransactionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        SubType = c.String(),
                        status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransactionDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionDetail", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Transaction", "TransactionTypeId", "dbo.TransactionType");
            DropForeignKey("dbo.Account", "AccountTypesId", "dbo.AccountTypes");
            DropIndex("dbo.TransactionDetail", new[] { "AccountId" });
            DropIndex("dbo.Transaction", new[] { "TransactionTypeId" });
            DropIndex("dbo.Account", new[] { "AccountTypesId" });
            DropTable("dbo.TransactionDetail");
            DropTable("dbo.TransactionType");
            DropTable("dbo.Transaction");
            DropTable("dbo.Person");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Account");
        }
    }
}
