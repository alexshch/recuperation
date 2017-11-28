using System.Windows;
using System.Windows.Controls;

namespace AdvancedTestGui
{
        public class Setting
        {
            public Setting(string name, double value)
            {
                Name = name;
                Value = value;
            }

            public string Name { get; private set; }
            public object Value { get; set; }
        }

        public class SettingsTemplateSelector : DataTemplateSelector
        {
            public DataTemplate TextBoxTemplate { get; set; }

            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                Setting setting = item as Setting;
                return TextBoxTemplate;
            }
        }
}
