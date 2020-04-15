using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using MvvmProdactApp.DataContext;

namespace MvvmProdactApp.Services
{
    public static class AppService
    {
        public static StoredObjects StaticStoredObjs { get; set; }

        public static BitmapImage ConvertBitmap(byte[] bmp)
        {
            using (var memory = new MemoryStream(bmp))
            {
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }
    }
}
