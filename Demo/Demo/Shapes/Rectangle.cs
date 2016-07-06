using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shapes
{
	class Rectangle : Shape
	{
		protected Rectangle()
		{
		}

		public Rectangle(Point p1, Point p2)
		{
			this.Point1 = p1;
			this.Point2 = p2;
		}

		public Point Point1 { get; protected set; }
		public Point Point2 { get; protected set; }

		public override Point Center
		{
			get
			{
				var xs = this.Point1.X + this.Point2.X;
				var ys = this.Point1.Y + this.Point2.Y;

				return new Point(xs / 2, ys / 2);
			}
		}

		public int Width
		{
			get { return Math.Abs(this.Point1.X - this.Point2.X);  }
		}

		public int Height
		{
			get { return Math.Abs(this.Point1.Y - this.Point2.Y); }
		}

		public override void Print(TextWriter output)
		{
			output.WriteLine($"{this.Color} rectangle at {this.Center} of width {this.Width} and height {this.Height}");
		}
	}
}
