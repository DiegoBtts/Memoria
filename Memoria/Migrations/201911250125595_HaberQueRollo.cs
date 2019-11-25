namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HaberQueRollo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserViewModels", "ApellidoPaterno", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UserViewModels", "ApellidoMaterno", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UserViewModels", "UserName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.UserViewModels", "Password", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.UserViewModels", "ConfirmPassword", c => c.String());
            AddColumn("dbo.UserViewModels", "RoleName", c => c.String());
            AlterColumn("dbo.UserViewModels", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.UserViewModels", "Email", c => c.String(nullable: false));
            DropColumn("dbo.UserViewModels", "User");
            DropColumn("dbo.UserViewModels", "ApellidoP");
            DropColumn("dbo.UserViewModels", "ApellidoM");
            DropColumn("dbo.UserViewModels", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserViewModels", "Role", c => c.String());
            AddColumn("dbo.UserViewModels", "ApellidoM", c => c.String());
            AddColumn("dbo.UserViewModels", "ApellidoP", c => c.String());
            AddColumn("dbo.UserViewModels", "User", c => c.String());
            AlterColumn("dbo.UserViewModels", "Email", c => c.String());
            AlterColumn("dbo.UserViewModels", "Nombre", c => c.String());
            DropColumn("dbo.UserViewModels", "RoleName");
            DropColumn("dbo.UserViewModels", "ConfirmPassword");
            DropColumn("dbo.UserViewModels", "Password");
            DropColumn("dbo.UserViewModels", "UserName");
            DropColumn("dbo.UserViewModels", "ApellidoMaterno");
            DropColumn("dbo.UserViewModels", "ApellidoPaterno");
        }
    }
}
