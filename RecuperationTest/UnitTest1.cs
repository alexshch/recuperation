using System;
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


    }
}
