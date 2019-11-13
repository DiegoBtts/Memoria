namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NombreCompleto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NombreCompleto");
        }
    }
}
