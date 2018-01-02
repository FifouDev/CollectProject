using CoPro.Models;
using CoPro.ViewModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoPro.Views
{
    public partial class MainPage : ContentPage
    {

        public MainViewModel Viewmodel { get; } = App.Locator.Main;
        public MainPage()
        {       
            InitializeComponent();
            BindingContext = Viewmodel;
            Viewmodel.Navigation = Navigation;
        }     
    }
}
