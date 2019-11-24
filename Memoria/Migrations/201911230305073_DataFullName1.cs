namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataFullName1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FechaNacimiento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "ApellidoPaterno", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AspNetUsers", "ApellidoMaterno", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "ApellidoMaterno", c => c.String());
            AlterColumn("dbo.AspNetUsers", "ApellidoPaterno", c => c.String());
            AlterColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            DropColumn("dbo.AspNetUsers", "FechaNacimiento");
        }
    }
}
