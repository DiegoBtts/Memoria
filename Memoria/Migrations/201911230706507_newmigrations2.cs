namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrations2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserViewModels", "FechaNacimiento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserViewModels", "FechaNacimiento");
        }
    }
}
