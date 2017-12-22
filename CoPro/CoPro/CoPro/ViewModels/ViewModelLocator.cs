using CoPro.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoPro.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public EditVolumeViewModel Edit => ServiceLocator.Current.GetInstance<EditVolumeViewModel>();
        public MainPage MainPage => ServiceLocator.Current.GetInstance<MainPage>();
        public EditVolumePage EditPage => ServiceLocator.Current.GetInstance<EditVolumePage>();
        //public NavigationPage NavigationPage => ServiceLocator.Current.GetInstance<NavigationPage>();      

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var ioc = SimpleIoc.Default;
            ioc.Register<MainViewModel>();
            ioc.Register<EditVolumePage>();
            ioc.Register<MainPage>();
            //ioc.Register<NavigationPage>();
            ioc.Register<EditVolumeViewModel>();
        }
    }
}
