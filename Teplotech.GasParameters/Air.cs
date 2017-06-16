using System;
namespace Teplotech.GasParameters
{
    public class Air : IGas
    {
        public double GetGasEnthalpy(double temperature)
        {
            return 44.906 * Math.Pow(temperature / 100, 2) + 56.289 * (temperature / 100) + 57.479;
        }

        public double GetDensityByTemperature(double temperature)
        {
            return 0.0013 * Math.Pow(temperature / 100 - 7, 2) - 0.0301 * (temperature / 100 - 7) + 0.3567;
        }

        public double GetThermalCapacity(double temperature)
        {
            throw new NotImplementedException();
        }

        public double GetVolumeByWeight(double w, double T)
        {
            return w / GetDensityByTemperature(T);
        }
    }
}
