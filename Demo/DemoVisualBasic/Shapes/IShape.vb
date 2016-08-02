
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	Enum Color
		Black
		White
		Red
		Green
		Blue
	End Enum

	Structure Point
		Public X As Integer
		Public Y As Integer

		Public Sub New(x As Integer, y As Integer)
			Me.X = x
			Me.Y = y
		End Sub

		Public Overrides Function ToString() As String
			Return $"({Me.X}, {Me.Y})"
		End Function
	End Structure

	Interface IShape
		Property Color As Color
		ReadOnly Property Center As Point

		Sub Print(output As TextWriter)
	End Interface
End Namespace
