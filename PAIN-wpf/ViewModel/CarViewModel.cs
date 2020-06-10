using PAIN_wpf.Model;
using PAIN_wpf.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_wpf.ViewModel
{
    class CarViewModel : IViewModel
    {
        private CarsModel carsModel;
        private Car car { get; set; }

        public string Brand { get; set; }
        public string Type { get; set; }
        public int MaxSpeed { get; set; }
        public int ProductionDate { get; set; }
        public Action Close { get; set; }

        public CarViewModel(CarsModel carsModel, Car car)
        {
            this.carsModel = carsModel;
            this.car = car;

            if (car != null)
            {
                Brand = car.Brand;
                Type = car.Type;
                MaxSpeed = car.MaxSpeed;
                ProductionDate = car.ProductionDate;
            }

        }


        private RelayCommand<object> cancelCommand;
        public RelayCommand<object> CancelCommand => cancelCommand = cancelCommand ?? new RelayCommand<object>(o => Cancel());

        private RelayCommand<object> okCommand;
        public RelayCommand<object> OkCommand => okCommand = okCommand ?? new RelayCommand<object>(o => Ok());


        private void Cancel()
        {
            Close?.Invoke();
        }

        private void Ok()
        {
            if (car == null)
            {
                car = new Car(Brand, Type, MaxSpeed, ProductionDate);
                carsModel.Cars.Add(car);
            }
            else
            {
                car.Brand = Brand;
                car.Type = Type;
                car.MaxSpeed = MaxSpeed;
                car.ProductionDate = ProductionDate;
            }
            Close?.Invoke(); 
        }
        


    }
}
