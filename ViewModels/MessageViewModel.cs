using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace svendeMobil.ViewModels
{
    public partial class MessageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string subject;
        
        [ObservableProperty]
        private string body;

        public string Names { get; set; }



    }
}
