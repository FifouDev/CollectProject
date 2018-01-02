using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoPro.Assets
{
    [ContentProperty("SourceImage")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string SourceImage { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (SourceImage == null)
            {
                return null;
            }
       
            var imageSource = ImageSource.FromResource($"CoPro.Assets.{SourceImage}");

            return imageSource;
        }
    }
}
