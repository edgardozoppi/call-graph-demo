using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	enum Color
	{
		Black,
		White,
		Red,
		Green,
		Blue
	}

	struct Point
	{
		public int X;
		public int Y;

		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		public override string ToString()
		{
			return $"({this.X}, {this.Y})";
		}
	}

	interface IShape
	{
		Color Color { get; set; }
		Point Center { get; }

		void Print(TextWriter output);
	}
}
