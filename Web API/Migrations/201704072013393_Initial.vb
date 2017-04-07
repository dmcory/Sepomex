Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.cities",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .State_id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.municipalities",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Key = c.String(),
                        .Zip_code = c.String(),
                        .State_id = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.states",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(),
                        .Cities_Count = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.zip_codes",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Cp = c.String(),
                        .Asentamiento = c.String(),
                        .Tipo_Asentamiento = c.String(),
                        .Municipio = c.String(),
                        .Estado = c.String(),
                        .Ciudad = c.String(),
                        .Clave_Tipo_Asentamiento = c.String(),
                        .Clave_Municipio = c.String(),
                        .Clave_Ciudad = c.String(),
                        .Zona = c.String(),
                        .Created_At = c.DateTime(nullable := False),
                        .Updated_At = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.zip_codes")
            DropTable("dbo.states")
            DropTable("dbo.municipalities")
            DropTable("dbo.cities")
        End Sub
    End Class
End Namespace
