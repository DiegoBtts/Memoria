namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrations1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserViewModels", "Role", c => c.String());
            DropColumn("dbo.UserViewModels", "Edad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserViewModels", "Edad", c => c.Int(nullable: false));
            DropColumn("dbo.UserViewModels", "Role");
        }
    }
}
