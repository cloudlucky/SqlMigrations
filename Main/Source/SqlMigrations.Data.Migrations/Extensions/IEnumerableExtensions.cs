using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlMigrations.Data.Migrations.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void Each<T>(this IEnumerable<T> ts, Action<T, int> action)
        {
            var num = 0;
            foreach (T obj in ts)
            {
                action(obj, num++);
            }
        }

        public static void Each<T>(this IEnumerable<T> ts, Action<T> action)
        {
            foreach (var obj in ts)
            {
                action(obj);
            }
        }

        public static void Each<T, S>(this IEnumerable<T> ts, Func<T, S> action)
        {
            foreach (T obj in ts)
            {
                var s = action(obj);
            }
        }

        public static string Join<T>(this IEnumerable<T> ts, Func<T, string> selector = null, string separator = ", ")
        {
            selector = selector ?? (t => t.ToString());
            return string.Join(separator, ts.Select(selector));
        }
    }
}
