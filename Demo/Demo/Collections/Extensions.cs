using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Collections
{
	static class Extensions
	{
		public static IEnumerable<T> Where<T>(this IEnumerable<T> self, Func<T, bool> condition)
		{
			var result = new List<T>();

			foreach (var elem in self)
			{
				if (condition(elem))
				{
					result.Add(elem);
				}
			}

			return result;
		}

		public static IEnumerable<R> Select<T, R>(this IEnumerable<T> self, Func<T, R> action)
		{
			var result = new List<R>();

			foreach (var elem in self)
			{
				var r = action(elem);
				result.Add(r);
			}

			return result;
		}

		public static int Count<T>(this IEnumerable<T> self)
		{
			var result = 0;

			foreach (var elem in self)
			{
				result++;
			}

			return result;
		}
	}
}
