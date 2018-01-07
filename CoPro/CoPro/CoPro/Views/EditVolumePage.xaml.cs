using CoPro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPro.Views
{
    public partial class EditVolumePage : ContentPage
    {
        public EditVolumeViewModel Viewmodel { get; } = App.Locator.Edit;
        public EditVolumePage()
        {
            InitializeComponent();
            BindingContext = Viewmodel;
            Viewmodel.Navigation = Navigation;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();                    
        }
    }
}