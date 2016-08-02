
Imports Demo.Chat
Imports Demo.Collections
Imports Demo.Shapes
Imports System.Collections.Generic
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo
	Class Program
		Shared Sub Main(args As String())
			Shapes()
			Chat()
			Collections()
		End Sub

		Private Shared Sub Shapes()
			Dim center = New Point(0, 0)
			Dim circle As IShape = New Circle(center, 5)

			circle.Color = Color.Red    ' Shape.Color.set

			circle.Print(Console.Out)   ' Circle.Print

			Dim square As Shape = New Square(center, 2)

			square.Print(Console.Out)   ' Square.Print

			Dim squareOrCircle As IShape = If(square.Center.X > circle.Center.X, square, circle)    ' Rectangle.Center.get, Circle.Center.get

			squareOrCircle.Print(Console.Out)   ' Square.Print or Circle.Print

			Dim rectangle = DirectCast(squareOrCircle, Rectangle)

			rectangle.Print(Console.Out)    ' Square.Print
		End Sub

		Private Shared Async Sub Chat()
			Dim server = New Server()
			Dim client = New Client()

			Dim result1 As MessageResult = Await client.ConnectAsync(server)
			result1.ToString()  ' SuccessMessageResult.ToString

			Dim result2 As MessageResult = Await server.SendAsync("Hello from server!")
			result2.ToString()  ' SuccessMessageResult.ToString or ErrorMessageResult.ToString

			Dim task As Task(Of MessageResult) = client.SendAsync($"Hello from client {client.Id}!")
			Dim result3 As MessageResult = Await task
			result3.ToString()  ' ErrorMessageResult.ToString
		End Sub

		Private Shared Sub Collections()
			Dim input As IEnumerable(Of Element) = New HashSet(Of Element)()
			Dim output As IEnumerable(Of Element) = input.Where(Function(e) e.Data IsNot Nothing)

			Console.WriteLine(output.Count())

			Dim dataSelector As Func(Of Element, Object) = Function(e) e.Data
			Dim data = output.[Select](dataSelector)

			Console.WriteLine(data.Count())

			Dim stringSelector As Func(Of Element, String) = GetSelector()
			Dim strings = output.[Select](stringSelector)

			Console.WriteLine(strings.Count())
		End Sub

		Private Shared Function GetSelector() As Func(Of Element, String)
			Return Function(e)
					   Return e.ToString()
				   End Function
		End Function
	End Class
End Namespace
