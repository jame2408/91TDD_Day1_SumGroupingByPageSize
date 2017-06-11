using System;
using System.Collections.Concurrent;
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
            var target = new GroupingByPageSize();

            //Act
            var actual = target.GetSum(pagesize: 3, groupName: nameof(Order.Cost)).ToList();

            //Assert
            var expected = new List<int>{ 6, 15, 24, 21};
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    internal class Order
    {
        public int Id { get; set; }

        public int Cost { get; set; }

        public int Revenue { get; set; }

        public int SellPrice { get; set; }

    }

    class GroupingByPageSize
    {
        public IEnumerable<int> GetSum(int pagesize, string groupName)
        {
            throw new NotImplementedException();
        }
    }
}
