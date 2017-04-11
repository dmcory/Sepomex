Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
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
                        .Zona = c.String()
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.zip_codes")
        End Sub
    End Class
End Namespace
