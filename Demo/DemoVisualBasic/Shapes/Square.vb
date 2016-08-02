
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	Class Square
		Inherits Rectangle
		Public Sub New(p1 As Point, size As Integer)
			Me.Point1 = p1
			Me.Point2 = New Point(p1.X + size, p1.Y + size)
		End Sub

		Public Overrides Sub Print(output As TextWriter)
			output.WriteLine($"{Me.Color} square at {Me.Center} of width {Me.Width} and height {Me.Height}")
		End Sub
	End Class
End Namespace
