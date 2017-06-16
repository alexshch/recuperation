using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teplotech.GasParameters
{
    class GasMix : IGas
    {
        private IEnumerable<PureGasWithPersantage> _gasMixList;
        public GasMix(IEnumerable<PureGasWithPersantage> gasMixList)
        {
            _gasMixList = gasMixList;
        }

        public double GetGasEnthalpy(double temperature)
        {
            return _gasMixList.Sum(gas => gas.Persantage * gas.Gas.GetGasEnthalpy(temperature));
        }

        public double GetDensityByTemperature(double temperature)
        {
            return _gasMixList.Sum(gas => gas.Persantage * gas.Gas.GetDensityByTemperature(temperature));
        }

        public double GetThermalCapacity(double temperature)
        {
            return _gasMixList.Sum(gas => gas.Persantage * gas.Gas.GetThermalCapacity(temperature));
        }

        public double GetVolumeByWeight(double w, double T)
        {
            return w / GetDensityByTemperature(T);
        }
    }

    class PureGasWithPersantage
    {
        public double Persantage { get; set; }
        public IGas Gas { get; set; }
    }
}
