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
        public GasCompositionItem(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public object Value { get; set; }
    }

    public class GasItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            GasCompositionItem gasCompositionItem = item as GasCompositionItem;
            return TextBoxTemplate;
        }
    }
}
