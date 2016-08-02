using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shapes
{
	class Square : Rectangle
	{
		public Square(Point p1, int size)
		{
			this.Point1 = p1;
			this.Point2 = new Point(p1.X + size, p1.Y + size);
		}

		public override void Print(TextWriter output)
		{
			output.WriteLine($"{this.Color} square at {this.Center} of width {this.Width} and height {this.Height}");
		}
	}
}
