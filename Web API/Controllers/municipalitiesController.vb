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
    Public Class municipalitiesController
        Inherits System.Web.Http.ApiController

        Private db As New Web_APIContext

        ' GET: api/municipalities
        Function Getmunicipalities() As IQueryable(Of municipalities)
            Return db.municipalities
        End Function

        ' GET: api/municipalities/5
        <ResponseType(GetType(municipalities))>
        Function Getmunicipalities(ByVal id As Integer) As IHttpActionResult
            Dim municipalities As municipalities = db.municipalities.Find(id)
            If IsNothing(municipalities) Then
                Return NotFound()
            End If

            Return Ok(municipalities)
        End Function

        ' PUT: api/municipalities/5
        <ResponseType(GetType(Void))>
        Function Putmunicipalities(ByVal id As Integer, ByVal municipalities As municipalities) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = municipalities.Id Then
                Return BadRequest()
            End If

            db.Entry(municipalities).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (municipalitiesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/municipalities
        <ResponseType(GetType(municipalities))>
        Function Postmunicipalities(ByVal municipalities As municipalities) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.municipalities.Add(municipalities)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = municipalities.Id}, municipalities)
        End Function

        ' DELETE: api/municipalities/5
        <ResponseType(GetType(municipalities))>
        Function Deletemunicipalities(ByVal id As Integer) As IHttpActionResult
            Dim municipalities As municipalities = db.municipalities.Find(id)
            If IsNothing(municipalities) Then
                Return NotFound()
            End If

            db.municipalities.Remove(municipalities)
            db.SaveChanges()

            Return Ok(municipalities)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function municipalitiesExists(ByVal id As Integer) As Boolean
            Return db.municipalities.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace