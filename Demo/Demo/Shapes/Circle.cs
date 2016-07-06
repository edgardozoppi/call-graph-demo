using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shapes
{
	class Circle : Shape
	{
		private Point center;

		public Circle(Point center, int radius)
		{
			this.center = center;
			this.Radius = radius;
		}

		public int Radius { get; private set; }

		public override Point Center
		{
			get { return center; }
		}

		public override void Print(TextWriter output)
		{
			output.WriteLine($"{this.Color} circle at {this.Center} of radius {this.Radius}");
		}
	}
}
