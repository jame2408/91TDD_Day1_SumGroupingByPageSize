using System;
using System.Collections.Generic;
using System.Linq;

namespace SumGroupingByPageSize
{
    public static class GetSumByPageSize
    {
        public static IEnumerable<int> GetSum<TSource>(this IEnumerable<TSource> source, int pagesize, Func<TSource, int> selector)
        {
            CheckPageSize(pagesize);

            var index = 0;
            while (source.isMoveNext(index))
            {
                yield return source.Skip(index).Take(pagesize).Sum(selector);
                index += pagesize;
            }
        }

        private static void CheckPageSize( this int pagesize)
        {
            if (pagesize <= 0)
            {
                throw new ArgumentException();
            }
        }

        private static bool isMoveNext<TSource>(this IEnumerable<TSource> source, int index)
        {
            return index <= source.Count();
        }
    }
}
