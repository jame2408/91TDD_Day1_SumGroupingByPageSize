using System;
using System.Collections.Generic;
using System.Linq;

namespace SumGroupingByPageSize
{
    public static class GetSumByPageSize
    {
        public static IEnumerable<int> GetSum<TSource>(this IEnumerable<TSource> source, int pagesize, Func<TSource, int> selector)
        {
            //Todo: 將檢核提出來並取個好名字...
            if (pagesize <= 0)
            {
                throw new ArgumentException();
            }

            var index = 0;
            while (source.isMoveNext(index))
            {
                yield return source.Skip(index).Take(pagesize).Sum(selector);
                index += pagesize;
            }
        }

        private static bool isMoveNext<TSource>(this IEnumerable<TSource> source, int index)
        {
            return index <= source.Count();
        }
    }
}
