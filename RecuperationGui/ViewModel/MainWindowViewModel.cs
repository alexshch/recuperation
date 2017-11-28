using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RecuperationGui.Model;

namespace RecuperationGui.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {

        private ApplicationModel _applicationModel;

        public MainWindowViewModel()
        {
            _applicationModel = ApplicationModel.GetAplicationModel();
            _compositionItems = new List<GasCompositionItem>
            {
                new GasCompositionItem("вода", 25),
                new GasCompositionItem("огонь", 25),
                new GasCompositionItem("воздух", 25),
                new GasCompositionItem("земля", 25)
            };
        }
        public List<GasCompositionItem> GasCompositionItems
        {
            get { return _compositionItems; }
            set
            {
                if (value == _compositionItems) return;
                _compositionItems = value;
                OnPropertyChanged();
            }
        }



        private List<GasCompositionItem> _compositionItems;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
