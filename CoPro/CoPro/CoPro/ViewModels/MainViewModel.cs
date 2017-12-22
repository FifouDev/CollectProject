using Android.Content.Res;
using CoPro.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoPro.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            _volumes = new ObservableCollection<Volume>();
            GetVolumes();
            _series = new ObservableCollection<Volume>();
            GetSeries();
            _suggestions = new ObservableCollection<Suggestion>();
            GetSuggestions();
        }

        #region Field
        private ObservableCollection<Volume> _volumes;      
        private ObservableCollection<Volume> _series;
        private ObservableCollection<Suggestion> _suggestions;
        private INavigation _navigation;
        #endregion
        #region Properties
        public INavigation Navigation
        {
            get { return _navigation; }
            set { Set(ref _navigation, value); }
        }
        public ObservableCollection<Volume> Volumes
        {
            get { return _volumes; }
            set { Set(ref _volumes, value); }
        }
        public ObservableCollection<Volume> Series
        {
            get { return _series; }
            set { Set(ref _series, value); }
        }
        public ObservableCollection<Suggestion> Suggestions
        {
            get { return _suggestions; }
            set { Set(ref _suggestions, value); }
        }

        #endregion
        #region Methods
        public void GetSeries()
        {
            _series.Add(new Volume { Id = 1, Name = "Dragon Ball", Description = "De la Balle, mon gars", ImageUrl = "Dragon-Ball-FighterZ.jpg" });
            _series.Add(new Volume { Id = 2, Name = "Naruto", Description = "Putain de musique motivante", ImageUrl = "Naruto.jpg" });
            _series.Add(new Volume { Id = 3, Name = "Bleach", Description = "Après Aizen, le néant", ImageUrl = "Bleach2.jpg" });

        }

        public void GetVolumes()
        {
            _volumes.Add(new Volume { Id = 1, Name = "Sangoku", Description = "De la Balle, mon gars", ImageUrl = "Dragon-Ball-FighterZ.jpg" });
            _volumes.Add(new Volume { Id = 2, Name = "Pilaf", Description = "Putain de musique motivante", ImageUrl = "Naruto.jpg" });
            _volumes.Add(new Volume { Id = 3, Name = "Tortue Génial", Description = "Après Aizen, le néant", ImageUrl = "Bleach2.jpg" });
        }

        public void GetSuggestions()
        {
            _suggestions.Add(new Suggestion { Id = 1, UserName = "Mr Savy", Text = "Franchement pas ouf", ImageUrl = "Arnaud.jpg" });
            _suggestions.Add(new Suggestion { Id = 2, UserName = "Prophete Foures", Text = "M'en fous, je fais ça pour toi", ImageUrl = "prophete.jpg" });
            _suggestions.Add(new Suggestion { Id = 3, UserName = "Lixfe", Text = "A babord toute", ImageUrl = "ok.jpg" });
        }

        public void AddVolume(Volume volume)
        {
            var isVolumeExist = _volumes.Any(vol => vol.Name == volume.Name);
            if (!isVolumeExist)
            {
                _volumes.Add(volume);
            }
        }
        #endregion
        #region Command

        private ICommand _deleteVolumeCommand;
        public ICommand DeleteVolumeCommand
        {
            get { return _deleteVolumeCommand ?? (_deleteVolumeCommand = new RelayCommand<Volume>(ExecuteDeleteCommand)); }
        }

        private void ExecuteDeleteCommand(Volume volume)
        {
            _volumes.Remove(volume);
            //((IEnumerable<Volume>)_volumes).ToList().IndexOf(item); 
        }

        private ICommand _addVolumeCommand;
        public ICommand AddVolumeCommand
        {
            get { return _addVolumeCommand ?? (_addVolumeCommand = new RelayCommand(ExecuteAddCommand)); }
        }

        private void ExecuteAddCommand()
        {
            _volumes.Add(new Volume { Id = 4, Name = "Jackie Choun", Description = "Après Aizen, le néant", ImageUrl = @"\Assets\Bleach2.jpg" });
        }


        private ICommand _toEditVolumePage;
        public ICommand ToEditVolumePage
        {
            get { return _toEditVolumePage ?? (_toEditVolumePage = new RelayCommand(ExecuteEditCommand)); }
        }

        private async void ExecuteEditCommand()
        {
            await Navigation.PushAsync(App.Locator.EditPage, false);
        }
        #endregion
    }
}
