namespace AssetManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatinguser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role_Id");
        }
    }
}
