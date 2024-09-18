namespace TaskManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        TareaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TareaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tareas");
        }
    }
}
