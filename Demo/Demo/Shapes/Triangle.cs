using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shapes
{
	class Triangle : Shape
	{
		public Triangle(Point p1, Point p2, Point p3)
		{
			this.Point1 = p1;
			this.Point2 = p2;
			this.Point3 = p3;
		}

		public Point Point1 { get; private set; }
		public Point Point2 { get; private set; }
		public Point Point3 { get; private set; }

		public override Point Center
		{
			get
			{
				var xs = this.Point1.X + this.Point2.X + this.Point3.X;
				var ys = this.Point1.Y + this.Point2.Y + this.Point3.Y;

				return new Point(xs / 3, ys / 3);
			}
		}

		public override void Print(TextWriter output)
		{
			output.WriteLine($"{this.Color} triangle at {this.Center}");
		}
	}
}
