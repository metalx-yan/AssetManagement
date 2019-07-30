namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Parameters", newName: "Categories");
            DropForeignKey("dbo.ReturnDetails", "Asset_Id", "dbo.Assets");
            DropForeignKey("dbo.ReturnDetails", "Return_Id", "dbo.Returns");
            DropIndex("dbo.ReturnDetails", new[] { "Asset_Id" });
            DropIndex("dbo.ReturnDetails", new[] { "Return_Id" });
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Boolean(nullable: false),
                        Religion = c.String(),
                        Department = c.String(),
                        Address = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.LoanRequestDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        AssetName = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        LoanRequest_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LoanRequests", t => t.LoanRequest_Id)
                .Index(t => t.LoanRequest_Id);
            
            CreateTable(
                "dbo.LoanRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Status = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Role_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Role_Id)
                .Index(t => t.Role_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Assets", "Category_Id", c => c.Int());
            CreateIndex("dbo.Assets", "Category_Id");
            AddForeignKey("dbo.Assets", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Categories", "Value");
            DropTable("dbo.ReturnDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ReturnDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Condition = c.String(),
                        Fine = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Asset_Id = c.Int(),
                        Return_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Categories", "Value", c => c.String());
            DropForeignKey("dbo.LoanRequestDetails", "LoanRequest_Id", "dbo.LoanRequests");
            DropForeignKey("dbo.LoanRequests", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.Employees", "Manager_Id", "dbo.Employees");
            DropForeignKey("dbo.Assets", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.LoanRequests", new[] { "User_Id" });
            DropIndex("dbo.LoanRequestDetails", new[] { "LoanRequest_Id" });
            DropIndex("dbo.Employees", new[] { "Manager_Id" });
            DropIndex("dbo.Assets", new[] { "Category_Id" });
            DropColumn("dbo.Assets", "Category_Id");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.LoanRequests");
            DropTable("dbo.LoanRequestDetails");
            DropTable("dbo.Employees");
            CreateIndex("dbo.ReturnDetails", "Return_Id");
            CreateIndex("dbo.ReturnDetails", "Asset_Id");
            AddForeignKey("dbo.ReturnDetails", "Return_Id", "dbo.Returns", "Id");
            AddForeignKey("dbo.ReturnDetails", "Asset_Id", "dbo.Assets", "Id");
            RenameTable(name: "dbo.Categories", newName: "Parameters");
        }
    }
}
