using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Collections
{
	class Element
	{
		public object Data { get; set; }

		public Element(object data)
		{
			this.Data = data;
		}

		public override string ToString()
		{
			return "My element";
		}
	}
}
