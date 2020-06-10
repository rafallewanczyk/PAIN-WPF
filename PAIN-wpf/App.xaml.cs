using PAIN_wpf.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public MVVM.IWindowService WindowService { get; } = new MVVM.WindowService();
        private CarsModel CarsModel { get; } = new CarsModel();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModel.CarsViewModel carsViewModel = new ViewModel.CarsViewModel(CarsModel);
            WindowService.Show(carsViewModel); 
        }
    }
}
