Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Web_API
Imports Web_API.Models

Namespace Controllers
    Public Class zip_codesController
        Inherits System.Web.Http.ApiController

        Private db As New Web_APIContext

        ' GET: api/zip_codes
        Function Getzip_codes() As IQueryable(Of zip_codes)
            Return db.zip_codes
        End Function

        ' GET: api/zip_codes/5
        <ResponseType(GetType(zip_codes))>
        Function Getzip_codes(ByVal id As Integer) As IHttpActionResult
            Dim zip_codes As List(Of zip_codes) = db.zip_codes.Where(Function(x) x.Cp = id).ToList
            If IsNothing(zip_codes) Then
                Return NotFound()
            End If

            Return Ok(zip_codes)
        End Function
    End Class
End Namespace