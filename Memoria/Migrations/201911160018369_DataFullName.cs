namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nombre", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApellidoPaterno", c => c.String());
            AddColumn("dbo.AspNetUsers", "ApellidoMaterno", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ApellidoMaterno");
            DropColumn("dbo.AspNetUsers", "ApellidoPaterno");
            DropColumn("dbo.AspNetUsers", "Nombre");
        }
    }
}
