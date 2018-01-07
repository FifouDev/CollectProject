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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //await App.VolumeRepository.DropAsync();     
            await Viewmodel.LoadVolumeAsync();
        }

        private void MissingVolumeListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                App.Locator.Edit.VolumeName = (e.SelectedItem as Volume).Name;
                App.Locator.Edit.VolumeDescription = (e.SelectedItem as Volume).Description;
                //App.Locator.Edit.Volume = (e.SelectedItem as Volume);
                Navigation.PushAsync(App.Locator.EditPage);
            }
        }
    }
}
