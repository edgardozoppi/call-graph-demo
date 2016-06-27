using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			var center = new Point(0, 0);
			IShape circle = new Circle(center, 5);

			circle.Color = Color.Red; // Circle.Color.set

			circle.Print(Console.Out); // Circle.Print

			Shape square = new Square(center, 2);

			square.Print(Console.Out); // Square.Print

			IShape squareOrCircle = square.Center.X > circle.Center.X ? square : circle;

			squareOrCircle.Print(Console.Out); // Square.Print or Circle.Print

			var rectangle = (Rectangle)squareOrCircle;

			rectangle.Print(Console.Out); // Square.Print
		}
	}
}
