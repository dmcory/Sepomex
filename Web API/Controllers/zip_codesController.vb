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
            Dim zip_codes As zip_codes = db.zip_codes.Find(id)
            If IsNothing(zip_codes) Then
                Return NotFound()
            End If

            Return Ok(zip_codes)
        End Function

        ' PUT: api/zip_codes/5
        <ResponseType(GetType(Void))>
        Function Putzip_codes(ByVal id As Integer, ByVal zip_codes As zip_codes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = zip_codes.Id Then
                Return BadRequest()
            End If

            db.Entry(zip_codes).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (zip_codesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/zip_codes
        <ResponseType(GetType(zip_codes))>
        Function Postzip_codes(ByVal zip_codes As zip_codes) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.zip_codes.Add(zip_codes)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = zip_codes.Id}, zip_codes)
        End Function

        ' DELETE: api/zip_codes/5
        <ResponseType(GetType(zip_codes))>
        Function Deletezip_codes(ByVal id As Integer) As IHttpActionResult
            Dim zip_codes As zip_codes = db.zip_codes.Find(id)
            If IsNothing(zip_codes) Then
                Return NotFound()
            End If

            db.zip_codes.Remove(zip_codes)
            db.SaveChanges()

            Return Ok(zip_codes)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function zip_codesExists(ByVal id As Integer) As Boolean
            Return db.zip_codes.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace