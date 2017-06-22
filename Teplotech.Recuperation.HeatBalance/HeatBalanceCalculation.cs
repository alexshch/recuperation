using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teplotech.GasParameters;

namespace Teplotech.Recuperation.HeatBalance
{
    public class HeatBalanceCalculation
    {

        private IGas _air;
        private IGas _fume;
        private double _vGasInput;
        private double _tGasInput;
        private double _vAirInput;
        private double _tAirInput;
        private double _tAirOutput;
        private double _lossFactor;

        public HeatBalanceCalculation(IGas air, IGas mixGas, double vGasInput, double tGasInput, double vAirInput, double tAirInput, double tAirOutput, double lossFactor = 0.98)
        {
            _air = air;
            _fume = mixGas;
            _vGasInput = vGasInput;
            _tGasInput = tGasInput;
            _vAirInput = vAirInput;
            _tAirInput = tAirInput;
            _tAirOutput = tAirOutput;
            _lossFactor = lossFactor;
        }

        public double GetOutputGasTemperature()
        {
            return GetOutputGasTemperature(_vGasInput, _tGasInput, _vAirInput, _tAirInput, _tAirOutput);
        }

        public double GetAverageTemperaturePressure(double tFumeInput, double tFumeOutput, double tAirInput, double tAirOutput)
        {
            var deltaTcp = ((tFumeInput - tAirOutput) - (tFumeOutput - tAirInput)) /
                           Math.Log((tFumeInput - tAirOutput) / (tFumeOutput - tAirInput)) *
                           GetEpsilonDeltaT(tFumeInput, tFumeOutput, tAirInput, tAirOutput);

            return deltaTcp;
        }

        private double GetEpsilonDeltaT(double tFumeInput, double tFumeOutput, double tAirInput, double tAirOutput)
        {
            var p = (tAirOutput - tAirInput) / (tFumeInput - tAirInput);
            var r = (tFumeInput - tFumeOutput) / (tAirOutput - tAirInput);
            var eps = GetEpsilonDeltaT(p, r);
            return eps;
        }

        // раcсчитываем epsdeltat
        private double GetEpsilonDeltaT(double p, double r)
        {
            var eps = new EpsilonDeltaT();
            return eps.GetEpsilonDeltaT(p, r);
        }

        /// <summary>
        /// расчет тепературы дыма на выходе
        /// </summary>
        /// <param name="vGasInput">объем газа на входе в нм3 </param>
        /// <param name="tGasInput">температура газа на входе в градусах</param>
        /// <param name="vAirInput">объем воздуха на входе в нм3</param>
        /// <param name="tAirInput">температура воздуха на входе в С</param>
        /// <param name="tAirOutput">температура воздуха на выходе в С</param>
        /// <param name="lossFactor">коэффициент потерь тепла</param>
        /// <returns>Темпепратура дым на выходе установки </returns>
        private double GetOutputGasTemperature(double vGasInput, double tGasInput, double vAirInput, double tAirInput, double tAirOutput)
        {
            // масса воздуха
            double weightAir = vAirInput * _air.GetDensityByTemperature(tAirOutput);
            // масса дыма
            double weightGas = vGasInput * _fume.GetDensityByTemperature(tGasInput);

            double cAirInput = _air.GetThermalCapacity(tAirInput);

            double cAirOutput = _air.GetThermalCapacity(tAirOutput);

            double cGasInput = _fume.GetThermalCapacity(tGasInput);
            //  ввиду того что средняя теплоемкость дыма в расчетах CgasInput - 0.1 - у нас она тоже будет с потолка

            return tGasInput - weightAir * ((cAirInput + cAirOutput) / 2) * (tAirOutput - tAirInput) / (weightGas * (cGasInput - 0.1));
        }


    }
}
