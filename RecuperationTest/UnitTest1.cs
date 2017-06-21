using System;
using System.Collections.Generic;
using System.Linq;
using Teplotech.Recuperation.GasRefrigeration;
using Xunit;
namespace RecuperationTest
{
    
    public class UnitTest1
    {
        private double eps = 0.3;

        [Fact]
        public void TestDeletaQDifference()
        {
            var calc = new RefrigerationEngeeneerCalculation();
            var diff = calc.GetDifference(1350, 1000, 8845, 0, 819);
            var rel = calc.GetRelation(1350, 1000, 8845, 0, 819);
            var shortage = calc.GetAirShortage(1350, 1000, 8845, 0, 819);

            var w1 = calc.GetNeedAirWeight(1350, 1000, 8845, 0);
            Assert.True(Math.Abs(w1 - 819) < eps);
            Assert.True(Math.Abs(diff - 4047) < eps);
        }


        [Fact]
        public void FindNearestNode()
        {
            List<double> ls = new List<double> {0.2, 0.4, 0.8, 1, 2, 4, 6};
            var point = 0.5;

            var foundP = FindNearest(0, ls.Count - 1, point, ls);
            Assert.Equal(foundP, 0.4, 3);

            foundP = FindNearest(0, ls.Count - 1, 0.7, ls);
            Assert.Equal(foundP, 0.8, 3);

            foundP = FindNearest(0, ls.Count - 1, 5, ls);
            Assert.Equal(foundP, 6, 3);

        }

        private double FindNearest(int i, int j,  double p, List<double> list)
        {
            int k = (i + j) / 2;

            if (k == i || k == j)
            {
                return Math.Abs(list[i] - p) < Math.Abs(list[j] - p) ? list[i] : list[j];
            }

            if (list[k] >= p)
            {
                j = k;
                return FindNearest(i, j, p, list);
            }
            else
            {
                i = k;
                return FindNearest(i, j, p, list);
            }
        }

        

    }
}
