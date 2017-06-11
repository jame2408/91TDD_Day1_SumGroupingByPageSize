using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SumGroupingByPageSize
{
    [TestClass]
    public class GetSumByPageSizeTest
    {
        [TestMethod]
        public void Pagesize_is_3_and_Sum_Cost_Should_be_6_15_24_21()
        {
            //Arrange
            var target = new Order();

            //Act
            var actual = target.GetOrders().GetSum(pagesize: 3, groupName: s => s.Cost).ToList();

            //Assert
            var expected = new List<int> { 6, 15, 24, 21 };
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    internal class Order
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public int Revenue { get; set; }

        public int SellPrice { get; set; }

        internal IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>()
            {
                new Order() { Id = 1, Cost = 1, Revenue = 11, SellPrice = 21},
                new Order() { Id = 2, Cost = 2, Revenue = 12, SellPrice = 22},
                new Order() { Id = 3, Cost = 3, Revenue = 13, SellPrice = 23},
                new Order() { Id = 4, Cost = 4, Revenue = 14, SellPrice = 24},
                new Order() { Id = 5, Cost = 5, Revenue = 15, SellPrice = 25},
                new Order() { Id = 6, Cost = 6, Revenue = 16, SellPrice = 26},
                new Order() { Id = 7, Cost = 7, Revenue = 17, SellPrice = 27},
                new Order() { Id = 8, Cost = 8, Revenue = 18, SellPrice = 28},
                new Order() { Id = 9, Cost = 9, Revenue = 19, SellPrice = 29},
                new Order() { Id = 10, Cost = 10, Revenue = 20, SellPrice = 30},
                new Order() { Id = 11, Cost = 11, Revenue = 21, SellPrice = 31}
            };
            return orders;
        }
    }

    static class GroupingByPageSize
    {
        public static IEnumerable<int> GetSum<T>(this IEnumerable<T> data, int pagesize, Func<T, int> groupName)
        {
            var orders = data.ToList();

            var index = 0;
            while (index <= orders.Count)
            {
                yield return orders.Skip(index).Take(pagesize).Sum(groupName);
                index += pagesize;
            }
        }
    }
}
