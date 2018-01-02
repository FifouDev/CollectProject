using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CoPro.Repositories.Implementations;
using System.IO;
using System.Linq;
using SQLite.Net.Platform.XamarinAndroid;

namespace CoPro.
    Droid
{
    [Activity(Label = "CoPro", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private VolumeRepository _volumeRepository;

        private string GetDbPath()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "Todo.db3");
        }
        protected override async void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);          
            //SetContentView(Resource.Layout.Main);

            var path = GetDbPath();

            _volumeRepository = new VolumeRepository();
            await _volumeRepository.InitializeAsync(path, new SQLitePlatformAndroid());
            var items = await _volumeRepository.GetAllAsync();
            // var todoListView = FindViewById<ListView>(Resource.Id.TodoListView);
            //todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, items.Select(i => i.Name).ToList());
            //var adapter = todoListView.Adapter as ArrayAdapter<string>;

            // ListView list = FindViewById<ListView>(Resource.Id.MainListView);

            //todoListView.Adapter = new ArrayAdapter<string>(this, global::Android.Resource.Layout.SimpleListItem1, items.Select(i => i.Name).ToList());

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

