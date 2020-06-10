using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_wpf.Model
{
    class CarsModel
    {
        public ObservableCollection<Car> Cars { get; set; } = new ObservableCollection<Car>(); 

        public CarsModel()
        {
            Cars.Add(new Car("Ford", "osobowy", 200, 2010));
            Cars.Add(new Car("Fiat", "osobowy", 150, 2020));
            Cars.Add(new Car("Harley","motor", 250, 2010));
        }
    }
}
