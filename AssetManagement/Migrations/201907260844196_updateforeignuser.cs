namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateforeignuser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Role_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_Id" });
            AlterColumn("dbo.Users", "Role_Id", c => c.Int(nullable: false));
        }
    }
}
