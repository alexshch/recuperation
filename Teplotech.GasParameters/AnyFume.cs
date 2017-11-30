using System;

namespace Teplotech.GasParameters
{
    // 13 % СО2,  11 % Н2О,  76 % N2
    public class AnyFume : IGas
    {
        public string Name => "дым";
        public double GetGasEnthalpy(double temperature)
        {
            throw new NotImplementedException();
        }

        public double GetDensityByTemperature(double temperature)
        {
            return 0.0179 * Math.Pow(temperature / 100, 2) - 0.2307 * (temperature / 100) + 1.153;
        }

        public double GetThermalCapacity(double temperature)
        {
            return 0.0167 * (temperature / 100 - 8) + 1.273;
        }

        public double GetVolumeByWeight(double w, double T)
        {
            return w / GetDensityByTemperature(T);
        }
    }
}
