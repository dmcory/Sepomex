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
    Public Class citiesController
        Inherits System.Web.Http.ApiController

        Private db As New Web_APIContext

        ' GET: api/cities
        Function Getcities() As IQueryable(Of cities)
            Return db.cities
        End Function

        ' GET: api/cities/5
        <ResponseType(GetType(cities))>
        Function Getcities(ByVal id As Integer) As IHttpActionResult
            Dim cities As cities = db.cities.Find(id)
            If IsNothing(cities) Then
                Return NotFound()
            End If

            Return Ok(cities)
        End Function

        ' PUT: api/cities/5
        <ResponseType(GetType(Void))>
        Function Putcities(ByVal id As Integer, ByVal cities As cities) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = cities.Id Then
                Return BadRequest()
            End If

            db.Entry(cities).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (citiesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/cities
        <ResponseType(GetType(cities))>
        Function Postcities(ByVal cities As cities) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.cities.Add(cities)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = cities.Id}, cities)
        End Function

        ' DELETE: api/cities/5
        <ResponseType(GetType(cities))>
        Function Deletecities(ByVal id As Integer) As IHttpActionResult
            Dim cities As cities = db.cities.Find(id)
            If IsNothing(cities) Then
                Return NotFound()
            End If

            db.cities.Remove(cities)
            db.SaveChanges()

            Return Ok(cities)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function citiesExists(ByVal id As Integer) As Boolean
            Return db.cities.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace