using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RecuperationGui.ViewModel
{
    public class GasCompositionItem
    {
        public GasCompositionItem(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; set; }
        public double Value { get; set; }
    }

    public class ReadyToUseGas
    {
        public string Name { get; set; }
        public List<GasCompositionItem> Items { get; set; }
    }
}
