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
        private Volume _volume;
        private string _volumeName;
        private string _volumeDescription;
        private INavigation _navigation;

        public EditVolumeViewModel()
        {
            _volumeName = null;
            _volumeDescription = null;
            _volume = new Volume();
        }
        public string VolumeName
        {
            get { return _volumeName; }
            set { Set(ref _volumeName, value); }
        }

        public Volume Volume
        {
            get { return _volume; }
            set { Set(ref _volume, value); }
        }
        public string VolumeDescription
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
            if (!string.IsNullOrEmpty(_volumeName) && !string.IsNullOrEmpty(_volumeDescription))
            {
                var editVolume = new Volume { Name = _volumeName, Description = _volumeDescription };
                App.Locator.Main.AddVolume(editVolume);
                VolumeName = string.Empty;
                VolumeDescription = string.Empty;
                //Volume.Name = string.Empty;
                //Volume.Description = string.Empty;
                await Navigation.PopAsync();
            }
        }
    }
}
