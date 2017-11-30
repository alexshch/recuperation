using System.Dynamic;

namespace Teplotech.GasParameters
{
    public interface IGas
    {
        string Name { get; }
        /// <summary>
        /// Получаем энтальпию в кДж/кг 
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns>Cp</returns>

        double GetGasEnthalpy(double temperature);

        /// <summary>
        /// Получаем плотность газа для заданной температуры в кг/м^3
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns>кг/м^3</returns>
        double GetDensityByTemperature(double temperature);

        /// <summary>
        /// Получаем теплоемкость газа кДж/кГ·°С
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns>Cp</returns>
        double GetThermalCapacity(double temperature);

        double GetVolumeByWeight(double w, double T);

    }
}
