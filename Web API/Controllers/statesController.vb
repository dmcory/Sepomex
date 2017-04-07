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
    Public Class statesController
        Inherits System.Web.Http.ApiController

        Private db As New Web_APIContext

        ' GET: api/states
        Function Getstates() As IQueryable(Of states)
            Return db.states
        End Function

        ' GET: api/states/5
        <ResponseType(GetType(states))>
        Function Getstates(ByVal id As Integer) As IHttpActionResult
            Dim states As states = db.states.Find(id)
            If IsNothing(states) Then
                Return NotFound()
            End If

            Return Ok(states)
        End Function

        ' PUT: api/states/5
        <ResponseType(GetType(Void))>
        Function Putstates(ByVal id As Integer, ByVal states As states) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = states.Id Then
                Return BadRequest()
            End If

            db.Entry(states).State = EntityState.Modified

            Try
                db.SaveChanges()
            Catch ex As DbUpdateConcurrencyException
                If Not (statesExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/states
        <ResponseType(GetType(states))>
        Function Poststates(ByVal states As states) As IHttpActionResult
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.states.Add(states)
            db.SaveChanges()

            Return CreatedAtRoute("DefaultApi", New With {.id = states.Id}, states)
        End Function

        ' DELETE: api/states/5
        <ResponseType(GetType(states))>
        Function Deletestates(ByVal id As Integer) As IHttpActionResult
            Dim states As states = db.states.Find(id)
            If IsNothing(states) Then
                Return NotFound()
            End If

            db.states.Remove(states)
            db.SaveChanges()

            Return Ok(states)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function statesExists(ByVal id As Integer) As Boolean
            Return db.states.Count(Function(e) e.Id = id) > 0
        End Function
    End Class
End Namespace