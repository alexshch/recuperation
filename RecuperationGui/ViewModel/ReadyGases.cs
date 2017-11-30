

using System.Collections.Generic;

namespace RecuperationGui.ViewModel
{
    internal class ReadyGasses
    {
       public static IEnumerable<ReadyToUseGas> Gases => new List<ReadyToUseGas>
        {
            new ReadyToUseGas
            {
                Name = "воздух",
                Items = new List<GasCompositionItem>
                {
                    new GasCompositionItem("воздух", 100)
                }
            },
            new ReadyToUseGas
            {
                Name = "дым",
                Items = new List<GasCompositionItem>
                {
                    new GasCompositionItem("дым", 100)
                }
            },
            new ReadyToUseGas
            {
                Name = "природный газ",
                Items = new List<GasCompositionItem>
                {
                    new GasCompositionItem("N2", 71.579),
                    new GasCompositionItem("C02", 7.973),
                    new GasCompositionItem("O2", 3.168),
                    new GasCompositionItem("H2O", 17.28)
                }
            }
        };
    }
}
