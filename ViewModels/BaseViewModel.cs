using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace svendeMobil.ViewModels
{
    public partial class BaseViewModel : INotifyPropertyChanged
    {
        public object Parameter { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNavigatedFrom()
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigatedToEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
