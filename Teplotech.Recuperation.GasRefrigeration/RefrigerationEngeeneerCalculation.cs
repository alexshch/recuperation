using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Teplotech.GasParameters;
namespace Teplotech.Recuperation.GasRefrigeration
{
    public class RefrigerationEngeeneerCalculation
    {
        private readonly Air _air;
        private readonly AnyFume _anyFume;
        public RefrigerationEngeeneerCalculation()
        {
            _air = new Air();
            _anyFume = new AnyFume();
        }
        // 
        // кДж/час
        /// <summary>
        /// сколько тепала отдает газ чтобы остыть до температуры T2
        ///  ΔQ = W*Срср*ΔТ; T1 > T2
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <param name="W">кГ/час</param>
        /// <returns></returns>
        public double GetDeltaQFume(double T1, double T2, double W)
        {
            return W * (_anyFume.GetThermalCapacity(T1) + _anyFume.GetThermalCapacity(T2)) / 2 * Math.Abs(T2 - T1);
        }

        //
        /// <summary>
        /// сколько тепла нужно взять воздуху что бы нагреться до температуры T2;
        /// T1 < T2
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <param name="W">кГ/час</param>
        /// <returns></returns>
        public double GetDeltaGAir(double T1, double T2, double W)
        {
            return W * (_air.GetGasEnthalpy(T2) - _air.GetGasEnthalpy(T1));
        }

        // подконка объемов в к "0" ΔQв-ΔQд

        public double GetDifference(double Tghot, double Tgcold, double Wghot, double Tacold, double Wacold)
        {
            var deltaQair = GetDeltaGAir(Tacold, Tgcold, Wacold);
            var deltaQfume = GetDeltaQFume(Tghot, Tgcold, Wghot);
            return deltaQair - deltaQfume;
        }

        // недостачи воздуха в %, подконка объемов в к "0" (1-ΔQ/ΔQ)*100
        public double GetAirShortage(double Tghot, double Tgcold, double Wghot, double Tacold, double Wacold)
        {
            return (1 - GetDeltaGAir(Tacold, Tgcold, Wacold) / GetDeltaQFume(Tghot, Tgcold, Wghot)) * 100;
        }

        // подконка объемов в к "1" ΔQв/ΔQд
        public double GetRelation(double Tghot, double Tgcold, double Wghot, double Tacold, double Wacold)
        {
            return GetDeltaGAir(Tacold, Tgcold, Wacold) / GetDeltaQFume(Tghot, Tgcold, Wghot);
        }

        public double GetNeedAirWeight(double Tghot, double Tgcold, double Wghot, double Tacold)
        {
            return GetDeltaQFume(Tghot, Tgcold, Wghot)/(_air.GetGasEnthalpy(Tgcold) - _air.GetGasEnthalpy(Tacold));
        }

    }
}
