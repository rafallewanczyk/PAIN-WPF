using System;
using System.ComponentModel; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAIN_wpf.Model;
using PAIN_wpf.MVVM;
using System.Windows;
using System.Security.RightsManagement;
using System.Windows.Data;
using PAIN_wpf.View;
using System.Collections.ObjectModel;

namespace PAIN_wpf.ViewModel {
    class CarsViewModel : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CarsModel CarsModel {get;}
        private readonly CollectionViewSource collectionViewSourceCars;
        private Car selectedCar; 

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                EditCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar))); 
            }
        }
        
        public ICollectionView Cars { get; }

        private RelayCommand<object> addCommand; 
        public RelayCommand<object> AddCommand => addCommand = addCommand ?? new RelayCommand<object>(o => AddCar());

        private RelayCommand<object> editCommand;
        public RelayCommand<object> EditCommand => editCommand = editCommand ?? new RelayCommand<object>(o => EditCar());

        private RelayCommand<object> deleteCommand;
        public RelayCommand<object> DeleteCommand => deleteCommand = deleteCommand ?? new RelayCommand<object>(o => DeleteCar()); 

        private RelayCommand<object> newWindowCommand;
        public RelayCommand<object> NewWindowCommand=> newWindowCommand= newWindowCommand?? new RelayCommand<object>(o =>NewWindow()); 

        public Action Close { get ; set ; }

        private string filterText = ""; 
        public string FilterText
        {
            get { return filterText; }
            set
            {
                filterText = value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterText)));
            }
        }

        private string filterCategory= "";
        public string FilterCategory
        {
            get { return filterCategory; }
            set
            {
                filterCategory= value;
                UpdateFilter();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FilterCategory)));
            }
        }
        private void UpdateFilter()
        {
            collectionViewSourceCars.View.Refresh(); 
        }

        private bool FilterCar(Car car)
        {
            if (filterCategory.Equals("Brand"))
            {
                return car.Brand.Contains(FilterText);
            }
            else if (filterCategory.Equals("Type"))
            {
                return car.Type.Contains(FilterText);
            }
            else if (filterCategory.Equals("Max Speed"))
            {
                return car.MaxSpeed.ToString().Contains(FilterText);
            }
            else if (filterCategory.Equals("Production Year"))
            {
                return car.ProductionDate.ToString().Contains(FilterText);
            }
            return true; 
        }

        public void AddCar()
        {
            CarViewModel carViewModel = new CarViewModel(CarsModel, null);
            ((App)Application.Current).WindowService.ShowDialog(carViewModel); 
        }

        public void EditCar()
        {
            if(selectedCar != null)
            {
                CarViewModel carViewModel = new CarViewModel(CarsModel, selectedCar);
                ((App)Application.Current).WindowService.ShowDialog(carViewModel); 
            }
        }


        public void DeleteCar()
        {
            if(selectedCar != null)
            {
                CarsModel.Cars.Remove(selectedCar);
                selectedCar = null; 
            }
        }

        public void NewWindow()
        {
            CarsViewModel carsViewModel = new CarsViewModel(CarsModel); 
            ((App)Application.Current).WindowService.Show(carsViewModel); 
        }

        public CarsViewModel(CarsModel carsModel)
        {
            CarsModel = carsModel;
            collectionViewSourceCars = new CollectionViewSource
            {
                Source = CarsModel.Cars
            };
            collectionViewSourceCars.View.Filter = (o) => FilterCar((Car)o); 
            Cars = collectionViewSourceCars.View;

        }
    }
}
