using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PAIN_wpf.Model
{
    class Car : INotifyPropertyChanged
    {
        private string brand;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Brand
        {
            get { return brand; }
            set { brand = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Brand")); }
        }

        private string type;

        public string Type
        {
            get { return type;  }
            set { type = value;  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Type"));}
        }

        private int maxSpeed; 
        public int MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaxSpeed"));}
        }

        private int productionDate;


        public int ProductionDate
        {
            get { return productionDate; }
            set { productionDate = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductionDate"));}
        }

        public Car(string brand, string type, int maxSpeed, int productionDate)
        {
            this.brand = brand;
            this.type = type;
            this.maxSpeed = maxSpeed;
            this.productionDate = productionDate;
        }
    }
}
