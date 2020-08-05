using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;


namespace Game
{
    class Controller
    {
        public static IField Field;
        static public System.Windows.Media.ImageSource BitmapToImageSource(Bitmap value)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)value).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit(); 

            return image;
        }

        public static void restart()
        {
            Field = new Model.Fild();
            ((Model.Fild)Field).pushBackColumn(1, new Model.SmallFish());
        }
    }
}
