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
            _series = new ObservableCollection<Volume>();
            _suggestions = new ObservableCollection<Suggestion>();
        }
        #region Field
        private ObservableCollection<Volume> _volumes;
        private ObservableCollection<Volume> _series;
        private ObservableCollection<Suggestion> _suggestions;
        #endregion
        #region Properties
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
            _series.Add(new Volume { Id = 1, Name = "Dragon Ball", Description = "De la Balle, mon gars", ImageUrl = @"\Assets\Dragon-Ball-FighterZ.jpg" });
            _series.Add(new Volume { Id = 2, Name = "Naruto", Description = "Putain de musique motivante", ImageUrl = @"\Assets\Naruto.jpg" });
            _series.Add(new Volume { Id = 3, Name = "Bleach", Description = "Après Aizen, le néant", ImageUrl = @"\Assets\Bleach2.jpg" });

        }

        public void GetVolumes()
        {
            _volumes.Add(new Volume { Id = 1, Name = "Sangoku", Description = "De la Balle, mon gars", ImageUrl = @"\Assets\Dragon-Ball-FighterZ.jpg" });
            _volumes.Add(new Volume { Id = 2, Name = "Pilaf", Description = "Putain de musique motivante", ImageUrl = @"\Assets\Naruto.jpg" });
            _volumes.Add(new Volume { Id = 3, Name = "Tortue Génial", Description = "Après Aizen, le néant", ImageUrl = @"\Assets\Bleach2.jpg" });
        }

        public void GetSuggestions()
        {
            _suggestions.Add(new Suggestion { Id = 1, UserName = "Mr Savy", Text = "Franchement pas ouf", ImageUrl = @"\Assets\Arnaud.jpg" });
            _suggestions.Add(new Suggestion { Id = 2, UserName = "Prophete Foures", Text = "M'en fous, je fais ça pour toi", ImageUrl = @"\Assets\prophete.jpg" });
            _suggestions.Add(new Suggestion { Id = 3, UserName = "Lixfe", Text = "A babord toute", ImageUrl = @"\Assets\ok.jpg" });
        }

        public void AddVolume()
        {
            _volumes.Add(new Volume { Id = 4, Name = "Jackie Choun", Description = "Après Aizen, le néant", ImageUrl = @"\Assets\Bleach2.jpg" });
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
        #endregion
    }
}
