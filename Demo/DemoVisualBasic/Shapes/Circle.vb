
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	Class Circle
		Inherits Shape
		Private _center As Point

		Public Sub New(center As Point, radius As Integer)
			Me._center = center
			Me.Radius = radius
		End Sub

		Public ReadOnly Property Radius As Integer

		Public Overrides ReadOnly Property Center() As Point
			Get
				Return _center
			End Get
		End Property

		Public Overrides Sub Print(output As TextWriter)
			output.WriteLine($"{Me.Color} circle at {Me.Center} of radius {Me.Radius}")
		End Sub
	End Class
End Namespace
