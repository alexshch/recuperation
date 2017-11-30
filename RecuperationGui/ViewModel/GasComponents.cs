using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperationGui.ViewModel
{
    public class GasComponents
    {
        public static IEnumerable<GasCompositionItem> Components => new List<GasCompositionItem>
        {
            new GasCompositionItem("воздух", 0),
            new GasCompositionItem("дым", 0),
            new GasCompositionItem("N2", 0),
            new GasCompositionItem("O2", 0),
            new GasCompositionItem("CO2", 0),
            new GasCompositionItem("H2O", 0),
            new GasCompositionItem("CO", 0)
        };
    }
}
