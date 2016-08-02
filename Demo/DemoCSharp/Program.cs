using Demo.Chat;
using Demo.Collections;
using Demo.Shapes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			Shapes();
			Chat();
			Collections();
		}

		private static void Shapes()
		{
			var center = new Point(0, 0);
			IShape circle = new Circle(center, 5);

			circle.Color = Color.Red; // Shape.Color.set

			circle.Print(Console.Out); // Circle.Print

			Shape square = new Square(center, 2);

			square.Print(Console.Out); // Square.Print

			IShape squareOrCircle = square.Center.X > circle.Center.X ? square : circle; // Rectangle.Center.get, Circle.Center.get

			squareOrCircle.Print(Console.Out); // Square.Print or Circle.Print

			var rectangle = (Rectangle)squareOrCircle;

			rectangle.Print(Console.Out); // Square.Print
		}

		private static async void Chat()
		{
			var server = new Server();
			var client = new Client();

			MessageResult result1 = await client.ConnectAsync(server);
			result1.ToString(); // SuccessMessageResult.ToString

			MessageResult result2 = await server.SendAsync("Hello from server!");
			result2.ToString(); // SuccessMessageResult.ToString or ErrorMessageResult.ToString

			Task<MessageResult> task = client.SendAsync($"Hello from client {client.Id}!");
			MessageResult result3 = await task;
			result3.ToString(); // ErrorMessageResult.ToString
		}

		private static void Collections()
		{
			IEnumerable<Element> input = new HashSet<Element>();
			IEnumerable<Element> output = input.Where(e => e.Data != null);

			Console.WriteLine(output.Count());

			Func<Element, object> dataSelector = e => e.Data;
			var data = output.Select(dataSelector);

			Console.WriteLine(data.Count());

			Func<Element, string> stringSelector = GetSelector();
			var strings = output.Select(stringSelector);

			Console.WriteLine(strings.Count());
		}

		private static Func<Element, string> GetSelector()
		{
			return e =>
			{
				return e.ToString();
			};
		}
	}
}
