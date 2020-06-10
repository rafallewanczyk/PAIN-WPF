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

namespace PAIN_wpf.ViewModel {
    class CarsViewModel : IViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CarsModel CarsModel {get;}
        private readonly CollectionViewSource collectionViewSource;
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


        public Action Close { get ; set ; }

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

        public CarsViewModel(CarsModel carsModel)
        {
            CarsModel = carsModel;
            collectionViewSource = new CollectionViewSource
            {
                Source = CarsModel.Cars
            };
            Cars = collectionViewSource.View; 
        }
    }
}
