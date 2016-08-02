
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Collections
	Class Element
		Public Property Data As Object

		Public Sub New(data As Object)
			Me.Data = data
		End Sub

		Public Overrides Function ToString() As String
			Return "My element"
		End Function
	End Class
End Namespace
