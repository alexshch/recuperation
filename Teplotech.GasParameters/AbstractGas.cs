using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teplotech.GasParameters
{
    public abstract class AbstractGas
    {
        protected abstract double Air { get; set; }
        protected abstract double N2 { get; set; }
        protected abstract double NO2 { get; set; }
        protected abstract double O2 { get; set; }
        protected abstract double H2O { get; set; }
        protected abstract double CO { get; set; }
        protected abstract double SO2 { get; set; }
        protected AbstractGas(double air, double n2, double no2, double o2, double h2o, double co, double so2)
        {
            Air = air;
            N2 = n2;
            NO2 = no2;
            O2 = o2;
            H2O = h2o;
            CO = co;
            SO2 = so2;
        }
    }
}
