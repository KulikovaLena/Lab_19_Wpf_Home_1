using Lab_19_Wpf_Home_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab_19_Wpf_Home_1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double result;
        public double Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public ICommand ResultCommand { get; }

        private void OnResultCommandExecute(object p)
        {
            Result = Circle.ResultCircle(Radius);
        }
        private bool CanResultCommandExecuted(object p)
        {
            if (radius != 0)
                return true;
            else
                return false;
        }
        
        public MainWindowViewModel()
        {
            ResultCommand = new RelayComand(OnResultCommandExecute, CanResultCommandExecuted);
        }
    }
}
