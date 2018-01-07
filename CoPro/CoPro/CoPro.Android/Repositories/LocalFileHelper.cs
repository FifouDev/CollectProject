using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoPro.Repositories;
using System.IO;
using Xamarin.Forms;
using CoPro.Droid.Repositories;

[assembly : Dependency(typeof(LocalFileHelper))]
namespace CoPro.Droid.Repositories
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string dbName)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, dbName);
        }
    }
}