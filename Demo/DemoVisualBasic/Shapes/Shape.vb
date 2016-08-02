
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Shapes
	MustInherit Class Shape
		Implements IShape
		Public Property Color As Color Implements IShape.Color

		Public MustOverride ReadOnly Property Center As Point Implements IShape.Center

		Public Overridable Sub Print(output As TextWriter) Implements IShape.Print
			output.WriteLine($"{Me.Color} shape")
		End Sub
	End Class
End Namespace
