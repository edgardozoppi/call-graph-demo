
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	Class Triangle
		Inherits Shape
		Public Sub New(p1 As Point, p2 As Point, p3 As Point)
			Me.Point1 = p1
			Me.Point2 = p2
			Me.Point3 = p3
		End Sub

		Public Property Point1 As Point
		Public Property Point2 As Point
		Public Property Point3 As Point

		Public Overrides ReadOnly Property Center() As Point
			Get
				Dim xs = Me.Point1.X + Me.Point2.X + Me.Point3.X
				Dim ys = Me.Point1.Y + Me.Point2.Y + Me.Point3.Y

				Return New Point(xs / 3, ys / 3)
			End Get
		End Property

		Public Overrides Sub Print(output As TextWriter)
			output.WriteLine($"{Me.Color} triangle at {Me.Center}")
		End Sub
	End Class
End Namespace
