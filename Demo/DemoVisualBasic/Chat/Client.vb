
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Chat
	Class Client
		Private server As Server
		Private messages As IList(Of String)

		Public Sub New()
			messages = New List(Of String)()
			Me.Id = Guid.NewGuid()
		End Sub

		Public ReadOnly Property Id As Guid

		Public Async Function ConnectAsync(server As Server) As Task(Of MessageResult)
			Dim result = Await server.AcceptAsync(Me)
			Me.server = server
			Return result
		End Function

		Public Async Function SendAsync(message As String) As Task(Of MessageResult)
			Dim result = Await server.ReceiveAsync(Me.Id, message)
			Return result
		End Function

		Public Async Function ReceiveAsync(message As String) As Task(Of MessageResult)
			Await Task.Delay(3)
			messages.Add($"Server: {message}")

			Dim result = New SuccessMessageResult()
			Return result
		End Function
	End Class
End Namespace
