﻿Imports System.Data.Entity

Namespace Models
    
    Public Class Web_APIContext
        Inherits DbContext
    
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, please use data migrations.
        ' For more information refer to the documentation:
        ' http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        Public Sub New()
            MyBase.New("name=Web_APIContext")
        End Sub

        Public Property cities As System.Data.Entity.DbSet(Of cities)
        Public Property municipalities As System.Data.Entity.DbSet(Of municipalities)
        Public Property states As System.Data.Entity.DbSet(Of states)
        Public Property zip_codes As System.Data.Entity.DbSet(Of zip_codes)
    End Class
    
End Namespace