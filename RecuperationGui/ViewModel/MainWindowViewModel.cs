using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using RecuperationGui.Model;

namespace RecuperationGui.ViewModel
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public string ModelState { get; set; }
        public bool ModelIsValid { get; set; }
        private ApplicationModel _applicationModel;
        public ICommand UpdateSelectedGas1ScriptCommand { get; set; }
        public ICommand UpdateSelectedGas2ScriptCommand { get; set; }

        public MainWindowViewModel()
        {
            _applicationModel = ApplicationModel.GetAplicationModel();
            UpdateSelectedGas1ScriptCommand = new RelayCommand(UpdateSelectedGas1);
            UpdateSelectedGas2ScriptCommand = new RelayCommand(UpdateSelectedGas2);

            _gas1CompositionItems = new List<GasCompositionItem>(GasComponents.Components);

            _gas2CompositionItems = new List<GasCompositionItem>(GasComponents.Components);


            ReadyToUseGasList1 = new ObservableCollection<ReadyToUseGas>(ReadyGasses.Gases);
            ReadyToUseGasList2 = new ObservableCollection<ReadyToUseGas>(ReadyGasses.Gases);

        }

        private void UpdateSelectedGas1(object selectedProps)
        {
            var selectedGasList = ((IList)selectedProps).Cast<GasCompositionItem>().ToList();
            var gasMix = string.Join("\n", selectedGasList.Select(s => $"{s.Name,-8}: {s.Value}%"));
            ChosenGas1Components = gasMix;
        }

        private void UpdateSelectedGas2(object selectedProps)
        {
            var selectedGasList = ((IList)selectedProps).Cast<GasCompositionItem>().ToList();
            var gasMix = string.Join("\n", selectedGasList.Select(s => $"{s.Name,-8}: {s.Value}%"));
            ChosenGas2Components = gasMix;

        }

        private List<GasCompositionItem> _gas1CompositionItems;
        public List<GasCompositionItem> Gas1CompositionItems
        {
            get { return _gas1CompositionItems; }
            set
            {
                if (value == _gas1CompositionItems) return;
                _gas1CompositionItems = value;
                OnPropertyChanged();
            }
        }

        private string _chosenGas1Components;
        public string ChosenGas1Components
        {
            get { return _chosenGas1Components; }
            set
            {
                if (value == _chosenGas1Components) return;
                _chosenGas1Components = value;
                Task.Run(() => SetScripts());
                OnPropertyChanged();
            }
        }


        private List<GasCompositionItem> _gas2CompositionItems;
        public List<GasCompositionItem> Gas2CompositionItems
        {
            get { return _gas2CompositionItems; }
            set
            {
                if (value == _gas2CompositionItems) return;
                _gas2CompositionItems = value;
                OnPropertyChanged();
            }
        }

        private string _chosenGas2Components;
        public string ChosenGas2Components
        {
            get { return _chosenGas2Components; }
            set
            {
                if (value == _chosenGas2Components) return;
                _chosenGas2Components = value;
                Task.Run(() => SetScripts());
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReadyToUseGas> ReadyToUseGasList1 { get; set; }
        public ObservableCollection<ReadyToUseGas> ReadyToUseGasList2 { get; set; }
        private ReadyToUseGas _selectedGas1;

        public ReadyToUseGas SelectedReadyGas1
        {
            get { return _selectedGas1; }
            set
            {
                if (value == _selectedGas1) return;
                _selectedGas1 = value;
                ChangeSelectedGas1(value);
            }
        }

        private void ChangeSelectedGas1(ReadyToUseGas gas)
        {
            try
            {
                ModelState = "Газ выбран";
                var newItems = Gas1CompositionItems.Select(item => new GasCompositionItem(item.Name, gas.Items.FirstOrDefault(i => i.Name == item.Name)?.Value ?? 0)).ToList();
                Gas1CompositionItems = newItems;
            }
            catch (Exception ex)
            {

            }
        }
        private ReadyToUseGas _selectedGas2;
        public ReadyToUseGas SelectedReadyGas2
        {
            get { return _selectedGas2; }
            set
            {
                if (value == _selectedGas2) return;
                _selectedGas2 = value;
                ChangeSelectedGas2(value);
            }
        }

        private void ChangeSelectedGas2(ReadyToUseGas gas)
        {
            try
            {
                ModelState = "Газ выбран";
                var newItems = Gas2CompositionItems.Select(item => new GasCompositionItem(item.Name, gas.Items.FirstOrDefault(i => i.Name == item.Name)?.Value ?? 0)).ToList();
                Gas2CompositionItems = newItems;
            }
            catch (Exception ex)
            {

            }
        }

        private void SetScripts()
        {
            ModelState = "Проверка состава газа на сумму 100...";

            ModelIsValid = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
