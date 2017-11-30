using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teplotech.GasParameters
{
    public class GasN2 : IGas
    {
        public string Name => "N2";
        public double GetGasEnthalpy(double temperature)
        {
            throw new NotImplementedException();
        }

        public double GetDensityByTemperature(double temperature)
        {
            throw new NotImplementedException();
        }

        public double GetThermalCapacity(double temperature)
        {
            throw new NotImplementedException();
        }

        public double GetVolumeByWeight(double w, double T)
        {
            throw new NotImplementedException();
        }
    }
}
