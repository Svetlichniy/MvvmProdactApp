using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Drawing;
using MvvmProdactApp.DataContext;
using MvvmProdactApp.ViewModels;

namespace MvvmProdactApp.Services
{
    public static class AppService
    {
        public static StoredObjects StaticStoredObjs { get; set; }
        public static PropertyVM PropertyVM { get; set; }
        public static DataContainerVM DataContainerVM { get; set; }
        public static TreeNavigationVM TreeNavigationVM { get; set; }
        public static ProdactVM ProdactVM { get; set; }

        public static BitmapImage ConvertBitmap(byte[] bmp)
        {
            if (bmp == null)
                return null;

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

        public static byte[] ConverBitmapImageToByteArray(BitmapImage img)
        {
            if (img == null)
                return null;

            
            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(img));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
    }
}
