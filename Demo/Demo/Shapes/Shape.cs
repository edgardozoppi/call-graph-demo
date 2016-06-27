using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
	abstract class Shape : IShape
	{
		public Color Color { get; set; }
		public abstract Point Center { get; }

		public virtual void Print(TextWriter output)
		{
			output.WriteLine($"{this.Color} shape");
		}
	}
}
