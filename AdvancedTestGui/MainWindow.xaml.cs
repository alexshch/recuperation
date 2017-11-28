using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace AdvancedTestGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Settings = new List<Setting>();
            Settings.Add(new Setting("Elevation", 100));
            Settings.Add(new Setting("Expiration", 200));
            Settings.Add(new Setting("Urucucidodation", 300));

            DataContext = this;
        }
        public List<Setting> Settings { get; private set; }
    }
}
