
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	Class Rectangle
		Inherits Shape

		Private _Point1 As Point
		Private _Point2 As Point

		Protected Sub New()
		End Sub

		Public Sub New(p1 As Point, p2 As Point)
			Me.Point1 = p1
			Me.Point2 = p2
		End Sub

		Public Property Point1() As Point
			Get
				Return _Point1
			End Get
			Protected Set
				_Point1 = Value
			End Set
		End Property

		Public Property Point2() As Point
			Get
				Return _Point2
			End Get
			Protected Set
				_Point2 = Value
			End Set
		End Property

		Public Overrides ReadOnly Property Center() As Point
			Get
				Dim xs = Me.Point1.X + Me.Point2.X
				Dim ys = Me.Point1.Y + Me.Point2.Y

				Return New Point(xs / 2, ys / 2)
			End Get
		End Property

		Public ReadOnly Property Width() As Integer
			Get
				Return Math.Abs(Me.Point1.X - Me.Point2.X)
			End Get
		End Property

		Public ReadOnly Property Height() As Integer
			Get
				Return Math.Abs(Me.Point1.Y - Me.Point2.Y)
			End Get
		End Property

		Public Overrides Sub Print(output As TextWriter)
			output.WriteLine($"{Me.Color} rectangle at {Me.Center} of width {Me.Width} and height {Me.Height}")
		End Sub
	End Class
End Namespace
