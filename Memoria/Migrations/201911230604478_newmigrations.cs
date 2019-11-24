namespace Memoria.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        User = c.String(),
                        Nombre = c.String(),
                        ApellidoP = c.String(),
                        ApellidoM = c.String(),
                        Email = c.String(),
                        Edad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserViewModels");
        }
    }
}
