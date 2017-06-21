using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teplotech.Recuperation.HeatBalance
{
    internal class EpsilonDeltaT
    {
        private readonly List<DeltaEpsCorrection> _corectionList;

        public EpsilonDeltaT()
        {
            _corectionList = new List<DeltaEpsCorrection>
            {
                new DeltaEpsCorrection
                {
                    R = 4.0,
                    function = x => -146.67 * x * x * x + 48 * x * x - 5.0333 * x + 1.152
                },
                new DeltaEpsCorrection
                {
                    R = 3.0,
                    function = x =>  -7217.3 * Math.Pow(x,5) + 5853.9 * Math.Pow(x, 4) - 1787.4 * Math.Pow(x, 3) + 252.56 * Math.Pow(x, 2) - 16.382 * x + 1.3668
                },
                new DeltaEpsCorrection
                {
                    R = 2.0,
                    function = x => -7.1143 * Math.Pow(x, 2) + 3.4242 * x + 0.5604
                },
                new DeltaEpsCorrection
                {
                    R = 1.5,
                    function = x => -14.75* Math.Pow(x, 3) + 14.824 * Math.Pow(x, 2) - 5.3718 * x + 1.6231
                },
                new DeltaEpsCorrection
                {
                    R = 1.0,
                    function = x => -3.3907 * Math.Pow(x, 3) + 3.6213 * Math.Pow(x, 2)- 1.678 * x + 1.2585
                },
                new DeltaEpsCorrection
                {
                    R = 0.8,
                    function = x => -2.8396 * Math.Pow(x, 3)  + 3.1387 * Math.Pow(x, 2) - 1.3637 * x + 1.1887
                },
                new DeltaEpsCorrection
                {
                    R = 0.6,
                    function = x =>  -4.7271 * Math.Pow(x, 3) + 7.0605 * Math.Pow(x, 2) - 3.6464 * x + 1.5912
                },
                new DeltaEpsCorrection
                {
                    R = 0.4,
                    function = x => -3.3814 * Math.Pow(x, 3) + 4.582 * Math.Pow(x, 2) - 2.0003 * x + 1.2454
                },
                new DeltaEpsCorrection
                {
                    R = 0.2,
                    function = x => -18.249 * Math.Pow(x, 4) + 40.776 * Math.Pow(x, 3) - 32.743 * Math.Pow(x, 2) + 11.043 * x - 0.3223
                },

            };

            _corectionList.Sort((x, y) => x.R.CompareTo(y.R));
        }
        public double GetEpsilonDeltaT(double p, double r)
        {
            return TakeNearestNode(r) (p);
        }

        private Func<double, double> TakeNearestNode(double R)
        {
            return FindNearest(0, _corectionList.Count - 1, R, _corectionList).function;
        }


        private DeltaEpsCorrection FindNearest(int i, int j, double R, List<DeltaEpsCorrection> list)
        {
            int k = (i + j) / 2;

            if (k == i || k == j)
            {
                return Math.Abs(list[i].R - R) < Math.Abs(list[j].R - R) ? list[i] : list[j];
            }

            if (list[k].R >= R)
            {
                j = k;
                return FindNearest(i, j, R, list);
            }
            else
            {
                i = k;
                return FindNearest(i, j, R, list);
            }
        }
        class DeltaEpsCorrection
        {
            public double R { get; set; }
            public Func<double, double> function { get; set; }
        }

    }
}
