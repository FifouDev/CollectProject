using CoPro.Models;
using CoPro.Repositories;
using CoPro.Repositories.Implementations;
using CoPro.ViewModels;
using CoPro.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CoPro
{
    public partial class App : Application
    {

        private static object padlock = new object();

        private static ViewModelLocator _locator;
        private static VolumeRepository _volumeRepository;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    lock (padlock)
                    {
                        if (_locator == null)
                        {
                            Initialize();
                            _locator = new ViewModelLocator();
                        }
                    }
                }

                return _locator;
            }
        }

        public static VolumeRepository VolumeRepository
        {
            get
            {
                if (_volumeRepository == null)
                {
                    _volumeRepository = new VolumeRepository(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("Volume.db3"));
                }
                return _volumeRepository;
            }
        }


        public static void Initialize()
        {
        }

        public App()
        {
            InitializeComponent();
            //SQLiteDataBase.SetConnectionProviderAsync(new SQLiteConnectionProvider()).GetAwaiter().GetResult();
            MainPage = new NavigationPage(Locator.MainPage);
            //MainPage = new MainPage();                 
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
