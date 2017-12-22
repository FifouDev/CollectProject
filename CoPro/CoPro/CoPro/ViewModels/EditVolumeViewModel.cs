using CoPro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoPro.ViewModels
{
    public class EditVolumeViewModel : ViewModelBase
    {
        private string _volumeName;
        private string _volumeDescription;
        private INavigation _navigation;

        public EditVolumeViewModel()
        {
            _volumeName = null;
            _volumeDescription = null;         
        }

        public string VolumeName
        {
            get { return _volumeName; }
            set { Set(ref _volumeName, value); }
        }
        public string VolumeDecription
        {
            get { return _volumeDescription; }
            set { Set(ref _volumeDescription, value); }
        }

        public INavigation Navigation
        {
            get { return _navigation; }
            set { Set(ref _navigation, value); }
        }

        private ICommand _editVolumeCommand;
        public ICommand EditVolumeCommand
        {
            get { return _editVolumeCommand ?? (_editVolumeCommand = new RelayCommand(ExecuteEditCommand)); }
        }

        private async void ExecuteEditCommand()
        {
            if (_volumeName != null && _volumeDescription != null)
            {
                var editVolume = new Volume { Name = _volumeName, Description = _volumeDescription };
                App.Locator.Main.AddVolume(editVolume);             
                await Navigation.PopAsync();
            }
        }
    }
}
