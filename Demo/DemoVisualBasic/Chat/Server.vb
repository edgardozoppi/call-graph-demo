
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Chat
	MustInherit Class MessageResult
		Public MustOverride ReadOnly Property Status() As Integer

		Public Overrides Function ToString() As String
			Return $"Message result status: {Me.Status}"
		End Function
	End Class

	Class SuccessMessageResult
		Inherits MessageResult
		Public Overrides ReadOnly Property Status() As Integer
			Get
				Return 0
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return $"Success message result status: {Me.Status}"
		End Function
	End Class

	Class ErrorMessageResult
		Inherits MessageResult
		Public Overrides ReadOnly Property Status() As Integer
			Get
				Return -1
			End Get
		End Property

		Public Overrides Function ToString() As String
			Return $"Error message result status: {Me.Status}"
		End Function
	End Class

	Class Server
		Private clients As IDictionary(Of Guid, Client)
		Private messages As IList(Of String)

		Public Sub New()
			clients = New Dictionary(Of Guid, Client)()
			messages = New List(Of String)()
		End Sub

		Public Function AcceptAsync(client As Client) As Task(Of MessageResult)
			clients.Add(client.Id, client)

			Dim result = New SuccessMessageResult()
			Return Task.FromResult(Of MessageResult)(result)
		End Function

		Public Async Function SendAsync(message As String) As Task(Of MessageResult)
			Dim result As MessageResult = New ErrorMessageResult()

			If clients.Count > 0 Then
				Dim tasks = New List(Of Task)()

				For Each client In clients.Values
					Dim task__1 = client.ReceiveAsync(message)
					tasks.Add(task__1)
				Next

				Await Task.WhenAll(tasks)
				result = New SuccessMessageResult()
			End If

			Return result
		End Function

		Public Async Function ReceiveAsync(clientId As Guid, message As String) As Task(Of MessageResult)
			Await Task.Delay(3)
			messages.Add($"Client {clientId}: {message}")

			Dim result = New ErrorMessageResult()
			Return result
		End Function
	End Class
End Namespace
