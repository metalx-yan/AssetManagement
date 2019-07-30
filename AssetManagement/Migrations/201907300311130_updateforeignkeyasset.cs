namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateforeignkeyasset : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanRequestDetails", "Asset_Id", c => c.Int());
            CreateIndex("dbo.LoanRequestDetails", "Asset_Id");
            AddForeignKey("dbo.LoanRequestDetails", "Asset_Id", "dbo.Assets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanRequestDetails", "Asset_Id", "dbo.Assets");
            DropIndex("dbo.LoanRequestDetails", new[] { "Asset_Id" });
            DropColumn("dbo.LoanRequestDetails", "Asset_Id");
        }
    }
}
