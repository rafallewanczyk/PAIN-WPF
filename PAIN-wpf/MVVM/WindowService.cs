using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PAIN_wpf.MVVM
{
    public class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Console.WriteLine("execute"); 
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.ShowDialog();
        }
    }
}
